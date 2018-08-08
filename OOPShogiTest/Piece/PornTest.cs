using System;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

using NUnit.Framework;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class PornTest
    {
        [Test]
        public void OK_NonPromotedPornHasForwardControl(
            [Values(false, true)] bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kPorn, isWhite);
            Coord expected = new Coord((isWhite ? -1 : 1), 0);
            Assert.IsTrue(piece.HasControlTo(expected),
                          $"{piece} shold have control to {expected}");
        }

        [TestCase(-1, -1, true)]
        [TestCase(-1, 1, true)]
        [TestCase(0, -1, true)]
        [TestCase(0, 0, true)]
        [TestCase(0, 1, true)]
        [TestCase(1, -1, true)]
        [TestCase(1, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(-1, -1, false)]
        [TestCase(-1, 0, false)]
        [TestCase(-1, 1, false)]
        [TestCase(0, -1, false)]
        [TestCase(0, 0, false)]
        [TestCase(0, 1, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, 1, false)]
        public void NG_NonPromotedPornHasForwardControl(
            int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kPorn, isWhite);
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
        public void OK_PromotedPornHasGoldControl(int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kPorn, isWhite);
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
        public void NG_PromotedPornHasGoldControl(int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kPorn, isWhite);
            piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }
    }
}
