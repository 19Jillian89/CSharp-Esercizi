namespace Caffè
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // la lista è di tipo IPreparazione: può contenere qualsiasi cosa, la dimensione non è fissa
            //Il <T> tra parentesi angolari è un tipo generico
            List<IPreparazione> torrefazione = new List<IPreparazione>
            {
                new Caffe("Arabica", 19.55),
                new CaffeInCapsule("Robusta", 45.55, "Alluminio", "Nespresso", 8.0, 15),
                new Bevande("Cioccolata", 6, 25.00, 250),
                new Bevande("Orzo", 5, 7.5, 750)
            };

            //Imposta il colore del testo.
            //Questa enumerazionea arriva ad includere fino a 16 colori (Red, Magenta, Green etc)
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Usando "@" dici a C# di ignorare questi comandi speciali e di prendere
            //il testo esattamente così come lo vedi.
            Console.WriteLine(@"
                             /\_/\ 
                             (°v°)
                             /|_||\
            
                 COO...Benvenuto ""Alla Piccionaia""!!
                Dicono che io ci metta il latte di piccione nel mio caffè...
                ");
            //comando che serve per fermare l'effetto del colore
            Console.ResetColor();

            foreach (IPreparazione prodotto in torrefazione) 
            {
                Console.WriteLine(prodotto.ToString());

                if (prodotto is CaffeInCapsule capsula)
                {
                    Console.WriteLine($"Prezzo per capsula singola: {capsula.CostoCapsulaSingola():C}");
                    Console.WriteLine($"Prezzo confezione ({capsula.PezzoConfezione} pz): {capsula.CostoConfezione():C}");
                }
                else if (prodotto is Caffe caffeMoka) 
                {
                    Console.WriteLine($"Prezzo pacchetto da ({caffeMoka.GrammiConfezione}g): {caffeMoka.CostoConfezioneMoka():C}");
                }
                else if (prodotto is Bevande bevanda)
                {
                    Console.WriteLine($"Prezzo barattolo ({bevanda.GrammiConfezione}g): {bevanda.CostoConfezioneBevanda():C}");
                }
                prodotto.Prepara();
            }
        }
    }
}
