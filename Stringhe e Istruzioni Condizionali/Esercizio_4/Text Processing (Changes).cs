using System.Collections.Specialized;
using System.Globalization;

namespace Changes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testo = "Ciao Osvalda! Se sei interessata a questo prodotto, il suo prezzo è di €250";
            string nomeErrato = "Osvalda";
            string valoreDaCambiare = "€250";

            Console.WriteLine($"Prima: {testo}\n");

            if (testo.Contains(nomeErrato))
            {
                testo = testo.Replace("Osvalda", "").Trim();
                Console.WriteLine("Nome errato rimosso!\n");
            }

            if (testo.Contains("prezzo"))
            {
                testo = testo.Replace("prezzo", "prz");
                Console.WriteLine("\nParola sostituita!\n");
            }

            Console.WriteLine($"Dopo: {testo}\n");

            // Conversione
            string nuovoPrezzo = valoreDaCambiare.Replace("€", "").Trim();
            int numero = int.Parse(nuovoPrezzo);
            Console.WriteLine($"\nPrezzo convertito: {numero}");

            // Elevamento
            double result = Math.Pow(numero, 2);
            Console.WriteLine($"{numero} con l'operazione di elevamento a potenza diventa: {result}");
        }
    }
}
