using System;
using LinkedList;

namespace Queue
{
    public class LinkedQueue<T>
    {
        public int Count => _linkedList.Count;

        private readonly DataLink<T> _linkedList = new DataLink<T>();

        public void Enqueue(T item)
        {
            _linkedList.Add(item);
        }

        public T Dequeue()
        {
            if (Count < 1)
                throw new InvalidOperationException($"Sequence contains 0 items");

            return _linkedList.CutFirst();
        }
    }
}