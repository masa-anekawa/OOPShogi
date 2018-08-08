using System;
using NUnit.Framework;

using OOPShogi;
using OOPShogi.Piece;
using static OOPShogi.Piece.PieceFactory;

namespace OOPShogiTest.Piece
{
    [TestFixture]
    public class BPieceTest
    {
        [TestCase(EPieceSort.kRook)]
        [TestCase(EPieceSort.kBishop)]
        [TestCase(EPieceSort.kSilver)]
        [TestCase(EPieceSort.kKnight)]
        [TestCase(EPieceSort.kLance)]
        [TestCase(EPieceSort.kPorn)]
        public void OK_ShouldPromote(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsTrue(piece.CanPromote(), $"{sort} should promote");
        }

        [TestCase(EPieceSort.kKing)]
        [TestCase(EPieceSort.kGold)]
        public void NG_ShouldNotPromote(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsFalse(piece.CanPromote(), $"{sort} must not promote");
        }

        [TestCase(EPieceSort.kRook)]
        [TestCase(EPieceSort.kBishop)]
        [TestCase(EPieceSort.kSilver)]
        [TestCase(EPieceSort.kKnight)]
        [TestCase(EPieceSort.kLance)]
        [TestCase(EPieceSort.kPorn)]
        public void NG_ShouldNotPromoteTwice(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            piece.Promote();
            Assert.IsFalse(piece.CanPromote(), $"{sort} must not promote twice");
        }

        [TestCase(EPieceSort.kKnight)]
        public void OK_ShouldJump(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsTrue(piece.CanJump(), $"{sort} should jump");
        }

        [TestCase(EPieceSort.kKing)]
        [TestCase(EPieceSort.kRook)]
        [TestCase(EPieceSort.kBishop)]
        [TestCase(EPieceSort.kGold)]
        [TestCase(EPieceSort.kSilver)]
        [TestCase(EPieceSort.kLance)]
        [TestCase(EPieceSort.kPorn)]
        public void NG_ShouldNotJump(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsFalse(piece.CanJump(), $"{sort} must not jump");
        }

        [TestCase(EPieceSort.kKing, true)]
        [TestCase(EPieceSort.kRook, true)]
        [TestCase(EPieceSort.kBishop, true)]
        [TestCase(EPieceSort.kGold, true)]
        [TestCase(EPieceSort.kSilver, true)]
        [TestCase(EPieceSort.kLance, true)]
        [TestCase(EPieceSort.kPorn, true)]
        [TestCase(EPieceSort.kKing, false)]
        [TestCase(EPieceSort.kRook, false)]
        [TestCase(EPieceSort.kBishop, false)]
        [TestCase(EPieceSort.kGold, false)]
        [TestCase(EPieceSort.kSilver, false)]
        [TestCase(EPieceSort.kLance, false)]
        [TestCase(EPieceSort.kPorn, false)]
        public void NG_AnyNonPromotedPieceShouldNotHaveControlToItself(
            EPieceSort sort, bool isWhite)
        {
            BPiece piece = MakePiece(sort, isWhite);
            Assert.IsFalse(piece.HasControlTo(Coord.Zero),
                           $"{piece} should not have control to itself");
        }

        [TestCase(EPieceSort.kRook, true)]
        [TestCase(EPieceSort.kBishop, true)]
        [TestCase(EPieceSort.kSilver, true)]
        [TestCase(EPieceSort.kLance, true)]
        [TestCase(EPieceSort.kPorn, true)]
        [TestCase(EPieceSort.kRook, false)]
        [TestCase(EPieceSort.kBishop, false)]
        [TestCase(EPieceSort.kSilver, false)]
        [TestCase(EPieceSort.kLance, false)]
        [TestCase(EPieceSort.kPorn, false)]
        public void NG_AnyPromotedPieceShouldNotHaveControlToItself(
            EPieceSort sort, bool isWhite)
        {
            BPiece piece = MakePiece(sort, isWhite);
            piece.Promote();
            Assert.IsFalse(piece.HasControlTo(Coord.Zero),
                           $"{piece} should not have control to itself");
        }

        [Test]
        public void NG_SomePiecesShouldNotHaveFarControl_Top(
            [Values(
                EPieceSort.kPorn,
                EPieceSort.kSilver,
                EPieceSort.kGold,
                EPieceSort.kKing)] EPieceSort sort,
            [Range(-3, -2)]int row,
            [Range(-3, 3)]int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            var piece = MakePiece(sort, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_SomePiecesShouldNotHaveFarControl_Bottom(
            [Values(
                EPieceSort.kPorn,
                EPieceSort.kSilver,
                EPieceSort.kGold,
                EPieceSort.kKing)] EPieceSort sort,
            [Range(2, 3)]int row,
            [Range(-3, 3)]int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            var piece = MakePiece(sort, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_SomePiecesShouldNotHaveFarControl_Left(
            [Values(
                EPieceSort.kPorn,
                EPieceSort.kSilver,
                EPieceSort.kGold,
                EPieceSort.kKing)] EPieceSort sort,
            [Range(-1, 1)]int row,
            [Range(-3, -2)]int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            var piece = MakePiece(sort, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void NG_SomePiecesShouldNotHaveFarControl_Right(
            [Values(
                EPieceSort.kPorn,
                EPieceSort.kSilver,
                EPieceSort.kGold,
                EPieceSort.kKing)] EPieceSort sort,
            [Range(-1, 1)] int row,
            [Range(2, 3)] int col,
            [Values] bool isWhite,
            [Values] bool doPromote)
        {
            var piece = MakePiece(sort, isWhite);
            if (doPromote) piece.Promote();
            Assert.IsFalse(piece.HasControlTo(new Coord(row, col)),
                           $"{piece} should not have control to ${new Coord(row, col)}");
        }

        [Test]
        public void OK_EveryPieceShouldBeNonPromotedAtFirst(
            [Values] EPieceSort sort,
            [Values] bool isWhtie
        )
        {
            BPiece piece = MakePiece(sort, isWhtie);
            Assert.IsFalse(piece.IsPromoted, "Every piece should not be non-promoted at first");
        }
    }
}
