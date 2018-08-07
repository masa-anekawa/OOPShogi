using System;
namespace OOPShogi.Piece
{
    public class Rook: BPiece
    {
        public Rook(bool isWhite) : base(EPieceSort.kRook, false, isWhite) {}

		public override bool CanPromote()
		{
            return base.CanPromote();
		}

        public override bool HasControlTo(Coord coord)
		{
            if (coord == Coord.Zero) return false;
            if (IsPromoted && Coord.ManhattanDistance(coord) == 1)
                return true;

            return coord.row == 0 || coord.col == 0;
		}
	}
}
