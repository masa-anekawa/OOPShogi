using System;
namespace OOPShogi.Piece
{
    public class Bishop: BPiece
    {
        public Bishop(bool isWhite) : base(EPieceSort.kBishop, isWhite) {}

        public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (IsPromoted && Coord.EightNeighborDistance(coord) == 1)
                return true;
            else
                return Math.Abs(coord.row) == Math.Abs(coord.col);
		}
	}
}
