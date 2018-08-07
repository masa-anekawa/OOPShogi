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
        public bool CanJump { get; private set; }

        public BPiece(EPieceSort sort, bool canJump, bool isWhite)
        {
            Sort = sort;
            IsPromoted = false;
            CanJump = canJump;
            IsWhite = isWhite;
        }

        public virtual bool CanPromote()
        {
            return !IsPromoted;
        }

        public virtual void Promote(){
            IsPromoted = true;
        }

        public abstract bool HasControlTo(Coord coord);

        protected bool IsInsideGoldControl(Coord coord){
            return Coord.ManhattanDistance(coord) == 1 &&
                        coord != new Coord(1, 1)       &&
                        coord != new Coord(1, -1);
        }

        protected Coord Forward(){
            if (IsWhite) return Coord.UnitRow * -1;
            else return Coord.UnitRow;
        }
        protected Coord Right(){
            if (IsWhite) return Coord.UnitCol;
            else return Coord.UnitCol * -1;
        }
	}
}
