using System;

namespace Acquario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] acquario = {
                { "Pesce Pagliaccio", "Pesce Chirurgo", "Vuota",         "Vuota"   },
                { "Pesce Rosso",      "Merluzzo",       "Vuota",         "Delfino" },
                { "Vuota",            "Vuota",          "Stella Marina", "Salmone" },
                { "Vuota",            "Pesce Palla",    "Tonno",         "Vuota"   }
            };

            int righe = acquario.GetLength(0);
            int colonne = acquario.GetLength(1);
            int vaschePiene = 0;
            int vascheVuote = 0;

            // --- Stampa matrice + conteggio ---
            Console.WriteLine("°°°Mappa Acquario°°°");
            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    Console.Write($"{acquario[i, j],-20}");

                    if (acquario[i, j] == "Vuota")
                        vascheVuote++;
                    else
                        vaschePiene++;
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nLe vasche con pesci sono: {vaschePiene}");
            Console.WriteLine($"Vasche vuote sono: {vascheVuote}");

            // --- Diagonale Principale ---
            Console.WriteLine("\n°°°Diagonale Principale°°°");
            for (int i = 0; i < righe; i++)
            {
                Console.WriteLine(acquario[i, i]);
            }

            // --- Diagonale Secondaria ---
            Console.WriteLine("\n°°°Diagonale Secondaria°°°");
            for (int i = 0; i < righe; i++)
            {
                Console.WriteLine(acquario[i, righe - 1 - i]);
            }

            CercaPesce(acquario, "Pesce Pagliaccio");
            CercaPesce(acquario, "Delfino");
            CercaPesce(acquario, "Balena");
        }

        // Metodo static: cerca una specie all'interno della matrice.
        // Se la trova: stampa il messaggio e fa return (esce subito, non continua a cercare).
        // Se non la trova: il ciclo continua fino alla fine e stampa il messaggio "non presente".
        static void CercaPesce(string[,] acquario, string specie)
        {
            int righe = acquario.GetLength(0);
            int colonne = acquario.GetLength(1);

            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    if (acquario[i, j] == specie)
                    {
                        if (specie == "Delfino")
                        {
                            Console.WriteLine($"\nHai trovato il Delfino in [{i},{j}]! Complimenti, HAI VINTO!!");
                        }
                        else
                        {
                            Console.WriteLine($"\n{specie} trovato in [{i},{j}]!");
                        }
                        return;
                    }
                }
            }
            Console.WriteLine($"\n{specie} non presente nell'acquario.");
        }
    }
}
