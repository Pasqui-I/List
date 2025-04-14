namespace List.src.List
{
    // Interfaccia che definisce il contratto per una Lista (specifically una Lista Collegata)
    public interface IList<T>
    {
        // Proprietà per ottenere o impostare il nodo head della lista
        public INode<T>? Head { get; set; }

        // Proprietà per ottenere o impostare la lunghezza della lista
        public int Length { get; set; }

        // Metodo per aggiungere un nuovo valore alla lista
        // Argomento: NewValue - il valore da aggiungere
        public void Add(T NewValue);

        // Metodo per rimuovere un valore dalla lista
        // Argomento: ValueToRemove - il valore da rimuovere
        public void Remove(T ValueToRemove);

        // Metodo per verificare se un valore è presente nella lista
        // Argomento: ValueToFind - il valore da cercare
        // Ritorna: true se il valore è trovato, altrimenti false
        public bool IsPresent(T ValueToFind);

        // Metodo per ottenere un valore in un determinato indice della lista
        // Argomento: Index - l'indice del valore da ottenere
        // Ritorna: il valore nell'indice dato, o null se fuori dai limiti
        public T? GetAt(int Index);

        // Metodo per verificare se la lista è vuota
        // Ritorna: true se la lista è vuota, altrimenti false
        public bool IsEmpty();

        // Metodo per rappresentare la lista come una stringa
        // Ritorna: Una rappresentazione in stringa dell'intera lista
        public string ToString();

    }
}