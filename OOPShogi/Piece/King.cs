using System;
namespace OOPShogi.Piece
{
    public class King: BPiece
    {
        public King(bool isWhite) : base(EPieceSort.kKing, isWhite) {}

		public override bool CanPromote()
		{
            return false;
		}

        public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            return Coord.EightNeighborDistance(coord) == 1;
		}
	}
}
