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
        public bool Promoted { get; private set; }
        public bool White { get; private set; }

        protected BPiece(EPieceSort sort, bool isWhite)
        {
            Sort = sort;
            Promoted = false;
            White = isWhite;
        }

		public override string ToString()
		{
            return "[BPiece: " +
                (Promoted ? "Promoted" : "Non-Promoted") + " " +
                (White ? "White" : "Black") + " " +
                Sort + "]";
		}

		public virtual bool CanPromote()
        {
            return !Promoted;
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
            Promoted = true;
        }

        public void PrepareToBeTaken(){
            White = !White;
            Promoted = false;
        }

        protected bool IsInsideGoldControl(Coord coord){
            return Coord.EightNeighborDistance(coord) == 1 &&
                        coord != (Backward + Right)        &&
                        coord != (Backward + Left);
        }

        protected Coord Forward{
            get { return Coord.UnitRow * (White ? -1 : 1); }
        }
        protected Coord Backward{
            get { return Forward * -1; }
        }
        protected Coord Right{
            get { return Coord.UnitCol * (White ? 1 : -1); }
        }
        protected Coord Left{
            get { return Right * -1; }
        }
	}
}
