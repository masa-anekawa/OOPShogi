using System;
using System.IO;

using static System.Console;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class TextCommander: ICommander
    {
        private TextReader _textReader;

        public TextCommander(TextReader reader){
            _textReader = reader;
        }
        public Command AskCommand(bool white){
            Command command = null;
            // TODO: Move発行，承認，移動までの流れ
            Write($"Command? (pass/surrender):");
            while (true)
            {
                string str = _textReader.ReadLine();
                command = GenerateCommand(str, white);
                if(command == null)
                {
                    // TODO: output design
                    WriteLine("invalid command. try again.");
                    continue;
                }
                else 
                    break;
            }
            return command;
        }

        private Command GenerateCommand(string str, bool white)
        {
            if (str == "surrender")
                // FIXME: TextCommanderを使うのは先手か後手か？
                return new Command(ECommandSort.kSurrender, white);
            else if (str == "pass")
                return new Command(ECommandSort.kPass, white);
            else
                return null;
        }
    }
}