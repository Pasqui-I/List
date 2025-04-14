using List.src.List;

namespace List.src.LinkedList
{
    // Classe che rappresenta un nodo in una lista collegata
    public class LinkedListNode<T> : INode<T>
    {
        // Campo privato che memorizza il valore del nodo
        private T value;

        // Campo privato che memorizza il nodo successivo nella lista
        private LinkedListNode<T>? next = null;

        // Costruttore per creare un nuovo nodo LinkedListNode con un valore dato
        // Argomento: Value - il valore da memorizzare nel nodo
        public LinkedListNode(T Value)
        {
            value = Value;
        }

        // Proprietà per ottenere o impostare il valore del nodo
        public T Value { get => value; set => this.value = value; }

        // Proprietà per ottenere o impostare il nodo successivo nella lista
        public LinkedListNode<T>? Next { get => next; set => next = value; }

        // Metodo per confrontare due nodi per uguaglianza
        // Argomento: OtherNode - il nodo da confrontare
        // Ritorna: true se i valori sono uguali, altrimenti false
        public bool Equals(INode<T> OtherNode)
        {
            ArgumentNullException.ThrowIfNull(OtherNode); // Verifica che l'altro nodo non sia nullo

            if (Value == null) // Se il valore di questo nodo è nullo, non può essere uguale ad un altro nodo
            {
                return false;
            }

            return Value.Equals(OtherNode.Value); // Confronta i valori dei nodi
        }

        // Metodo per restituire una rappresentazione in stringa del nodo
        // Ritorna: Una stringa che descrive il valore del nodo
        public override string ToString()
        {
            return $"Value : {Value}"; // Formato semplice per la descrizione del valore del nodo
        }
    }
}