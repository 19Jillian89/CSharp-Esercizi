using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpereGiapponesi
{
    internal class OperaGiapponese
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }

        public OperaGiapponese(string titolo, string autore)
        {
            Titolo = titolo;
            Autore = autore;
        }

        //Le classi Manga e Anime non hanno il permesso di modificare MostraInfo!
        public virtual void MostraInfo() 
        {
            Console.WriteLine($"Nome: {Titolo}, di {Autore}");
        }
    }
}
