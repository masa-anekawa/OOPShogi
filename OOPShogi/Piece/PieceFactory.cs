using System;
using System.Diagnostics;

namespace OOPShogi.Piece
{
    public static class PieceFactory
    {
        public static BPiece MakePiece(EPieceSort sort, bool isWhite)
        {
            BPiece ret = null;
            switch (sort)
            {
                case EPieceSort.kKing:
                    ret = new King(isWhite);
                    break;
                case EPieceSort.kRook:
                    ret = new Rook(isWhite);
                    break;
                case EPieceSort.kBishop:
                    ret = new Bishop(isWhite);
                    break;
                case EPieceSort.kGold:
                    ret = new Gold(isWhite);
                    break;
                case EPieceSort.kSilver:
                    ret = new Silver(isWhite);
                break;
                case EPieceSort.kKnight:
                    ret = new Knight(isWhite);
                    break;
                case EPieceSort.kLance:
                    ret = new Lance(isWhite);
                    break;
                case EPieceSort.kPorn:
                    ret = new Porn(isWhite);
                break;
                default:
                    Trace.TraceError("the piece sort is unknown");
                    Environment.Exit(1);
                    break;
            }
            if (ret == null)
            {
                Trace.TraceError("PieceFactory#NewPiece(): couldn't make a Piece");
            }
            return ret;
        }
    }
}
