using System;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

using NUnit.Framework;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class RookTest
    {
        [Test]
        public void OK_RookShouldHaveVerticalControl(
            [Range(-9, 9)] int row,
            [Values(0)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (row == 0 && col == 0) Assert.Ignore("Unnecessary Test. Ommited");
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} shold have control to {new Coord(row, col)}");
        }

        [Test]
        public void OK_RookShouldHaveHorizontalControl(
            [Values(0)] int row,
            [Range(-9, 9)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (row == 0 && col == 0) Assert.Ignore("Unnecessary Test. Ommited");
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} shold have control to {new Coord(row, col)}");
        }

        [Test]
        public void OK_PromotedRookShouldHaveCircularControl(
            [Range(-1, 1)] int row,
            [Range(-1, 1)] int col,
            [Values] bool isWhite)
        {
            if (row == 0 && col == 0) Assert.Ignore("Unnecessary Test. Ommited");
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            piece.Promote();
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} shold have control to {new Coord(row, col)}");
        }

        [TestCase(-1, -1, false)]
        [TestCase(-1, 1, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, 1, false)]
        [TestCase(-1, -1, true)]
        [TestCase(-1, 1, true)]
        [TestCase(1, -1, true)]
        [TestCase(1, 1, true)]
        public void NG_NonPromotedRookShouldNotHaveCircularControl(
            int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} " +
                           "must not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_RookShouldNotHaveControlToTopLeft(
            [Range(-3, -1)] int row,
            [Range(-3, -1)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (doPromote && Coord.EightNeighborDistance(new Coord(row, col)) == 1)
            {
                Assert.Ignore("Unnecessary Test. Ommited");
            }
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} must not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_RookShouldNotHaveControlToTopRight(
            [Range(-3, -1)] int row,
            [Range(1, 3)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (doPromote && Coord.EightNeighborDistance(new Coord(row, col)) == 1)
            {
                Assert.Ignore("Unnecessary Test. Ommited");
            }
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} must not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_RookShouldNotHaveControlToBottomLeft(
            [Range(1, 3)] int row,
            [Range(-3, -1)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (doPromote && Coord.EightNeighborDistance(new Coord(row, col)) == 1)
            {
                Assert.Ignore("Unnecessary Test. Ommited");
            }
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} must not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_RookShouldNotHaveControlToBottomRight(
            [Range(1, 3)] int row,
            [Range(1, 3)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            if (doPromote && Coord.EightNeighborDistance(new Coord(row, col)) == 1)
            {
                Assert.Ignore("Unnecessary Test. Ommited");
            }
            var piece = MakePiece(EPieceSort.kRook, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece.Sort} must not have control to ${new Coord(row, col)}");
        }
    }
}
