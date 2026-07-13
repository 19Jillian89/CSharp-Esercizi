using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ortaggi
{
    internal class Ortaggio
    {
        protected string statoCrescita = "Seminato";
        public string Nome { get; set; }

        public Ortaggio(string nome)
        {
            Nome = nome;
        }
        public string VerificaCrescita() 
        {
            return statoCrescita;
        }
    }
}
