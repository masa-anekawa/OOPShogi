using System;
namespace OOPShogi.Piece
{
    public class Porn: BPiece
    {
        public Porn(bool isWhite): base(EPieceSort.kPorn, isWhite){}

		public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (!Promoted)
                return coord == Forward;
            else
                return IsInsideGoldControl(coord);
		}
	}
}
