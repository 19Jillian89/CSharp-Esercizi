using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpereGiapponesi
{
    internal class Manga : OperaGiapponese
    {
        public int VolumiRilasciati { get; set; }

        public Manga(string titolo, string autore, int volumiRilasciati) : base(titolo, autore)
        {
            VolumiRilasciati = volumiRilasciati;
        }

        public override void MostraInfo() 
        {
            Console.WriteLine($"[MANGA] {Titolo} - Autore: {Autore} | Volumi pubblicati: {VolumiRilasciati}");
        }
    }
}
