using System;
using System.Globalization;

namespace Studente
{
    internal class Studente
    {
        public string Nome { get; set; }
        public int[] Voti;

        public Studente(String nome, int[] voti)
        {
            Nome = nome;
            Voti = voti;
        }

        public double CalcoloMedia()
        {
            int numSomma = 0;
            foreach (int voto in Voti)
                numSomma += voto;
            return (double)numSomma / Voti.Length;
        }

        public string strOutput()
        {
            double media = CalcoloMedia();
            return string.Format("{0} - Media: {1:F2}", Nome.ToUpper(), media);
        }

        public string determinareGiudizio()
        {
            double media = CalcoloMedia();
            string giudizio;

            if (media > 9)
            {
                giudizio = "Eccellente";
            }
            else if (media >= 6 && media < 9)
            {
                giudizio = "Superato";
            }
            else
            {
                giudizio = "Non Superato";
            }
            return giudizio;
        }
    }
}
