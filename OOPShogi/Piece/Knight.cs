using System;
namespace OOPShogi.Piece
{
    public class Knight: BPiece
    {
        public Knight(bool isWhite): base(EPieceSort.kKnight, isWhite){}

		public override bool CanJump()
		{
            return !Promoted;
		}

		public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (!Promoted)
                return coord == (Forward * 2 + Right) ||
                       coord == (Forward * 2 + Left);
            else
                return IsInsideGoldControl(coord);
		}
	}
}
