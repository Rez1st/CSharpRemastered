using System;

namespace Queue
{
    public class ArrayQueue<T>
    {
        private const int FirstMinSize = 8;
        private const int ExpandAndShrinkMultiplier = 2;

        private T[] _array = new T[0];
        private int _headPtr;
        private int _tailPtr;
        public int Count { get; private set; }

        /// <summary>
        ///     First condition is about the case when head pointer is on the same position
        ///     And we just enqueue items enough to fill up the array
        ///     So we checking if tail - is pointing on the last available cell
        /// </summary>
        private bool FirstExpandCondition => _tailPtr == _array.Length - 1 && _headPtr == 0;

        /// <summary>
        ///     Second condition is about the case when we enqueue/dequeue set of items without need to expand
        ///     Then we Enqueue and reach the limt when tailPointer is close to head and sequence contains more that 1 item
        /// </summary>
        private bool SecondExpandCondition => _tailPtr + 1 == _headPtr && Count > 1;

        /// <summary>
        ///     Shrink condition checking if Count is less then  half of the array length - meaning we can shrink it
        /// </summary>
        private bool ShrinkCondition => Count < _array.Length / 2 && _array.Length > FirstMinSize;

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

            if (ShrinkCondition)
                Shrink();
            else
                _headPtr++;
        }

        private void Increment()
        {
            Count++;

            if (FirstExpandCondition || SecondExpandCondition)
                Expand();
            else
                _tailPtr++;

            if (_tailPtr == _array.Length && _headPtr > 0)
                _tailPtr = 0;
        }

        private void Expand()
        {
            var newArr = new T[_array.Length * ExpandAndShrinkMultiplier];

            if (FirstExpandCondition)
                StraightCopy(newArr);
            else
                ReversedCopy(newArr);

            _array = newArr;

            SetBasePosition();
        }

        private void Shrink()
        {
            var newArr = new T[_array.Length / ExpandAndShrinkMultiplier];

            if (_headPtr < _tailPtr)
                StraightCopy(newArr);
            else
                ReversedCopy(newArr);

            _array = newArr;
            SetBasePosition();
        }

        private void StraightCopy(T[] newArr)
        {
            var index = 0;

            for (var i = _headPtr; i < _tailPtr - 1; i++, index++)
                newArr[index] = _array[i+1];
        }

        private void ReversedCopy(T[] newArr)
        {
            for (var i = 0; i < _array.Length; i++)
            {
                if (_headPtr == _array.Length)
                    _headPtr = 0;

                newArr[i] = _array[_headPtr];

                if (_headPtr == _tailPtr)
                    break;

                _headPtr++;
            }
        }

        private void SetBasePosition()
        {
            _headPtr = 0;
            _tailPtr = Count;
        }
    }
}