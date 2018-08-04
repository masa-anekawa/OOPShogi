using System;
namespace OOPShogi.Piece
{
    public enum EPieceSort
    {
        kKing,
        kRook,
        kBishop,
        kGold,
        kSilver,
        kKnight,
        kLance,
        kPorn
    }

    public abstract class BPiece
    {
        private EPieceSort _sort;
        private bool _isPromoted;

        public EPieceSort Sort
        {
            get { return _sort; }
            private set { _sort = value; }
        }

        public bool IsPromoted
        {
            get { return _isPromoted; }
            private set { _isPromoted = value; }
       }

        public BPiece(EPieceSort sort)
        {
            Sort = sort;
            IsPromoted = false;
        }

        public virtual bool CanPromote()
        {
            return !IsPromoted;
        }

        public void Promote(){
            IsPromoted = true;
        }

        public abstract bool HasControl(Coord to);

    }
}
