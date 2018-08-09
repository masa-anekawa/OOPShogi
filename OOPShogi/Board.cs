using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class Board
    {
        public readonly Coord kSize;
        private IList<BPiece> _pieceList;
        private IDictionary<BPiece, Coord> _pieceCoordMap;

        public Board(Coord coord)
        {
            CheckIfCoordIsPositive(coord);
            kSize = coord;
            _pieceList = Enumerable.Repeat<BPiece>(null, coord.row * coord.col)
                                   .ToList();
            _pieceCoordMap = new Dictionary<BPiece, Coord>();
        }

        /// <summary>
        /// Gets the piece by coordinate.
        /// Returns null if the table is empty for the coordinate.
        /// </summary>
        /// <returns>The piece.</returns>
        /// <param name="coord">Coordinate.</param>
        public BPiece GetPiece(Coord coord){
            CheckIfCoordIsOnBoard(coord);
            return _pieceList[CalcPiecesIndex(coord)];
        }

        /// <summary>
        /// Gets the coordinate by piece.
        /// </summary>
        /// <returns>The coordinate.</returns>
        /// <param name="piece">Piece.</param>
        public Coord GetCoord(BPiece piece)
        {
            CheckIfMapContains(piece);
            return _pieceCoordMap[piece];
        }

        /// <summary>
        /// Moves the specified piece.
        /// </summary>
        /// <returns>Taken piece, if this move takes.</returns>
        /// <param name="piece">Piece that is moved.</param>
        /// <param name="to">Coordinate the piece is moved to.</param>
        public BPiece Move(BPiece piece, Coord to)
        {
            if (!IsMovable(piece, to))
            {
                Trace.TraceError($"board cannnot move {piece} from {GetCoord(piece)} to {to}");
                Environment.Exit(1);
            }

            BPiece toPiece = GetPiece(to);
            if (toPiece != null)
            {
                // this move takes a opponent's piece.
                Debug.Assert(toPiece.IsWhite != piece.IsWhite);
                RemovePieceByCoord(GetCoord(toPiece));
                RemoveCoordByPiece(toPiece);
            }
            RemovePieceByCoord(GetCoord(piece));
            RemoveCoordByPiece(piece);
            SetCoordByPiece(piece, to);
            SetPieceByCoord(piece, to);
            return toPiece;
        }

        /// <summary>
        /// Drop the piece to specified coordinate.
        /// </summary>
        /// <param name="piece">Piece that is dropped.</param>
        /// <param name="dropTo">where the piece is dropped.</param>
        public void Drop(BPiece piece, Coord dropTo)
        {
            if (!IsDropable(piece, dropTo))
            {
                Trace.TraceError($"couldn't drop {piece} to {dropTo}");
                Environment.Exit(1);
            }
            SetPieceByCoord(piece, dropTo);
            SetCoordByPiece(piece, dropTo);
        }

        /// <summary>
        /// Checks if the piece can promote,
        /// including information about the board and the piece.
        /// </summary>
        /// <returns><c>true</c>, if promote was caned, <c>false</c> otherwise.</returns>
        /// <param name="piece">Piece.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public bool CanPromote(BPiece piece, Coord from, Coord to)
        {
            return piece.CanPromote() &&
                        (IsWithinOpponentsField(piece.IsWhite, from) ||
                         IsWithinOpponentsField(piece.IsWhite, to));
        }

        // overwrite is not allowed
        private bool SetPieceByCoord(BPiece piece, Coord coord){
            CheckIfCoordIsOnBoard(coord);
            if (GetPiece(coord) != null)
            {
                Trace.TraceError($"error: Board{coord} is already occupied.");
                return false;
            }
            _pieceList[CalcPiecesIndex(coord)] = piece;
            return true;
        }

        private bool RemovePieceByCoord(Coord coord){
            if (GetPiece(coord) == null)
                return false;
            else
            {
                _pieceList[CalcPiecesIndex(coord)] = null;
                return true;
            }
        }

        // overwrite is not allowed
        private bool SetCoordByPiece(BPiece piece, Coord coord){
            CheckIfCoordIsOnBoard(coord);
            CheckIfMapIsEmptyFor(piece);
            _pieceCoordMap.Add(piece, coord);
            return true;
        }

        private bool RemoveCoordByPiece(BPiece piece){
            if (!_pieceCoordMap.ContainsKey(piece))
                return false;
            else{
                _pieceCoordMap.Remove(piece);
                return true;
            }
        }

        // move *your* peice
        private bool IsMovable(
            BPiece piece, Coord to, bool isDrop, Coord? dropTo){
            if (piece == null) return false;

            // failFlag is used for tell onFailure() is called in CheckIf funcitons
			bool failFlag = false;

            Coord from;
            if(isDrop){
                if (!dropTo.HasValue){
                    Trace.TraceError("dropFrom cannot be null when isDrop == true");
                    Environment.Exit(1);
                }
                from = dropTo.Value;
            }
            else{
                CheckIfMapContains(piece, () => failFlag = false);
                if (failFlag) return false;

                from = GetCoord(piece);
            }

            CheckIfCoordIsOnBoard(from, () => failFlag = true);
            CheckIfCoordIsOnBoard(to, () => failFlag = true);
            if (failFlag) return false;

            // cannot move to outside of the control
            if (!piece.HasControlTo(to - from))
                return false;
            // cannot move onto your piece
            if (GetPiece(to) != null && GetPiece(to).IsWhite == piece.IsWhite)
                return false;
            // cannot move over pieces, except for non-promoted knight
            if ((from.row == to.row || from.col == to.col) &&
                !piece.CanJump() &&
                !this.IsEmptyBetween(from, to))
                return false;

            return true;
        }

        private bool IsMovable(Coord from, Coord to){
            bool failFlag = false;
            CheckIfCoordIsOnBoard(from, () => failFlag = true);
            CheckIfPieceListIsNotNullFor(from, () => failFlag = true);
            if (failFlag) return false;

            return IsMovable(GetPiece(from), to, false, null); 
        }

        private bool IsMovable(BPiece piece, Coord to)
            => IsMovable(piece, to, false, null);

        private bool IsDropable(BPiece piece, Coord dropTo){
            bool failFlag = false;
            CheckIfCoordIsOnBoard(dropTo, () => failFlag = true);
            if (failFlag) return false;

            // TODO: Optimization
            foreach (int i in Enumerable.Range(0, kSize.row))
            {
                foreach (int j in Enumerable.Range(0, kSize.col))
                {
                    if (IsMovable(piece, new Coord(i, j), true, dropTo) &&
                       GetPiece(dropTo) == null)
                        return true;
                }
            }
            return false;
        }


        private bool IsEmptyBetween(Coord from, Coord to)
        {
            CheckIfCoordIsOnBoard(from);
            CheckIfCoordIsOnBoard(to);

            if (from.row == to.row)
            {
                for (int col = Math.Min(from.col, to.col) + 1;
                     col < Math.Max(from.col, to.col);
                     ++col)
                {
                    if (GetPiece(new Coord(from.row, col)) != null)
                        return false;
                }
                return true;
            }
            else if (from.col == to.col)
            {
                for (int row = Math.Min(from.row, to.row) + 1;
                     row < Math.Max(from.row, to.row);
                     ++row)
                {
                    if (GetPiece(new Coord(row, from.col)) != null)
                        return false;
                }
                return true;
            }
            else
            {
                Trace.TraceError($"{from} and {to} do not have same row nor col");
                Environment.Exit(1);
                return false;
            }
        }

        private int CalcPiecesIndex(Coord coord){
            return coord.row * kSize.col + coord.col;
        }

        private Action defaultOnFailure = () => Environment.Exit(1);

        private void CheckIfMapContains(BPiece piece, Action onFailure = null)
        {
            if (onFailure == null) onFailure = defaultOnFailure;
            if(!_pieceCoordMap.ContainsKey(piece)){
                Trace.TraceError($"{nameof(_pieceCoordMap)} does not contains {piece}");
                onFailure();
            }
        }
        private void CheckIfMapIsEmptyFor(BPiece piece, Action onFailure = null)
        {
            if (onFailure == null) onFailure = defaultOnFailure;
            if (_pieceCoordMap.ContainsKey(piece)){
                Trace.TraceError($"{nameof(_pieceCoordMap)} for {piece} is already occupied");
                onFailure();
            }
        }

        private void CheckIfCoordIsOnBoard(Coord coord, Action onFailure = null)
        {
            if (onFailure == null) onFailure = defaultOnFailure;
            if (!coord.IsLessThan(kSize) || !coord.IsGreaterThanOrEqualTo(Coord.Zero))
            {
                Trace.TraceError($"{coord} is out of the board.");
                onFailure();
            }
        }
        private void CheckIfCoordIsNonNegative(Coord coord, Action onFailure = null)
        {
            if (onFailure == null) onFailure = defaultOnFailure;
            if (coord.row < 0 || coord.col < 0)
            {
                Trace.TraceError($"Either row or col of {coord} is negative");
                onFailure();
            }
        }
        private void CheckIfCoordIsPositive(Coord coord, Action onFailure = null)
        {
            if (onFailure == null) onFailure = defaultOnFailure;
            if (coord.row <= 0 || coord.col <= 0)
            {
                Trace.TraceError($"Either row or col of {coord} is non-positive");
                onFailure();
            }
        }

        private void CheckIfPieceListIsNotNullFor(Coord coord, Action onFailure = null){
            if (onFailure == null) onFailure = defaultOnFailure;
            if(GetPiece(coord) == null){
                Trace.TraceError($"couldn't find a piece for {coord}");
                onFailure();
            }
        }

        private bool IsWithinOpponentsField(bool isWhite, Coord coord){
            CheckIfCoordIsOnBoard(coord);
            if (isWhite)
            {
                return coord.row < kSize.row / 3;
            }
            else
            {
                return coord.row >= kSize.row - kSize.row / 3;
            }
        }
    }
}
