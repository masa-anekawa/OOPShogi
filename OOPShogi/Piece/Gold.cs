using System;
namespace OOPShogi.Piece
{
    public class Gold: BPiece
    {
        public Gold(bool isWhite): base(EPieceSort.kGold, isWhite) {}

		public override bool CanPromote()
		{
            return false;
		}

		public override bool HasControlTo(Coord coord)
		{
            return IsInsideGoldControl(coord);
		}
	}
}
