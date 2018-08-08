using System;

using NUnit.Framework;
using OOPShogi;

namespace OOPShogiTest
{
    [TestFixture]
    public class CoordTest
    {
        [Test, Pairwise]
        public void OK_IsLessThan_Normal(
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int row1,
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int col1,
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int row2,
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int col2)
        {
            Coord c1 = new Coord(row1, col1);
            Coord c2 = new Coord(row2, col2);
            Assert.AreEqual(row1 < row2 && col1 < col2,
                          c1.IsLessThan(c2),
                            "Coord#IsLessThan() intends to check that " +
                            "both row and col are smaller than those of the parameter.");
        }

        [Test, Pairwise]
        public void OK_IsGreaterThanOrEqualTo(
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int row1,
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int col1,
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int row2,
            [Values(int.MinValue, -9, -1, 0, 1, 9, int.MaxValue)] int col2)
        {
            Coord c1 = new Coord(row1, col1);
            Coord c2 = new Coord(row2, col2);
            Assert.AreEqual(row1 >= row2 && col1 >= col2,
                            c1.IsGreaterThanOrEqualTo(c2),
                            "Coord#IsGreaterThanOrEqualTo() intends to check that " +
                            "both row and col are greater than or equal to those of the parameter.");
        }

        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 3, 9, ExpectedResult = 12)]
        [TestCase(0, 0, 100, -1, ExpectedResult = 101)]
        [TestCase(0, 0, -42, 7, ExpectedResult = 49)]
        [TestCase(5, 12, -42, 7, ExpectedResult = 52)]
        [TestCase(-12, -7, -42, 7, ExpectedResult = 44)]
        [TestCase(-121231232, 9, -42, 71232323, ExpectedResult = 192463504)]
        public int OK_ManhattanDistance(
            int row1, int col1, int row2, int col2)
        {
            Coord c1 = new Coord(row1, col1);
            Coord c2 = new Coord(row2, col2);
            return Coord.ManhattanDistance(c1, c2);
        }

        [Test]
        public void NG_Math_Abs_ShouldThrowOverflowException(){
            Assert.Throws(typeof(OverflowException), () =>
            {
                Math.Abs(int.MinValue);
            });
        }
        [Test]
        public void NG_PlusOperator_ShouldThrowOverflowException_WithChecked(){
            Assert.Throws(typeof(OverflowException), () =>
            {
                checked
                {
                    int x = int.MaxValue;
                    int y = int.MaxValue;
                    int z = x + y;
                    Console.WriteLine(z);
                }
            });
        }

        [TestCase(int.MaxValue, int.MaxValue, 0, 0)]
        [TestCase(0, 0, int.MaxValue, int.MaxValue)]
        [TestCase(0, 0, int.MinValue, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue, 0, 0)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue)]
        public void NG_ManhattanDistance_ShouldThrowOverFlowException(
            int row1, int col1, int row2, int col2)
        {
            Coord c1 = new Coord(row1, col1);
            Coord c2 = new Coord(row2, col2);
            Assert.Throws(typeof(OverflowException), () => {
                Console.WriteLine(
                    $"Coord.ManhattanDistance({c1}, {c2} = {Coord.ManhattanDistance(c1, c2)}");
            });
        }

        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 3, 9, ExpectedResult = 9)]
        [TestCase(0, 0, 100, -1, ExpectedResult = 100)]
        [TestCase(0, 0, -42, 7, ExpectedResult = 42)]
        [TestCase(5, 12, -42, 7, ExpectedResult = 47)]
        [TestCase(-12, -7, -42, 7, ExpectedResult = 30)]
        [TestCase(-121231232, 9, -42, 71232323, ExpectedResult = 121231190)]
        [TestCase(0, 0, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int OK_EightNeighborDistance(
            int row1, int col1, int row2, int col2)
        {
            Coord c1 = new Coord(row1, col1);
            Coord c2 = new Coord(row2, col2);
            return Coord.EightNeighborDistance(c1, c2);
        }

        [TestCase(int.MaxValue, int.MaxValue, -1, 1)]
        [TestCase(0, -1, int.MaxValue, int.MaxValue)]
        [TestCase(0, 0, int.MinValue, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue, 2, 123)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue)]
        public void NG_EightNeighborDistance_ShouldThrowOverFlowException(
            int row1, int col1, int row2, int col2)
        {
            Coord c1 = new Coord(row1, col1);
            Coord c2 = new Coord(row2, col2);
            Assert.Throws(typeof(OverflowException), () => {
                Console.WriteLine(
                    $"Coord.ManhattanDistance({c1}, {c2} = {Coord.EightNeighborDistance(c1, c2)}");
            });
        }
    }
}
