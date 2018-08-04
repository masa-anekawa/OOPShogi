using System;
namespace OOPShogi.Piece
{
    public class King: BPiece
    {
        public King(EPieceSort sort) : base(sort)
        {
        }

		public override bool CanPromote()
		{
            return false;
		}

		public override bool HasControl(Coord to)
		{
            return Coord.ManhattanDistance(Coord.Zero, to) == 1;
		}
	}
}
