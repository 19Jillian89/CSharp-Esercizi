using System.ComponentModel;

namespace Analisi_Temperature
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Citta> meteo = new List<Citta>()
            {
                new Citta{ Nome = "Roma", Temperature = 35.0, Umidita = 70},
                new Citta{ Nome = "Bologna", Temperature = 31.5, Umidita = 55},
                new Citta{ Nome = "Perugia", Temperature = 37.0, Umidita = 27},
                new Citta{ Nome = "Lucca", Temperature = 29, Umidita = 46},
                new Citta{ Nome = "Bressanone", Temperature = 28.5, Umidita = 36}

            };

            //Allerta caldo (> 30°C)
            var allertaCaldo = meteo.Where(c => c.Temperature > 30);
            
            Console.WriteLine("Lista Città allerta caldo: \n");

            int indice = 1;
            foreach (var citta in allertaCaldo)
            {
                Console.WriteLine($"Città: {citta.Nome} - Temperatura: {citta.Temperature}°C - Umidità: {citta.Umidita}%");
            }
            
            var cittaPiuFredde = meteo.OrderBy(c => c.Temperature);

            Console.WriteLine("\nLista Città ordinate dalla più fredda alla più calda: \n");
            int indicedue = 1;
            foreach (var citta in cittaPiuFredde)
            {
                Console.WriteLine($"Città: {citta.Nome} - Temp: {citta.Temperature}°C - Umidità: {citta.Umidita}%");
            }

            var cittaPiuCalde = meteo.OrderByDescending(c => c.Temperature);

            Console.WriteLine("\nLista Città ordinate dalla più clada alla più fredda: \n");
            int indicetre = 1;
            foreach (var citta in cittaPiuCalde)
            {
                Console.WriteLine($"Città: {citta.Nome} - Temp: {citta.Temperature}°C - Umidità: {citta.Umidita}%");
            }
        }
    }
}
