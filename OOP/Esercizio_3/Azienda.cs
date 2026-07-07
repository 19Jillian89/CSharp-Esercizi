using System;

namespace Azienda
{
    internal class Dipendenti
    {
        /*Calcolo tot = 9 giorni ferie 
         * Gianni ha 3 giorni, Luisa ne ha 4,
         * Marco ha 16 ore di permessi
         * Calcolo 16 ore totali / 8 ore giornaliere
         * = 2 giorni di lavoro.
         * Sommo Gianni + Luisa + Marco = 9 giorni totali*/
        private const int GiorniFerieMinime = 2;
        private const int OrePermessiMinime = 8;

        private static int totaleFerie = 0;
        private static int totalePermessi = 0;
       
        public string Nome { get; }

        private int giorniFerie;
        public int GiorniFerie
        {
            get { return giorniFerie; }
            set
            {
                if (value < GiorniFerieMinime)
                    giorniFerie = GiorniFerieMinime;
                else
                    giorniFerie = value;
            }
        }

        private int orePermessi;
        public int OrePermessi 
        {
            get { return orePermessi; }
            set
            {
                if (value < OrePermessiMinime)
                    orePermessi = OrePermessiMinime;
                else
                    orePermessi= value;
            }
        }
        public Dipendenti(string nome, int giorniFerie, int orePermessi) 
        {
            Nome = nome;
            GiorniFerie = giorniFerie;
            OrePermessi = orePermessi;

            totaleFerie += GiorniFerie;
            totalePermessi += OrePermessi;
        }
        public static int TotaleFerie
        {
            get { return totaleFerie; }
        }

        public static int TotalePermessi
        {
            get { return totalePermessi; }
        }
    }
}
