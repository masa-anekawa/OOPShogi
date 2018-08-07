using System;
using System.ComponentModel.DataAnnotations;

namespace OOPShogi
{
    public struct Coord
    {
        public readonly int row, col;

        public Coord(int r, int c)
        {
            row = r;
            col = c;
        }

        public bool IsWithin(Coord other)
        {
            return this.row <= other.row && this.col <= other.col;
        }

        public override String ToString()
        {
            return $"[{this.row}, {this.col}]";
        }

        public static int ManhattanDistance(Coord from, Coord to)
        {
            return Math.Abs(from.row - to.row)
                       + Math.Abs(from.col - to.col);
        }
        public static int ManhattanDistance(Coord to) => ManhattanDistance(Coord.Zero, to);

        public static readonly Coord Zero = new Coord(0, 0);
        public static readonly Coord UnitRow = new Coord(1, 0);
        public static readonly Coord UnitCol = new Coord(0, 1);

        public override bool Equals(System.Object obj)
        {
            if (obj == null) return false;
            var coord = (Coord)obj;
            if (coord == null) return false;
            else return coord.row == this.row && coord.col == this.col;
        }
        public bool Equals(Coord other)
        {
            if (other == null) return false;
            else return this.row == other.row && this.col == other.col;
        }
        public override int GetHashCode()
        {
            return row ^ col;
        }
        public static bool operator ==(Coord lhs, Coord rhs) => Equals(lhs, rhs);
        public static bool operator !=(Coord lhs, Coord rhs) => !(lhs == rhs);

        public static Coord operator *(Coord lhs, int rhs)
        {
            return new Coord(lhs.row * rhs, lhs.col * rhs);
        }
        public static Coord operator *(int lhs, Coord rhs) => rhs * lhs;

        public static Coord operator +(Coord lhs, Coord rhs)
        {
            return new Coord(lhs.row + rhs.row, lhs.col + rhs.col);
        }
    }
}