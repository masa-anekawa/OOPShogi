using System;

using OOPShogi.Piece;

namespace OOPShogi
{
    /// <summary>
    /// Move.
    /// </summary>
    public struct Move
    {
        public EPieceSort sort;
        public Coord from;
        public Coord to;
        public bool white;
        public bool doPromote;
        public bool doDrop;

        public Move(
            EPieceSort _pieceSort,
            Coord _from,
            Coord _to,
            bool _white,
            bool _doPromote,
            bool _doDrop)
        {
            sort = _pieceSort;
            from = _from;
            to = _to;
            white = _white;
            doPromote = _doPromote;
            doDrop = _doDrop;
        }

        public override string ToString()
        {
            if (doDrop)
                return $"[Move: Drop {(white ? "White" : "Black")} {sort} to {to}]";
            else
                return $"[Move: Move {(white ? "White" : "Black")} {sort} from {from} to {to}";
        }
    }
}
