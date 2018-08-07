using System;
namespace OOPShogi
{
    public class Player
    {
        public bool IsWhite { get; private set; }
        public String Name{ get; private set; }

        public Player(bool isWhite, String name)
        {
            IsWhite = isWhite;
            Name = name;
		}
    }
}
