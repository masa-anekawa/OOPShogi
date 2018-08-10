using System;
using System.Collections;
using System.Collections.Generic;

using OOPShogi.Piece;

namespace OOPShogi
{
    public class History: IList<HistoryEvent>
    {
        private IList<HistoryEvent> _events;

        public History(){
            _events = new List<HistoryEvent>();
        }

        public HistoryEvent this[int index]
        { 
            get => _events[index];
            set => _events[index] = value;
        }

        public HistoryEvent? LastEvent
        {
            get{
                if (Count == 0)
                    return null;
                else
                    return this[Count - 1];
            }
        }

        public int Count => _events.Count;

        public bool IsReadOnly => _events.IsReadOnly;

        public override string ToString()
        {
            String ret = $"[History: Count = {Count}, Events:\n";
            foreach(var e in _events){
                ret += "\t" + e + "\n";
            }
            ret += "]";

            return ret;
        }

        public void Add(HistoryEvent item)
        {
            _events.Add(item);
        }

        public void Clear()
        {
            _events.Clear();
        }

        public bool Contains(HistoryEvent item)
        {
            return _events.Contains(item);
        }

        public void CopyTo(HistoryEvent[] array, int arrayIndex)
        {
            _events.CopyTo(array, arrayIndex);
        }

        public IEnumerator<HistoryEvent> GetEnumerator()
        {
            return _events.GetEnumerator();
        }

        public int IndexOf(HistoryEvent item)
        {
            return _events.IndexOf(item);
        }

        public void Insert(int index, HistoryEvent item)
        {
            _events.Insert(index, item);
        }

        public bool Remove(HistoryEvent item)
        {
            return _events.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _events.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _events.GetEnumerator();
        }
    }
}