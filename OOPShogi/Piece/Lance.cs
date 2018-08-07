using System;
namespace OOPShogi.Piece
{
    public class Lance: BPiece
    {
        public Lance(bool isWhite): base(EPieceSort.kLance, isWhite){}

		public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (!IsPromoted)
                return coord.row / Forward.row > 0 && coord.col == 0;
            else
                return IsInsideGoldControl(coord);
		}
	}
}
