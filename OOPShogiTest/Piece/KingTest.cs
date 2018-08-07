using System;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

using NUnit.Framework;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class KingTest
    {
        [TestCase(-1, -1)]
        [TestCase(-1, 0)]
        [TestCase(-1, 1)]
        [TestCase(0, -1)]
        [TestCase(0, 1)]
        [TestCase(1, -1)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void OK_WhiteKingHasControlTo(int row, int col)
        {
            var piece = MakePiece(EPieceSort.kKing, true);
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} shold have control to {new Coord(row, col)}");
        }

        [TestCase(0, 0)]
        [TestCase(-2, -2)]
        [TestCase(-2, -1)]
        [TestCase(-2, 0)]
        [TestCase(-2, 1)]
        [TestCase(-2, 2)]
        [TestCase(-1, -2)]
        [TestCase(-1, 2)]
        [TestCase(0, -2)]
        [TestCase(0, 2)]
        [TestCase(1, -2)]
        [TestCase(1, 2)]
        [TestCase(2, -2)]
        [TestCase(2, -1)]
        [TestCase(2, 0)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        public void NG_WhiteKingDoNotHaveControlTo(int row, int col)
        {
            var piece = MakePiece(EPieceSort.kKing, true);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} must not have control to {new Coord(row, col)}");
        }

        [TestCase(-1, -1)]
        [TestCase(-1, 0)]
        [TestCase(-1, 1)]
        [TestCase(0, -1)]
        [TestCase(0, 1)]
        [TestCase(1, -1)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void OK_BlackKingHasControlTo(int row, int col)
        {
            var piece = MakePiece(EPieceSort.kKing, false);
            Assert.IsTrue(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} shold have control to {new Coord(row, col)}");
        }

        [TestCase(0, 0)]
        [TestCase(-2, -2)]
        [TestCase(-2, -1)]
        [TestCase(-2, 0)]
        [TestCase(-2, 1)]
        [TestCase(-2, 2)]
        [TestCase(-1, -2)]
        [TestCase(-1, 2)]
        [TestCase(0, -2)]
        [TestCase(0, 2)]
        [TestCase(1, -2)]
        [TestCase(1, 2)]
        [TestCase(2, -2)]
        [TestCase(2, -1)]
        [TestCase(2, 0)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        public void NG_BlackKingDoNotHaveControlTo(int row, int col)
        {
            var piece = MakePiece(EPieceSort.kKing, false);
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                          $"{piece.Sort} must not have control to {new Coord(row, col)}");
        }
    }
}
