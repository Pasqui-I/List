using List.src.List;

namespace List.src.LinkedList
{
    public class LinkedListNode<T>(T Value) : INode<T>
    {
        private T value = Value;
        private LinkedListNode<T>? next = null;

        public T Value { get => value; set => this.value = value; }
        public LinkedListNode<T>? Next { get => next; set => next = value; }
        public bool Equals(INode<T> OtherNode)
        {
            ArgumentNullException.ThrowIfNull(OtherNode);
            if (Value == null)
            {
                return false;
            }
            return Value.Equals(OtherNode.Value);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}