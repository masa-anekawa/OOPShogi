using System;
namespace OOPShogi
{
    public enum Color{
        kWhite,
        kBlack
    }

    public class Player
    {
        private Color _color;
        private String _name;

        public String Name{
            get { return _name; }
        }

        public Color Color{
            get { return _color; }
        }

        public Player(Color col, String name)
        {
            _color = col;
            _name = name;
        }
    }
}
