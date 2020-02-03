using System;

namespace Stack
{
    public class ArrayStack<T>
    {
        public int Count => _array.Length - _pointer - 1;

        private const int FirstMinSize = 8;
        private const int OutOfSpaceMultiplier = 2;
        private int _pointer;
        private T[] _array = new T[0];

        public void Push(T item)
        {
            // scenario with 0 size
            if (_array.Length == 0)
            {
                _array = new T[FirstMinSize];
                _pointer = _array.Length - 1;
            }

            // scenario with filled array
            if (_pointer == 0)
            {
                // fill-up the array with the income value
                _array[_pointer] = item;

                // create new sized array
                var tempArray = new T[_array.Length * OutOfSpaceMultiplier];

                // copy previous items to new array(the last part)
                _array.CopyTo(tempArray, tempArray.Length - _array.Length);

                // set pointer to correct spot
                _pointer = tempArray.Length - _array.Length -1;

                // switching arrays
                _array = tempArray;
            }
            else
            {
                _array[_pointer] = item;
                _pointer--;
            }
        }

        public T Pop()
        {
            if (_pointer == 0 || _pointer == _array.Length)
                throw new InvalidOperationException("Sequence contains 0 items");

            _pointer++;

            var value = _array[_pointer];

            if (_pointer > _array.Length / 2 && _array.Length > FirstMinSize)
                Defragmentation();

            return value;
        }

        private void Defragmentation()
        {
            var tempArray = new T[_array.Length / OutOfSpaceMultiplier];

            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                tempArray[tempArray.Length - 1 - i] = _array[_array.Length - 1 - i];
            }

            _pointer = 1;

            _array = tempArray;
        }
    }
}