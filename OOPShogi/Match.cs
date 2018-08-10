using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OOPShogi.Piece;

namespace OOPShogi
{
    class Match : IPosition
    {
        public Board Board { get; }
        public Pool WhitePool { get; }
        public Pool BlackPool { get; }
        //FIXME: Turnオブジェクトを手番表示だけに使うか，かかった時間や着手時刻を記録する要素として使うか
        public Turn Turn { get; }

        public Player WhitePlayer { get; }
        public Player BlackPlayer { get; }

        public Player Winner{
            get
            {
                if (!IsMatchOver())
                    return null;
                else
                {
                    // assert that a match is always done by surrender at last
                    if (History.LastEvent.Value.Command.White)
                        return BlackPlayer;
                    else
                        return WhitePlayer;

                }
            }
        }

        //private Judge _judge;
        public History History { get; }

        private IRenderer _textRenderer;
        private ICommander _textCommander;

        public Match(Player white, Player black){
            Board = new Board(new Coord(9, 9));
            WhitePool = new Pool(true);
            BlackPool = new Pool(false);
            Turn = new Turn();

            WhitePlayer = white;
            BlackPlayer = black;

            History = new History();

            _textRenderer = new TextRenderer(Console.Out);
            _textCommander = new TextCommander(Console.In);
        }

        public Board GetBoard() => Board;
        public Turn GetTurn() => Turn;

        public Pool GetPool(bool isWhite)
        => (isWhite ? WhitePool : BlackPool);

        public Pool GetPool(Turn turn)
        => GetPool(turn.White);
        
        public Player GetPlayer(bool isWhite) 
        => (isWhite ? WhitePlayer : BlackPlayer);

        public Player GetPlayer(Turn turn)
        => GetPlayer(turn.White);

        public void Init()
        {
            Console.WriteLine("Shogi#Init() called");
            // TODO: 誰がPieceをNewするのか？誰がPieceインスタンスを管理するのか？Pieceインスタンスの総数は固定したい
            BPiece gold = PieceFactory.MakePiece(EPieceSort.kGold, true);
            BPiece king = PieceFactory.MakePiece(EPieceSort.kKing, false);
            Board.Drop(gold, new Coord(8, 4));
            Board.Drop(king, new Coord(0, 4));
            Turn.Switch();
        }

        public void StartMatch()
        {
            Console.WriteLine("Shogi#StartMatch() called");
            MainLoop();
            ShowResult();
        }

        private void MainLoop(){
            while (!this.IsMatchOver())
            {
                _textRenderer.RenderPosition(this);
                Command command;
                command = this.AskCommand();
                Console.WriteLine($"{GetPlayer(Turn).Name} command: {command}");
                History.Add(new HistoryEvent(command));
                Turn.Switch();
            }
        }

        private bool IsMatchOver(){
            // TODO: introduce Judge
            if (!History.LastEvent.HasValue)
                return false;
            else
                return History.LastEvent.Value.Command.Sort == ECommandSort.kSurrender;
        }

        private Command AskCommand(){
            if (GetPlayer(Turn).IsHuman)
            {
                return _textCommander.AskCommand(Turn.White);
            }
            else
            {
                // TODO: implement AI
                return new Command(ECommandSort.kPass, false);
            }
        }

        private void ShowResult(){
            Console.WriteLine($"{Winner} won!");
        }
    }
}
