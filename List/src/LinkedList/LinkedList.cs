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
                return;
            }
            AddToEnd(NewValue);
        }

        private void AddToHead(T NewValue)
        {
            LinkedListNode<T> NewHead = new(NewValue);
            head = NewHead;
            length++;
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
            length++;
        }

        public bool IsEmpty()
        {
            return length == 0 || head == null;
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
                return;
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
            length--;
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
                    length--;
                    return;
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

            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');

            LinkedListNode<T>? current = ConvertToLinkedListNode(head);

            // Aggiungi il primo elemento
            if (current.Value != null)
            {
                stringBuilder.Append(current.Value);
            }

            current = current.Next;

            // Aggiungi gli elementi successivi con la virgola
            while (current != null)
            {
                if (current.Value != null)
                {
                    stringBuilder.Append(", ");
                    stringBuilder.Append(current.Value);
                }
                current = current.Next;
            }

            stringBuilder.Append(']');
            return stringBuilder.ToString();
        }
    }
}