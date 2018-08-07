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
        public void OK_CanPromote(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsTrue(piece.CanPromote(), $"{sort} must be able to promote");
        }

        [TestCase(EPieceSort.kKing)]
        [TestCase(EPieceSort.kGold)]
        public void NG_CannotPromote(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsFalse(piece.CanPromote(), $"{sort} must be unable to promote");
        }

        [TestCase(EPieceSort.kRook)]
        [TestCase(EPieceSort.kBishop)]
        [TestCase(EPieceSort.kSilver)]
        [TestCase(EPieceSort.kKnight)]
        [TestCase(EPieceSort.kLance)]
        [TestCase(EPieceSort.kPorn)]
        public void NG_CannotPromoteTwice(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            piece.Promote();
            Assert.IsFalse(piece.CanPromote(), $"{sort} must not promote twice");
        }

        [TestCase(EPieceSort.kKnight)]
        public void OK_CanJump(EPieceSort sort)
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
        public void NG_CannotJump(EPieceSort sort)
        {
            BPiece piece = MakePiece(sort, true);
            Assert.IsFalse(piece.CanJump(), $"{sort} must not jump");
        }
    }
}
