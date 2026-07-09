namespace FiltriAcquario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] tempIniziali = { 23.0, 25.0, 24.0, 22.0, 30.0 };

            static bool VerificaFiltri(double[] temperature, out int anomalie, out double[] tempCorrette)
            {
                anomalie = 0;
                tempCorrette = new double[temperature.Length];

                for (int i = 0; i < temperature.Length; i++)
                {
                    double temp = temperature[i];

                    if (temp < 22 || temp > 26)
                    {
                        anomalie++;
                        tempCorrette[i] = 22.0;
                        Console.WriteLine($"Anomalia riscontrata: la temperatura in posizione {i} è di {temp} gradi!");
                    }
                    else
                    {
                        // se corretta, copia la temp
                        tempCorrette[i] = temp;
                    }
                }

                bool sicuro = (anomalie == 0);
                return sicuro;
            }

            bool acquarioSicuro = VerificaFiltri(tempIniziali, out int anomalie, out double[] tempCorrette);

            Console.WriteLine($"Acquario sicuro: {acquarioSicuro}");
            Console.WriteLine($"Acquario con anomalie: {anomalie}");
        }
    }
}
