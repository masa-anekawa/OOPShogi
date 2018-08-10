using System;
namespace OOPShogi.Piece
{
    public class Rook: BPiece
    {
        public Rook(bool isWhite) : base(EPieceSort.kRook, isWhite) {}

        public override bool HasControlTo(Coord coord)
		{
            if (!base.HasControlTo(coord)) return false;

            if (Promoted && Coord.EightNeighborDistance(coord) == 1)
                return true;
            else
                return coord.Row == 0 || coord.Col == 0;
		}
	}
}
