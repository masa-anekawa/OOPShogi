using System;
using System.Collections;
using System.Collections.Generic;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class Pool : ICollection<BPiece>
    {
        public bool IsWhite { get; private set; }

        public int Count => _pieces.Count;

        public bool IsReadOnly => _pieces.IsReadOnly;

        private ICollection<BPiece> _pieces;

        public Pool(bool isWhite)
        {
            _pieces = new List<BPiece>();
            IsWhite = isWhite;
        }

        public override string ToString()
        {
            return $"[Pool: {(IsWhite ? "White" : "Black")} with count {Count}]";
        }

        public void Add(BPiece item)
        {
            _pieces.Add(item);
        }

        public void Clear()
        {
            _pieces.Clear();
        }

        public bool Contains(BPiece item)
        {
            return _pieces.Contains(item);
        }

        public void CopyTo(BPiece[] array, int arrayIndex)
        {
            _pieces.CopyTo(array, arrayIndex);
        }

        public bool Remove(BPiece item)
        {
            return _pieces.Remove(item);
        }

        public IEnumerator<BPiece> GetEnumerator()
        {
            return _pieces.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _pieces.GetEnumerator();
        }
    }
}
