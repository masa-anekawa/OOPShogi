using System;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

using NUnit.Framework;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class LanceTest
    {
        [Test]
        public void OK_NonPromotedWhiteLanceShouldHaveStraightControl(
            [Range(-9, -1)]int row)
        {
            var piece = MakePiece(EPieceSort.kLance, true);
            Coord coord = new Coord(row, 0);
            Assert.IsTrue(piece.HasControlTo(coord),
                          $"{piece} shold have control to {coord}");
        }
        [Test]
        public void OK_NonPromotedBlackLanceShouldHaveStraightControl(
            [Range(1, 9)]int row)
        {
            var piece = MakePiece(EPieceSort.kLance, false);
            Coord coord = new Coord(row, 0);
            Assert.IsTrue(piece.HasControlTo(coord),
                          $"{piece} shold have control to {coord}");
        }

        [Test]
        public void NG_NonPromotedWhiteLanceShouldNotHaveBackwardControl(
            [Range(3, 1)]int row,
            [Range(-3, 3)]int col)
        {
            var piece = MakePiece(EPieceSort.kLance, true);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_NonPromotedWhiteLanceShouldNotHaveLeftControl(
            [Range(-3, 0)]int row,
            [Range(-3, -1)]int col)
        {
            var piece = MakePiece(EPieceSort.kLance, true);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_NonPromotedWhiteLanceShouldNotHaveRightControl(
            [Range(-3, 0)]int row,
            [Range(1, 3)]int col)
        {
            var piece = MakePiece(EPieceSort.kLance, true);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }


        [Test]
        public void NG_NonPromotedBlackLanceShouldNotHaveBackwardControl(
            [Range(-3, -1)]int row,
            [Range(-3, 3)]int col)
        {
            var piece = MakePiece(EPieceSort.kLance, false);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_NonPromotedBlackLanceShouldNotHaveLeftControl(
            [Range(0, 3)]int row,
            [Range(-3, -1)]int col)
        {
            var piece = MakePiece(EPieceSort.kLance, false);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_NonPromotedBlackLanceShouldNotHaveRightControl(
            [Range(0, 3)]int row,
            [Range(1, 3)]int col)
        {
            var piece = MakePiece(EPieceSort.kLance, false);
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
        public void OK_PromotedLanceShouldHaveGoldControl(int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kLance, isWhite);
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
        public void NG_PromotedLanceShouldHaveGoldControl(int row, int col, bool isWhite)
        {
            var piece = MakePiece(EPieceSort.kLance, isWhite);
            piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }
    }
}
