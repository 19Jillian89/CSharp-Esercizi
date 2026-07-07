using System;

namespace Azienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dipendenti gianni = new Dipendenti("Gianni", 3, 0);
            Dipendenti luisa = new Dipendenti("Luisa", 4, 0);
            Dipendenti marco = new Dipendenti("Gianni", 0, 16);

            Console.WriteLine($"Totale giorni ferie: {Dipendenti.TotaleFerie}");
            Console.WriteLine($"Totale ore permessi: {Dipendenti.TotalePermessi}");
        }
    }
}
