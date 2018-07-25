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
            Shogi shogi = new Shogi();
            shogi.Init();
            shogi.StartMatch();

            Console.Read();
        }
    }
}
