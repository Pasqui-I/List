
class Program
{
    static void Main(string[] args)
    {
        // Sezione 1: Creazione della lista e test di inserimento
        Console.WriteLine("Sezione 1: Creazione della lista e test di inserimento");
        List.src.LinkedList.LinkedList<int> lista = new();
        Console.WriteLine($"Lista vuota: {lista.ToString()}"); // Lista inizialmente vuota

        // Aggiungi alcuni valori alla lista
        lista.Add(10);
        lista.Add(20);
        lista.Add(30);
        Console.WriteLine($"Lista dopo l'aggiunta di 10, 20 e 30: {lista.ToString()}");

        // Sezione 2: Test di presenza dei valori
        Console.WriteLine("\nSezione 2: Test di presenza dei valori");
        Console.WriteLine($"È presente 20 nella lista? {lista.IsPresent(20)}"); // Dovrebbe essere true
        Console.WriteLine($"È presente 40 nella lista? {lista.IsPresent(40)}"); // Dovrebbe essere false

        // Sezione 3: Test di rimozione di un valore
        Console.WriteLine("\nSezione 3: Test di rimozione di un valore");
        lista.Remove(20); // Rimuovi il valore 20
        Console.WriteLine($"Lista dopo aver rimosso 20: {lista.ToString()}");

        // Prova a rimuovere un valore non presente
        try
        {
            lista.Remove(40); // Tentativo di rimuovere un valore non presente
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante la rimozione: {ex.Message}"); // Mostra errore se il valore non è trovato
        }

        // Sezione 4: Test di accesso a un elemento per indice
        Console.WriteLine("\nSezione 4: Test di accesso a un elemento per indice");
        try
        {
            int valore = lista.GetAt(1); // Dovrebbe restituire il secondo elemento (30)
            Console.WriteLine($"Valore all'indice 1: {valore}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante l'accesso: {ex.Message}");
        }

        // Sezione 5: Test di lista vuota
        Console.WriteLine("\nSezione 5: Test di lista vuota");
        List.src.LinkedList.LinkedList<int> listaVuota = new();
        Console.WriteLine($"La lista è vuota? {listaVuota.IsEmpty()}"); // Dovrebbe essere true

        // Aggiungi un elemento e verifica se la lista è vuota
        listaVuota.Add(100);
        Console.WriteLine($"La lista è vuota dopo aver aggiunto un elemento? {listaVuota.IsEmpty()}"); // Dovrebbe essere false

        // Sezione 6: Test di gestione di un errore per indice fuori dai limiti
        Console.WriteLine("\nSezione 6: Test di gestione di un errore per indice fuori dai limiti");
        try
        {
            lista.GetAt(10); // Indice fuori dai limiti
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante l'accesso: {ex.Message}"); // Dovrebbe lanciare un errore
        }
    }
}
