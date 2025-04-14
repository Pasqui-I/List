namespace List.src.List
{
    // Interfaccia che definisce il contratto per un Nodo in una lista collegata
    public interface INode<T>
    {
        // Proprietà per ottenere o impostare il valore del nodo
        public T Value { get; set; }

        // Metodo per confrontare il nodo corrente con un altro nodo
        // Argomento: OtherNode - il nodo con cui confrontare
        // Ritorna: true se i nodi sono uguali, altrimenti false
        public bool Equals(INode<T> OtherNode);

        // Metodo per rappresentare il nodo come una stringa
        // Ritorna: Una stringa che rappresenta il valore del nodo
        public string ToString();
    }
}