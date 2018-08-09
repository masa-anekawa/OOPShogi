using System;
using System.IO;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class TextCommander
    {
        private TextReader _textReader;

        public TextCommander(TextReader reader){
            _textReader = reader;
        }
        public Command AskCommand(){
            Command command = null;
            Console.WriteLine($"Command? ");
            while (true)
            {
                string str = _textReader.ReadLine();
                command = GenerateCommand(str);
                if(command == null)
                {
                    // TODO: output design
                    Console.WriteLine("invalid command. try again.");
                    continue;
                }
                else 
                    break;
            }
            return command;
        }

        private Command GenerateCommand(string str)
        {
            if (str == "surrender")
                return new Command(ECommandSort.kSurrender);
            else
                return null;
        }
    }
}