using System.ComponentModel;
using System.Text;

namespace NegozioInformatica
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<ComponentePC> inventario = new List<ComponentePC>() 
            {
                new ComponentePC { Nome = "RAM", Categoria = "GPU", Prezzo = 555.50m, PresenzaMagazzino = false },
                new ComponentePC { Nome = "Monitor curvo", Categoria = "Monitor", Prezzo = 999.99m, PresenzaMagazzino = true },
                new ComponentePC { Nome = "Dissipatore", Categoria = "Alimentatori", Prezzo = 105.00m, PresenzaMagazzino = false },
                new ComponentePC { Nome = "Scheda di rete XX-XXX", Categoria = "Schede di rete", Prezzo = 56.00m, PresenzaMagazzino = false },
                new ComponentePC { Nome = "Intel Core 5", Categoria = "CPU", Prezzo = 309.98m, PresenzaMagazzino = true },
                new ComponentePC { Nome = "Filtro antipolvere", Categoria = "Ventole", Prezzo = 3.79m, PresenzaMagazzino = true },
            };

            List<string> prodottiDisponibili = inventario
                .Where(component => component.Prezzo < 300 && component.PresenzaMagazzino)
                .Select(Component => Component.Nome)
                .ToList();

            Console.WriteLine("Lista Componenti Economici (sotto i 300€): \n");
            foreach (string nome in prodottiDisponibili) 
            {
                Console.WriteLine($"- {nome}\n");
            }

            bool prodottiTop = inventario.Any(component => component.Prezzo > 500);
            if (prodottiTop)
            {
                Console.WriteLine("Sono presenti componenti che superano i 500€.");
            }
            else
            {
                Console.WriteLine("Prodotti terminati.");
            }

        }
    }
}
