using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OOPShogi.Piece;

namespace OOPShogi
{
    class Shogi : IPosition
    {
        private Board _board;
        private Pool _poolWhite, _poolBlack;
        private Turn _turn;

        private TextRenderer _textRenderer;
        private TextCommander _textCommander;

        public Shogi(){
            _board = new Board(new Coord(9, 9));
            _poolWhite = new Pool(true);
            _poolBlack = new Pool(false);
            _turn = new Turn();

            _textRenderer = new TextRenderer(Console.Out);
            _textCommander = new TextCommander(Console.In);
        }

        public Board GetBoard()
        => _board;

        public Pool GetPool(bool isWhite)
        => (isWhite ? _poolWhite : _poolBlack);

        public Turn GetTurn()
        => _turn;

        public void Init()
        {
            Console.WriteLine("Shogi.Init called");
            // TODO: 誰がPieceをNewするのか？誰がPieceインスタンスを管理するのか？Pieceインスタンスの総数は固定したい
            BPiece gold = PieceFactory.MakePiece(EPieceSort.kGold, true);
            BPiece king = PieceFactory.MakePiece(EPieceSort.kKing, false);
            _board.Drop(gold, new Coord(1, 4));
            _board.Drop(king, new Coord(0, 4));
            _turn.Switch();
        }

        public void StartMatch()
        {
            _textRenderer.RenderPosition(this);
            Command command;
            if (GetTurn().IsWhite)
            {
                command = _textCommander.AskCommand();
                Console.WriteLine($"Your command: {command}");
            }
            else
            {
                command = new Command(ECommandSort.kSurrender);
                Console.WriteLine($"AI's command: {command}");
            }
            Console.WriteLine("You Won!");
        }
    }
}
