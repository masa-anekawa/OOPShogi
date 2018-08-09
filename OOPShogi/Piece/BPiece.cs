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
        kPorn,
    }

    public abstract class BPiece
    {
        public EPieceSort Sort { get; private set; }
        public bool IsPromoted { get; private set; }
        public bool IsWhite { get; private set; }

        protected BPiece(EPieceSort sort, bool isWhite)
        {
            Sort = sort;
            IsPromoted = false;
            IsWhite = isWhite;
        }

		public override string ToString()
		{
            return "[BPiece: " +
                (IsPromoted ? "Promoted" : "Non-Promoted") + " " +
                (IsWhite ? "White" : "Black") + " " +
                Sort + "]";
		}

		public virtual bool CanPromote()
        {
            return !IsPromoted;
        }

        public virtual bool CanJump()
        {
            return false;
        }

        public virtual bool HasControlTo(Coord coord){
            return coord != Coord.Zero;
        }

        public void Promote()
        {
            IsPromoted = true;
        }

        public void Betray(){
            IsWhite = !IsWhite;
        }

        protected bool IsInsideGoldControl(Coord coord){
            return Coord.EightNeighborDistance(coord) == 1 &&
                        coord != (Backward + Right)        &&
                        coord != (Backward + Left);
        }

        protected Coord Forward{
            get { return Coord.UnitRow * (IsWhite ? -1 : 1); }
        }
        protected Coord Backward{
            get { return Forward * -1; }
        }
        protected Coord Right{
            get { return Coord.UnitCol * (IsWhite ? 1 : -1); }
        }
        protected Coord Left{
            get { return Right * -1; }
        }
	}
}
