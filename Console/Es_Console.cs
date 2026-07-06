namespace ConsoleApp1
{
    class Guerriero
    {
        public string Nome { get; set; }
        public int HPMassimi { get; set; }
        public int HPAttuali { get; set; }
        public string Stato { get; set; }

        public void EroeAttaccato(int danno)
        {
            //prende il valore attuale, ci sottrae danno, e riassegna il risultato alla stessa variabile.
            //Se HPAttuali è 200 e danno è 150, HPAttuali vale 50
            HPAttuali -= danno;

            // Impedisce che gli HP scendano sotto zero 
            if (HPAttuali < 0)
                HPAttuali = 0;

            Stato = (HPAttuali <= 0) ? "Svenuto" : "Pronto al combattimento";

            Console.WriteLine($"{Nome} subisce {danno} danni! HP rimanenti: {HPAttuali}/{HPMassimi}");
        }
        public void StampaInfo()
        {
            Console.WriteLine("\n--- Caratteristiche Guerriero ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"HP: {HPAttuali}/{HPMassimi}");
            Console.WriteLine($"Stato: {Stato}");
        }
    }

    // Rappresenta il mercante: ora prezzo e sconto sono proprietà dell'istanza,
    // non più parametri del metodo — vanno valorizzate PRIMA di chiamare MostraRicevuta()
    class Mercante
    {
        public decimal PrezzoBase { get; set; }
        public double Sconto { get; set; }

        // Metodo per calcolare il prezzo finale e stampare lo scontrino
        public void MostraRicevuta()
        {
            // Cast esplicito da double a decimal per eseguire l'operazione matematica
            decimal scontoDecimal = (decimal)Sconto;
            decimal importoSconto = PrezzoBase * scontoDecimal;
            decimal prezzoFinale = PrezzoBase - importoSconto;

            Console.WriteLine("\n--- RICEVUTA MERCANTE ---");
            Console.WriteLine("{0, -20} {1, 15:C}", "Prezzo Iniziale:", PrezzoBase);
            Console.WriteLine("{0, -20} {1, 15:P0}", "Sconto Applicato:", scontoDecimal);
            Console.WriteLine("{0, -20} {1, 15:C}", "Prezzo Finale:", prezzoFinale);
            Console.WriteLine("GRAZIE!");
            Console.WriteLine("-------------------------\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*----GUERRIERO----*/
            Guerriero guerriero = new Guerriero();

            Console.Write("Inserisci Nickname: ");
            guerriero.Nome = Console.ReadLine();

            Console.WriteLine($"\nBenvenuto, {guerriero.Nome}! Il regno ha bisogno di un eroe come te.");
            Console.WriteLine("Dimmi altro di te...\n");

            Console.Write("Hp massimi sono: ");
            string inputHpMassimi = Console.ReadLine();
            if (!int.TryParse(inputHpMassimi, out int maxHp))
            {
                Console.WriteLine("Nope! Valore hp massimi errato! Adios");
                return;
            }
            guerriero.HPMassimi = maxHp;

            Console.Write("Hp attuali sono: ");
            string inputHpAttuali = Console.ReadLine();
            if (!int.TryParse(inputHpAttuali, out int hpAttuali))
            {
                Console.WriteLine("Nope! Valore Hp attuali errato! Adios");
                return;
            }
            else if (hpAttuali > maxHp)
            {
                Console.WriteLine($"HP attuali {hpAttuali} sono superiori a quelli massimi: reimpostati al valore massimo {maxHp}\n");
                hpAttuali = maxHp;
            }
            guerriero.HPAttuali = hpAttuali;

            guerriero.Stato = (hpAttuali <= 0) ? "Svenuto" : "Pronto al combattimento";
            guerriero.StampaInfo();

            Console.Write("\nOh no! Il nostro eroe è stato attaccato!! Quanti danni sono stati inflitti? ");
            string inputDanno = Console.ReadLine();
            if (int.TryParse(inputDanno, out int danno))
            {
                guerriero.EroeAttaccato(danno);
                guerriero.StampaInfo();   // ristampo per vedere lo stato aggiornato
            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();
            Console.WriteLine("\n");

            /*----MERCANTE----*/
            Mercante mercante = new Mercante();

            Console.WriteLine("Salve guerriero, hai bisogno di una bella pozione!!\n");

            Console.Write("La pozione costa: ");
            string inputPrezzo = Console.ReadLine();
            decimal prezzoBase;
            try
            {
                prezzoBase = Convert.ToDecimal(inputPrezzo);
            }
            catch (FormatException)
            {
                prezzoBase = 50.00m;
                Console.WriteLine("Nope! Conversione fallita, la pozione avrà un prezzo prestabilito di 50.00 euro.");
            }

            Console.Write("Mi sei simpatico, ti farò uno sconto: ");
            string inputSconto = Console.ReadLine();
            double sconto = Convert.ToDouble(inputSconto);

            // Valorizzo le proprietà dell'istanza PRIMA di chiamare MostraRicevuta()
            mercante.PrezzoBase = prezzoBase;
            mercante.Sconto = sconto;
            mercante.MostraRicevuta();
        }
    }
}
