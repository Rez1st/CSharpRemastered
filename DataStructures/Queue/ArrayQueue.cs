using System;

namespace Queue
{
    public class ArrayQueue<T>
    {
        private const int FirstMinSize = 8;
        public int Count { get; private set; }
        private T[] _array = new T[0];
        private int _headPtr;
        private int _tailPtr;

        public void Enqueue(T item)
        {
            if (_array.Length == 0)
                _array = new T[FirstMinSize];

            _array[_tailPtr] = item;

            Increment();
        }

        public T Dequeue()
        {
            if (_headPtr == _tailPtr)
                throw new InvalidOperationException("Sequence is empty");

            var item = _array[_headPtr];

            Decrement();

            return item;
        }

        private void Decrement()
        {
            Count--;
            _headPtr++;
        }

        private void Increment()
        {
            Count++;
            _tailPtr++;
        }
    }
}