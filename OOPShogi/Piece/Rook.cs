using System;
namespace OOPShogi.Piece
{
    public class Rook: BPiece
    {
        public Rook(EPieceSort sort) : base(sort)
        {
        }

		public override bool CanPromote()
		{
            return base.CanPromote();
		}

		public override bool HasControl(Coord to)
		{
            if (to == Coord.Zero) return false;

            if (IsPromoted && Coord.ManhattanDistance(Coord.Zero, to) == 1)
                return true;

            return to.row == 0 || to.col == 0;
		}
	}
}
