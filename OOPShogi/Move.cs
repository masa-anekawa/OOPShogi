using System;

using OOPShogi.Piece;

namespace OOPShogi
{
    /// <summary>
    /// 着手．生成時点で常に合法手であることが保証されている．
    /// </summary>
    public class Move
    {
        public BPiece piece;
        public Coord to;
        public bool isWhite;
        public bool doPromote;
        public int index;

        public Move(
            BPiece _piece,
            Coord _to,
            bool _isWhite,
            bool _doPromote,
            int _index)
        {
            piece = _piece;
            to = _to;
            isWhite = _isWhite;
            doPromote = _doPromote;
            index = _index;
        }
    }
}
