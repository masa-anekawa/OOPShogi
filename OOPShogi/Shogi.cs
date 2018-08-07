using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OOPShogi.Piece;

namespace OOPShogi
{
    class Shogi
    {
        private Board _board;
        private TextRenderer _textRenderer;
        public Shogi(){
            _board = new Board(new Coord(9, 9));
            _textRenderer = new TextRenderer(Console.Out);
        }
        public void Init()
        {
            Console.WriteLine("Shogi.Init called");
            BPiece gold = PieceFactory.MakePiece(EPieceSort.kGold, true);
            BPiece king = PieceFactory.MakePiece(EPieceSort.kKing, false);
            _board.SetPiece(gold, new Coord(1, 4));
            _board.SetPiece(king, new Coord(0, 4));
        }

        public void StartMatch()
        {
            _textRenderer.RenderBoard(_board);
            Console.WriteLine("You Won!");
        }
    }
}
