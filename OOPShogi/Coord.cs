using System;
using System.ComponentModel.DataAnnotations;

namespace OOPShogi
{
    public struct Coord
    {
        public readonly int Row, Col;

        public Coord(int r, int c)
        {
            Row = r;
            Col = c;
        }

        public bool IsLessThan(Coord other)
        {
            return this.Row < other.Row && this.Col < other.Col;
        }

        public bool IsGreaterThanOrEqualTo(Coord other){
            return this.Row >= other.Row && this.Col >= other.Col;
        }

        public override String ToString()
        {
            return $"[{this.Row}, {this.Col}]";
        }

        public static int ManhattanDistance(Coord from, Coord to)
        {
            checked
            {
                return Math.Abs(to.Row - from.Row) +
                           Math.Abs(to.Col - from.Col);
            }
        }
        public static int ManhattanDistance(Coord to)
            => ManhattanDistance(Coord.Zero, to);

        public static int EightNeighborDistance(Coord from, Coord to){
            checked
            {
                return Math.Max(Math.Abs(to.Row - from.Row),
                                Math.Abs(to.Col - from.Col));
            }
        }
        public static int EightNeighborDistance(Coord to)
            => EightNeighborDistance(Coord.Zero, to);

        public static readonly Coord Zero = new Coord(0, 0);
        public static readonly Coord UnitRow = new Coord(1, 0);
        public static readonly Coord UnitCol = new Coord(0, 1);

        public override bool Equals(System.Object obj)
        {
            if (obj == null) return false;
            var coord = (Coord)obj;
            if (coord == null) return false;
            else return coord.Row == this.Row && coord.Col == this.Col;
        }
        public bool Equals(Coord other)
        {
            if (other == null) return false;
            else return this.Row == other.Row && this.Col == other.Col;
        }
        public override int GetHashCode()
        {
            return Row ^ Col;
        }
        public static bool operator ==(Coord lhs, Coord rhs) => Equals(lhs, rhs);
        public static bool operator !=(Coord lhs, Coord rhs) => !(lhs == rhs);

        public static Coord operator *(Coord lhs, int rhs)
        {
            return new Coord(lhs.Row * rhs, lhs.Col * rhs);
        }
        public static Coord operator *(int lhs, Coord rhs) => rhs * lhs;

        public static Coord operator +(Coord lhs, Coord rhs)
        {
            return new Coord(lhs.Row + rhs.Row, lhs.Col + rhs.Col);
        }

        public static Coord operator -(Coord lhs, Coord rhs){
            return new Coord(lhs.Row - rhs.Row, lhs.Col - rhs.Col);
        }
        public static Coord operator -(Coord lhs){
            return new Coord(-lhs.Row, -lhs.Col);
        }
    }
}