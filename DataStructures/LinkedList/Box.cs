namespace LinkedList
{
    public class Box<T>
    {
        public Box(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Box<T> NextBox { get; set; }

        public Box<T> PrevBox { get; set; }
    }
}