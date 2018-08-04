using System;
using System.Diagnostics;
using System.Collections.Generic;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class Board
    {
        public readonly Coord kSize;
        private List<BPiece> _pieces;

        public Board(Coord coord)
        {
            kSize = coord;
            _pieces = new List<BPiece>(coord.row * coord.col);
        }

        public BPiece GetBPiece(Coord coord){
            if (!coord.IsWithin(kSize))
            {
                Trace.TraceError($"Board{coord} is out of the board.");
                Environment.Exit(1);
            }
            return _pieces[calcBPiecesIndex(coord)];
        }
        
        public bool SetBPiece(Coord coord, BPiece piece){
            if (GetBPiece(coord) != null)
            {
                Trace.TraceError($"error: Board{coord} is already occupied.");
                return false;
            }
            _pieces[calcBPiecesIndex(coord)] = piece;
            return true;
        }

        public bool isMovable(BPiece piece, Coord to){
            // TODO
            return true;
        }

        public bool isMovable(Coord from, Coord to){
            return isMovable(GetBPiece(from), to);
        }

        private int calcBPiecesIndex(Coord coord){
            return coord.row * kSize.col + coord.col;
        }
    }
}
