using System.Runtime.CompilerServices;
using System.Text;
using List.src.List;

namespace List.src.LinkedList
{
    public class LinkedList<T> : List.IList<T>
    {
        private INode<T>? head = null;
        private int length = 0;
        public INode<T>? Head { get => head; set => head = value; }
        public int Length { get => length; set => length = value; }
        public void Add(T NewValue)
        {
            ArgumentNullException.ThrowIfNull(NewValue);
            if (head == null)
            {
                AddToHead(NewValue);
            }
            AddToEnd(NewValue);
        }

        private void AddToHead(T NewValue)
        {
            LinkedListNode<T> NewHead = new(NewValue);
            head = NewHead;
        }

        private void AddToEnd(T NewValue)
        {
            if (head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            LinkedListNode<T> NewNode = new(NewValue);
            LinkedListNode<T> Curr = LinkedList<T>.ConvertToLinkedListNode(head);
            while (Curr.Next != null)
            {
                Curr = Curr.Next;
            }
            Curr.Next = NewNode;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public bool IsPresent(T ValueToFind)
        {
            ArgumentNullException.ThrowIfNull(ValueToFind);
            if (head == null)
            {
                return false;
            }
            LinkedListNode<T>? Curr = LinkedList<T>.ConvertToLinkedListNode(head);
            while (Curr != null)
            {
                if (Curr.Value != null && Curr.Value.Equals(ValueToFind))
                {
                    return true;
                }
                Curr = Curr.Next;
            }

            return false;
        }

        public void Remove(T ValueToRemove)
        {
            ArgumentNullException.ThrowIfNull(ValueToRemove);
            if (head == null)
            {
                throw new NullReferenceException("Head is null");
            }
            if (head.Value != null && head.Value.Equals(ValueToRemove))
            {
                RemoveHead();
            }
            RemoveFromMiddle(ValueToRemove);
        }


        private void RemoveHead()
        {
            if (head == null)
            {
                throw new NullReferenceException("Head is null");
            }

            head = LinkedList<T>.ConvertToLinkedListNode(head).Next;
        }

        private void RemoveFromMiddle(T ValueToRemove)
        {
            if (head == null)
            {
                throw new NullReferenceException("Head is null");
            }

            LinkedListNode<T> Prev = LinkedList<T>.ConvertToLinkedListNode(head);
            LinkedListNode<T>? Curr = Prev.Next;
            while (Curr != null)
            {
                T CurrValue = Curr.Value;
                if (CurrValue != null && CurrValue.Equals(ValueToRemove))
                {
                    Prev.Next = Curr.Next;
                }
                Prev = Curr;
                Curr = Curr.Next;
            }
        }

        private static LinkedListNode<T> ConvertToLinkedListNode(INode<T> NodeToConvert)
        {
            ArgumentNullException.ThrowIfNull(NodeToConvert);
            return (LinkedListNode<T>)NodeToConvert;
        }

        public override string ToString()
        {
            if (head == null)
            {
                return "[]";
            }
            StringBuilder StringBuilder = new();
            StringBuilder.Append('[');
            LinkedListNode<T> Curr = LinkedList<T>.ConvertToLinkedListNode(head);
            while (Curr.Next != null)
            {
                T CurrValue = Curr.Value;
                if (CurrValue != null)
                {
                    StringBuilder.Append(CurrValue + ", ");
                }
            }
            if (Curr != null && Curr.Value != null)
            {
                StringBuilder.Append(']');
            }
            return StringBuilder.ToString();
        }
    }
}