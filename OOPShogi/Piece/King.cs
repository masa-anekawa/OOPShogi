using System;
namespace OOPShogi.Piece
{
    public class King: BPiece
    {
        public King(bool isWhite) : base(EPieceSort.kKing, false, isWhite) {}

		public override bool CanPromote()
		{
            return false;
		}

        public override bool HasControlTo(Coord coord)
		{
            return Coord.ManhattanDistance(coord) == 1;
		}
	}
}
