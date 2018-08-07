using System;
namespace OOPShogi.Piece
{
    public class Knight: BPiece
    {
        public Knight(bool isWhite): base(EPieceSort.kKnight, true, isWhite){}

		public override bool CanPromote()
		{
            return base.CanPromote();
		}

		public override bool HasControlTo(Coord coord)
		{
            if (!IsPromoted)
                return coord == new Coord(-2, 1) || coord == new Coord(-2, -1);
            else
                return IsInsideGoldControl(coord);
		}
	}
}
