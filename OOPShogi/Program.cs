using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPShogi
{
    class Program
    {
        static void Main(string[] args)
        {
            Player you = new Player("Masa", true);
            Player ai = new Player("Ponanza", false);
            Match match = new Match(you, ai);
            match.Init();
            match.StartMatch();

            Console.Read();
        }
    }
}
