using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;
using List.src.List;

namespace List.src.LinkedList
{
    // Classe che rappresenta una lista collegata
    public class LinkedList<T> : List.IList<T>
    {
        // Campo privato che memorizza il nodo head della lista
        private INode<T>? head = null;

        // Campo privato che memorizza la lunghezza della lista
        private int length = 0;

        // Proprietà per ottenere o impostare il nodo head della lista
        public INode<T>? Head { get => head; set => head = value; }

        // Proprietà per ottenere o impostare la lunghezza della lista
        public int Length { get => length; set => length = value; }

        // Metodo per aggiungere un nuovo valore alla lista
        // Argomento: NewValue - il valore da aggiungere
        public void Add(T NewValue)
        {
            ArgumentNullException.ThrowIfNull(NewValue); // Verifica che il nuovo valore non sia nullo

            if (head == null) // Se la lista è vuota, aggiungi alla testa
            {
                AddToHead(NewValue);
                return;
            }

            AddToEnd(NewValue); // Altrimenti, aggiungi alla fine della lista
        }

        // Metodo per aggiungere un nuovo valore alla testa della lista
        // Argomento: NewValue - il valore da aggiungere alla testa
        private void AddToHead(T NewValue)
        {
            LinkedListNode<T> NewHead = new(NewValue); // Crea un nuovo nodo con il valore dato
            head = NewHead; // Imposta la testa al nuovo nodo
            length++; // Incrementa la lunghezza della lista
        }

        // Metodo per aggiungere un nuovo valore alla fine della lista
        // Argomento: NewValue - il valore da aggiungere alla fine
        private void AddToEnd(T NewValue)
        {
            if (head == null) // Verifica che la testa non sia nulla
            {
                throw new NullReferenceException("Head is null");
            }

            LinkedListNode<T> NewNode = new(NewValue); // Crea un nuovo nodo per il nuovo valore
            LinkedListNode<T> Curr = LinkedList<T>.ConvertToLinkedListNode(head); // Inizia dalla testa della lista

            // Traversiamo la lista fino all'ultimo nodo
            while (Curr.Next != null)
            {
                Curr = Curr.Next;
            }

            Curr.Next = NewNode; // Collega l'ultimo nodo al nuovo nodo
            length++; // Incrementa la lunghezza della lista
        }

        // Metodo per verificare se la lista è vuota
        // Ritorna: true se la lista è vuota, altrimenti false
        public bool IsEmpty()
        {
            return length == 0 || head == null; // Verifica se la lunghezza è zero o se la testa è nulla
        }

        // Metodo per verificare se un valore specifico è presente nella lista
        // Argomento: ValueToFind - il valore da cercare
        // Ritorna: true se il valore è trovato, altrimenti false
        public bool IsPresent(T ValueToFind)
        {
            ArgumentNullException.ThrowIfNull(ValueToFind); // Verifica che il valore da cercare non sia nullo

            if (head == null) // Se la lista è vuota, ritorna false
            {
                return false;
            }

            LinkedListNode<T>? Curr = LinkedList<T>.ConvertToLinkedListNode(head); // Inizia dalla testa della lista

            // Traversiamo la lista per cercare il valore
            while (Curr != null)
            {
                if (Curr.Value != null && Curr.Value.Equals(ValueToFind)) // Se il valore è trovato
                {
                    return true;
                }
                Curr = Curr.Next; // Passa al nodo successivo
            }

            return false; // Ritorna false se il valore non è trovato
        }

        // Metodo per rimuovere un valore dalla lista
        // Argomento: ValueToRemove - il valore da rimuovere
        public void Remove(T ValueToRemove)
        {
            ArgumentNullException.ThrowIfNull(ValueToRemove); // Verifica che il valore da rimuovere non sia nullo

            if (head == null) // Se la lista è vuota, lancia un'eccezione
            {
                throw new NullReferenceException("Head is null");
            }

            if (head.Value != null && head.Value.Equals(ValueToRemove)) // Se il valore da rimuovere è alla testa
            {
                RemoveHead(); // Rimuovi la testa
                return;
            }

            RemoveFromMiddle(ValueToRemove); // Altrimenti, rimuovi il valore dalla lista
        }

        // Metodo per rimuovere il nodo di testa dalla lista
        private void RemoveHead()
        {
            if (head == null) // Verifica che la testa non sia nulla
            {
                throw new NullReferenceException("Head is null");
            }

            head = LinkedList<T>.ConvertToLinkedListNode(head).Next; // Imposta la testa al nodo successivo
            length--; // Decrementa la lunghezza della lista
        }

        // Metodo per rimuovere un valore dalla parte centrale della lista
        // Argomento: ValueToRemove - il valore da rimuovere
        private void RemoveFromMiddle(T ValueToRemove)
        {
            if (head == null) // Verifica che la testa non sia nulla
            {
                throw new NullReferenceException("Head is null");
            }

            LinkedListNode<T> Prev = LinkedList<T>.ConvertToLinkedListNode(head); // Inizia dalla testa
            LinkedListNode<T>? Curr = Prev.Next; // Ottieni il nodo successivo

            // Traversiamo la lista per trovare il valore da rimuovere
            while (Curr != null)
            {
                T CurrValue = Curr.Value;
                if (CurrValue != null && CurrValue.Equals(ValueToRemove)) // Se il valore è trovato
                {
                    Prev.Next = Curr.Next; // Rimuovi il nodo corrente
                    length--; // Decrementa la lunghezza della lista
                    return;
                }
                Prev = Curr; // Muovi il puntatore precedente
                Curr = Curr.Next; // Muovi il puntatore corrente
            }
        }

        // Metodo per ottenere il valore in un determinato indice della lista
        // Argomento: Index - l'indice del valore da ottenere
        // Ritorna: il valore nell'indice dato, o lancia un'eccezione se fuori dai limiti
        public T? GetAt(int Index)
        {
            if (head == null) // Se la lista è vuota, lancia un'eccezione
            {
                throw new NullReferenceException("Head is null");
            }

            if (Index >= length || Index < 0) // Verifica che l'indice sia valido
            {
                throw new IndexOutOfRangeException("Index out of bound");
            }

            LinkedListNode<T>? Curr = LinkedList<T>.ConvertToLinkedListNode(head); // Inizia dalla testa

            // Traversiamo la lista per trovare il nodo all'indice specificato
            for (int i = 0; i < Index; i++)
            {
                if (Curr.Next == null) // Verifica che il nodo successivo non sia nullo
                {
                    throw new IndexOutOfRangeException("Index out of range due to null node");
                }
                Curr = Curr.Next; // Passa al nodo successivo
            }

            return Curr.Value; // Restituisci il valore all'indice specificato
        }

        // Metodo helper per convertire un INode<T> in un LinkedListNode<T>
        // Argomento: NodeToConvert - il nodo da convertire
        // Ritorna: Il nodo convertito di tipo LinkedListNode<T>
        private static LinkedListNode<T> ConvertToLinkedListNode(INode<T> NodeToConvert)
        {
            ArgumentNullException.ThrowIfNull(NodeToConvert); // Verifica che il nodo non sia nullo
            return (LinkedListNode<T>)NodeToConvert; // Esegui il cast e ritorna il nodo
        }

        // Metodo per rappresentare la lista collegata come una stringa
        // Ritorna: Una rappresentazione in stringa dell'intera lista
        public override string ToString()
        {
            if (head == null) // Se la lista è vuota, ritorna una lista vuota
            {
                return "[]";
            }

            StringBuilder stringBuilder = new(); // Crea un oggetto StringBuilder per costruire la stringa
            stringBuilder.Append('['); // Aggiungi il carattere di apertura

            LinkedListNode<T>? Curr= ConvertToLinkedListNode(head); // Inizia dalla testa della lista

            // Aggiungi il primo elemento
            if (Curr.Value != null)
            {
                stringBuilder.Append(Curr.Value);
            }

            Curr = Curt.Next; // Passa al nodo successivo

            // Aggiungi gli altri elementi separati da virgole
            while (Curr != null)
            {
                if (Curr.Value != null)
                {
                    stringBuilder.Append(", ");
                    stringBuilder.Append(Curr.Value);
                }
                Curr = Curr.Next; // Passa al nodo successivo
            }

            stringBuilder.Append(']'); // Aggiungi il carattere di chiusura
            return stringBuilder.ToString(); // Restituisci la rappresentazione in stringa della lista
        }


    }
}
