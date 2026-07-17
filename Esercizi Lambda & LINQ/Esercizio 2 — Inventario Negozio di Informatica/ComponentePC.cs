using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioInformatica
{
    public class ComponentePC
    {
        public string Nome { get; set; } 
        public string Categoria { get; set; } 
        public decimal Prezzo { get; set; } 
        public bool PresenzaMagazzino { get; set; }
    }
}
