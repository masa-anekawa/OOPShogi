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
        public EPieceSort Sort { get; private set; }
        public bool IsPromoted { get; private set; }
        public readonly bool IsWhite;

        public BPiece(EPieceSort sort, bool isWhite)
        {
            Sort = sort;
            IsPromoted = false;
            IsWhite = isWhite;
        }

		public override string ToString()
		{
            return "BPiece: " + base.ToString();
		}


		public virtual bool CanPromote()
        {
            return !IsPromoted;
        }

        public virtual bool CanJump()
        {
            return false;
        }

        public abstract bool HasControlTo(Coord coord);


        public void Promote()
        {
            IsPromoted = true;
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
