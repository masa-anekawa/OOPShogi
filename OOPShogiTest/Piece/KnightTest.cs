using System;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

using NUnit.Framework;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class KnightTest
    {
        [TestCase(-2, -1, true)]
        [TestCase(-2, 1, true)]
        [TestCase(2, -1, false)]
        [TestCase(2, 1, false)]
        public void OK_NonPromotedKnightShouldHaveLControl(
            int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kKnight, isWhite);
            Coord expected = new Coord(row, col);
            Assert.IsTrue(piece.HasControlTo(expected),
                          $"{piece} shold have control to {expected}");
        }

        [Test]
        public void NG_NonPromotedKnightShouldNotHaveNearControl(
            [Range(-1, 1)]int row,
            [Range(-1, 1)]int col,
            [Values] bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kKnight, isWhite);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [TestCase(-2, -2, true)]
        [TestCase(-2, 0, true)]
        [TestCase(-2, 2, true)]
        [TestCase(-1, -2, true)]
        [TestCase(-1, 2, true)]
        [TestCase(0, -2, true)]
        [TestCase(0, 2, true)]
        [TestCase(1, -2, true)]
        [TestCase(1, 2, true)]
        [TestCase(2, -2, true)]
        [TestCase(2, -1, true)]
        [TestCase(2, 0, true)]
        [TestCase(2, 1, true)]
        [TestCase(2, 2, true)]
        [TestCase(-2, -2, false)]
        [TestCase(-2, -1, false)]
        [TestCase(-2, 0, false)]
        [TestCase(-2, 1, false)]
        [TestCase(-2, 2, false)]
        [TestCase(-1, -2, false)]
        [TestCase(-1, 2, false)]
        [TestCase(0, -2, false)]
        [TestCase(0, 2, false)]
        [TestCase(1, -2, false)]
        [TestCase(1, 2, false)]
        [TestCase(2, -2, false)]
        [TestCase(2, 0, false)]
        [TestCase(2, 2, false)]
        public void NG_NonPromotedKnightShouldHaveLControl(
            int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kKnight, isWhite);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [TestCase(-1, -1, true)]
        [TestCase(-1, 0, true)]
        [TestCase(-1, 1, true)]
        [TestCase(0, -1, true)]
        [TestCase(0, 1, true)]
        [TestCase(1, 0, true)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, 1, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, 0, false)]
        [TestCase(1, 1, false)]
        public void OK_PromotedKnightShouldHaveGoldControl(int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kKnight, isWhite);
            piece.Promote();
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
            $"{piece} should have control to ${new Coord(row, col)}");
        }

        [TestCase(-2, -2, true)]
        [TestCase(-2, -1, true)]
        [TestCase(-2, 0, true)]
        [TestCase(-2, 1, true)]
        [TestCase(-2, -2, true)]
        [TestCase(-1, -2, true)]
        [TestCase(-1, 2, true)]
        [TestCase(0, -2, true)]
        [TestCase(0, 2, true)]
        [TestCase(1, -2, true)]
        [TestCase(1, -1, true)]
        [TestCase(1, 1, true)]
        [TestCase(1, 2, true)]
        [TestCase(2, -2, true)]
        [TestCase(2, -1, true)]
        [TestCase(2, 0, true)]
        [TestCase(2, 1, true)]
        [TestCase(2, -2, true)]
        [TestCase(-2, -2, false)]
        [TestCase(-2, -1, false)]
        [TestCase(-2, 0, false)]
        [TestCase(-2, 1, false)]
        [TestCase(-2, -2, false)]
        [TestCase(-1, -2, false)]
        [TestCase(-1, -1, false)]
        [TestCase(-1, 1, false)]
        [TestCase(-1, 2, false)]
        [TestCase(0, -2, false)]
        [TestCase(0, 2, false)]
        [TestCase(1, -2, false)]
        [TestCase(1, 2, false)]
        [TestCase(2, -2, false)]
        [TestCase(2, -1, false)]
        [TestCase(2, 0, false)]
        [TestCase(2, 1, false)]
        [TestCase(2, -2, false)]
        public void NG_PromotedKnightShouldHaveGoldControl(int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kKnight, isWhite);
            piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }
    }
}
