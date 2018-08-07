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
        private List<BPiece> _pieces;
        private Dictionary<BPiece, Coord> _pieceCoordMap;

        public Board(Coord coord)
        {
            kSize = coord;
            _pieces = new List<BPiece>(coord.row * coord.col);
            _pieceCoordMap = new Dictionary<BPiece, Coord>();
        }

        // may return null
        public BPiece GetPiece(Coord coord){
            if (!coord.IsWithin(kSize))
            {
                Trace.TraceError($"Board{coord} is out of the board.");
                Environment.Exit(1);
            }
            return _pieces[calcPiecesIndex(coord)];
        }

        // overwrite is not allowed
        public bool SetPiece(Coord coord, BPiece piece){
            if (GetPiece(coord) != null)
            {
                Trace.TraceError($"error: Board{coord} is already occupied.");
                return false;
            }
            _pieceCoordMap.Add(piece, coord);
            _pieces[calcPiecesIndex(coord)] = piece;
            return true;
        }

        // returned value is non-nullable
        public Coord GetCoord(BPiece piece) => _pieceCoordMap[piece];

        // overwrite is not allowed
        public void SetCoord(BPiece piece, Coord coord){
            _pieceCoordMap.Add(piece, coord);
        }

        public bool isMovable(BPiece piece, Coord to){
            Coord from = _pieceCoordMap[piece];
            if (!_pieceCoordMap.ContainsKey(piece)) return false;
            if (!to.IsWithin(kSize)) return false;
            if (!piece.HasControlTo(to)) return false;
            if (!piece.CanJump && !this.IsEmptyBetween(from, to)) return false;

            return true;
        }
        public bool isMovable(Coord from, Coord to) => isMovable(GetPiece(from), to);

        private bool IsEmptyBetween(Coord from, Coord to){
            // TODO
            return true;
        }

        private int calcPiecesIndex(Coord coord){
            return coord.row * kSize.col + coord.col;
        }
    }
}
