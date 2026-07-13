using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpereGiapponesi  
{
    internal class Anime : OperaGiapponese  
    {
        public int NumeroEpisodi { get; set; }
        public string StudioAnimazione { get; set; }

        // Costruttore con passaggio dei parametri alla classe base
        public Anime(string titolo, string autore, int numeroEpisodi, string studioAnimazione) 
            : base(titolo, autore)
        {
            StudioAnimazione = studioAnimazione;
            NumeroEpisodi = numeroEpisodi;
        }
        public override void MostraInfo()
        {
            Console.WriteLine($"[ANIME] {Titolo} - Autore: {Autore} | Episodi: {NumeroEpisodi} | Studio: {StudioAnimazione}");
        }
    }
}
