using System.Net.Cache;
using System.Text;

namespace NegozioVestiti
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Abbigliamento> inventario = new List<Abbigliamento>
            {
                new Abbigliamento { Modello = "Jeans", Reparto = "Donna", Disponibilita = 5, PrezzoOriginale = 39.99m},
                new Abbigliamento { Modello = "Minigonna", Reparto = "Donna", Disponibilita = 7, PrezzoOriginale = 19.99m},
                new Abbigliamento { Modello = "Reggiseno", Reparto = "Donna", Disponibilita = 2, PrezzoOriginale = 9.99m},
                new Abbigliamento { Modello = "T-Shirt", Reparto = "Donna", Disponibilita = 3, PrezzoOriginale = 5.00m},
                new Abbigliamento { Modello = "Cappotto", Reparto = "Donna", Disponibilita = 2, PrezzoOriginale = 109.99m},
                new Abbigliamento { Modello = "Calzini", Reparto = "Donna", Disponibilita = 6, PrezzoOriginale = 2.99m}
            };

            var articoloScontato = inventario
                .Where(capo => capo.Reparto == "Donna")
                .OrderBy(capo => capo.PrezzoOriginale)
                .Select(capo => $"Modello: {capo.Modello} - Prezzo Scontato: {capo.PrezzoOriginale * 0.80m:F2}€");

            Console.WriteLine("Capi scontati del 20%: \n");
            foreach (var sconto in articoloScontato)
            {
                Console.WriteLine(sconto);
            }
        } 
    }
}
