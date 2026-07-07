using static Gestione_Ristorante.Ordinazione;

namespace Gestione_Ristorante
{
    internal class Program
    {
        //Genera numeri random e crea ID tavoli
        private static Random randTavolo = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine($"Benvenuti al Ristorante Daje Goju!!" + "Pronti ad ordinare?\n");

            //ciclo che gestisce inserimento ordinazioni, finchè ADIOS non viene scritto
            while (true) 
            {
                int nuovoTavolo = randTavolo.Next(1, 16); ;
                Console.WriteLine($"\nIl tavolo assegnato è il numero: {nuovoTavolo}!");
                Console.WriteLine($"Inziamo l'ordine? Inserisci il menù di tuo gradimento (Carne, Pesce, Vegano).\nHai dimenticato il bancomat? Digita ADIOS: ");

                string inputMenu = Console.ReadLine();
                if (inputMenu == "ADIOS") 
                {
                    Console.WriteLine("Adios!");
                    break;
                }

                /* Converte la stringa digitata dall'utente nel corrispondente 
                 * valore dell'Enum 'TipoMenu'
                 * Il parametro 'true' ignora la differenza tra maiuscole e minuscole
                 * Se la conversione riesce, il valore viene salvato nella variabile 'menuScelto'
                 */
                if (Enum.TryParse(inputMenu, true, out TipoMenu menuScelto))
                {
                    new Ordinazione(nuovoTavolo, menuScelto);
                    Console.WriteLine($"Ordinazione registrata con successo per il Tavolo {nuovoTavolo}!\n");
                }
                else
                {
                    Console.WriteLine("menù non valido!\n");
                }
            }

            Console.WriteLine("Ore 23: CHIUSO! Riepilogo: \n");
            Console.WriteLine($"Menù totali venduti: {Ordinazione.TotaleMenu}");
            Console.WriteLine($"Carne: {Ordinazione.TotaleCarne}");
            Console.WriteLine($"Pesce: {Ordinazione.TotalePesce}");
            Console.WriteLine($"Vegano: {Ordinazione.TotaleVegano}");
        }
    }
}
