using System;
using System.Collections;
using System.Collections.Generic;
using LinkedList;

namespace Stack
{
    public class LinkedStack<T> : IEnumerable<T>
    {
        private readonly DataLink<T> _list = new DataLink<T>();

        public int Count => _list.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            _list.Add(item);
        }

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Sequence contain 0 items");

            return _list.CutLast();
        }
    }
}