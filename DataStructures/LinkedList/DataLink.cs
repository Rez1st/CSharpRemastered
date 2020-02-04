using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class DataLink<T> : ICollection<T>
    {
        private Box<T> Head { get; set; }

        private Box<T> Tail { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            var box = new Box<T>(item);
            Count++;

            if (Head == null)
            {
                Head = box;
                Tail = box;

                return;
            }

            Tail.NextBox = box;
            box.PrevBox = Tail;
            Tail = box;
        }

        public T CutLast()
        {
            T val = Tail.Data;

            if (Tail.PrevBox == null)
            {
                Clear();
                return val;
            }

            Tail.PrevBox.NextBox = null;
            Tail = Tail.PrevBox;

            Count--;
            return val;
        }

        public T CutFirst()
        {
            if (Head == null)
                throw new InvalidOperationException($"Sequence is empty");

            T data = Head.Data;

            if (Head.NextBox != null)
            {
                Head.NextBox.PrevBox = null;
                Head = Head.NextBox;
            }
            else
            {
                Head = null;
            }

            Count--;

            return data;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Head == null)
                throw new InvalidOperationException("Sequence contains 0 elements");

            var currentBox = Head;

            do
            {
                yield return currentBox.Data;

                currentBox = currentBox.NextBox;
            } while (currentBox != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}