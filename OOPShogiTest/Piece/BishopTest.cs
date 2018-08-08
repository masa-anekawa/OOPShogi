using System;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

using NUnit.Framework;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class BishopTest
    {
        [Test]
        public void OK_NonPromotedBishopShouldHaveDiagonalControl(
            [Range(-9, 9)] int row,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (row == 0) Assert.Ignore("Unnecessary Test. Ommited");
            var piece = MakePiece(EPieceSort.kBishop, isWhite);
            if (doPromote) piece.Promote();
            Coord expected1 = new Coord(row, row);
            Coord expected2 = new Coord(row, -row);
            Assert.IsTrue(piece.HasControlTo(expected1),
                          $"{piece} shold have control to {expected1}");
            Assert.IsTrue(piece.HasControlTo(expected2),
                          $"{piece} shold have control to {expected2}");
        }

        [Test]
        public void OK_PromotedBishopShouldHaveCircularControl(
            [Range(-1, 1)] int row,
            [Range(-1, 1)] int col,
            [Values] bool isWhite)
        {
            if (row == 0 && col == 0) Assert.Ignore("Unnecessary Test. Ommited");
            var piece = MakePiece(EPieceSort.kBishop, isWhite);
            piece.Promote();
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} shold have control to {new Coord(row, col)}");
        }

        [TestCase(-1, 0, true)]
        [TestCase(0, -1, true)]
        [TestCase(0, 1, true)]
        [TestCase(1, 0, true)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, 1, false)]
        [TestCase(1, 0, false)]
        public void NG_NonPromotedBishopShouldNotHaveCircularControl(
            int row, int col, bool isWhite)
        {
            if (row == 0 && col == 0) Assert.Ignore("Unnecessary Test. Ommited");
            var piece = MakePiece(EPieceSort.kBishop, isWhite);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} must not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_BishopShouldNotHaveNonDiagonalControl(
            [Range(-3, 3)] int row,
            [Range(-3, 3)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (Math.Abs(row) == Math.Abs(col) ||
                (doPromote && Coord.EightNeighborDistance(new Coord(row, col)) == 1))
            {
                Assert.Ignore("Unnecessary Test. Ommited");
            }
            var piece = MakePiece(EPieceSort.kBishop, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} must not have control to ${new Coord(row, col)}");
        }
    }
}
