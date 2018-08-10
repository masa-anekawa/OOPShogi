using System;
namespace OOPShogi
{
    public class Player
    {
        public String Name{ get; }
        public bool IsHuman { get; }

        public Player(String _name, bool _isHuman)
        {
            Name = _name;
            IsHuman = _isHuman;
		}
    }
}
