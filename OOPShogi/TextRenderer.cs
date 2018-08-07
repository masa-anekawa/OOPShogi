using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

using static System.Linq.Enumerable;
using static System.Environment;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class TextRenderer
    {
        private readonly TextWriter _textWriter;

        public TextRenderer(TextWriter textWriter){
            _textWriter = textWriter;
        }

        public void RenderBoard(Board board){
            if(board == null){
                Trace.TraceError("board is null");
                Exit(1);
            }
            int row = board.kSize.row;
            int col = board.kSize.col;
            foreach (var i in Range(0, row))
            {
                RenderHorizontalLine(col * 2 + (col + 1));
                foreach (var j in Range(0, col))
                {
                    Write("|");
                    RenderPiece(board.GetPiece(new Coord(i, j)));
                }
                WriteLine("|");
            }
            RenderHorizontalLine(col * 2 + (col + 1));
        }

        public void RenderPiece(BPiece piece){
            if (piece == null)
            {
                Write("..");
                return;
            }

            if (piece.IsPromoted) Write("!");
            else                  Write(".");

            switch(piece.Sort){
                case EPieceSort.kKing:
                    Write((piece.IsWhite ? "K" : "k"));
                    break;
                case EPieceSort.kRook:
                    Write((piece.IsWhite ? "R" : "r"));
                    break;
                case EPieceSort.kBishop:
                    Write((piece.IsWhite ? "B" : "b"));
                    break;
                case EPieceSort.kGold:
                    Write((piece.IsWhite ? "G" : "g"));
                    break;
                case EPieceSort.kSilver:
                    Write((piece.IsWhite ? "S" : "s"));
                    break;
                case EPieceSort.kKnight:
                    Write((piece.IsWhite ? "N" : "n"));
                    break;
                case EPieceSort.kLance:
                    Write((piece.IsWhite ? "L" : "l"));
                    break;
                case EPieceSort.kPorn:
                    Write((piece.IsWhite ? "P" : "p"));
                    break;
            }
        }

        private void Write(string s){
            _textWriter.Write(s);
        }
        private void WriteLine(string s){
            _textWriter.WriteLine(s);
        }
        private void RenderHorizontalLine(int count){
            string str = "-";
            for (int i = 1; i < count; i++)
            {
                str += "-";
            }
            WriteLine(str);
        }
    }
}
