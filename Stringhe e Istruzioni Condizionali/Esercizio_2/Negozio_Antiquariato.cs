namespace Negozio_Antiquariato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] codici = { "ANT-4922", "", "ABC-4922", "ANT-1522", "ANT-4821", null };

            for (int i = 0; i < codici.Length; i++)
            {
                string identificativo = codici[i];

                // Controllo null per primo: Trim() su null lancerebbe un'eccezione
                if (identificativo == null)
                    goto CodiceNonValido;

                identificativo = identificativo.Trim();

                // StartsWith(): verifica se una stringa inizia con una specifica sottostringa
                if (!identificativo.StartsWith("ANT-"))
                    goto CodiceNonValido;

                if (identificativo == "")
                    goto CodiceNonValido;

                goto CodiceValido;

            CodiceNonValido:
                Console.WriteLine($"[Indice {i}] ERRORE: codice non valido. Elaborazione interrotta per questo elemento.");
                continue;

            CodiceValido:
                Console.WriteLine($"[Codice {i}] Codice '{identificativo}' accettato correttamente!");
            }

            Console.WriteLine("\nElaborazione completata.");
        }
    }
}
