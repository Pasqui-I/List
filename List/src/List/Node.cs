namespace List.src.List
{
    public interface INode<T>
    {

        public T Value { get; set; }

        public bool Equals(INode<T> OtherNode);
        public string ToString();
    }
}