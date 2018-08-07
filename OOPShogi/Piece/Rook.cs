using System;
namespace OOPShogi.Piece
{
    public class Rook: BPiece
    {
        public Rook(bool isWhite) : base(EPieceSort.kRook, isWhite) {}

		public override bool CanPromote()
		{
            return base.CanPromote();
		}

        public override bool HasControlTo(Coord coord)
		{
            if (coord == Coord.Zero)
                return false;
            else if (IsPromoted && Coord.EightNeighborDistance(coord) == 1)
                return true;
            else
                return coord.row == 0 || coord.col == 0;
		}
	}
}
