using System;
namespace OOPShogi.Piece
{
    public class Silver: BPiece
    {
        public Silver(bool isWhite): base(EPieceSort.kSilver, isWhite){}

		public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (!IsPromoted)
                return Coord.EightNeighborDistance(coord) == 1
                            && coord != Right
                            && coord != Left
                            && coord != Backward;
            else
                return IsInsideGoldControl(coord);
		}
	}
}
