using System;
namespace OOPShogi.Piece
{
    public class Lance: BPiece
    {
        public Lance(bool isWhite): base(EPieceSort.kLance, isWhite){}

		public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (!Promoted)
                return coord.Row / Forward.Row > 0 && coord.Col == 0;
            else
                return IsInsideGoldControl(coord);
		}
	}
}
