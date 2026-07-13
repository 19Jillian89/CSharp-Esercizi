using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffè
{
    internal class Caffe : IPreparazione
    {
        public string Miscela { get; set; }
        public double PrezzoAlChilo { get; set; }

        public double GrammiConfezione { get; set; } = 250;

        public Caffe(string miscela, double prezzoAlChilo)
        {
            Miscela = miscela;
            PrezzoAlChilo = prezzoAlChilo;
        }

        public double CostoConfezioneMoka()
        {
            // Dividiamo i grammi della confezione per 1000 per convertire il prezzo al Kg
            return PrezzoAlChilo * (GrammiConfezione / 1000);
        }

        // virtual: le classi figlie POSSONO riscriverlo, ma non sono obbligate
        public virtual void Prepara()
        {
            Console.WriteLine($"Preparazione del caffè miscela {Miscela}...");
            Console.WriteLine($"Riempi la base della moka con acqua fredda. Riempi il filtro di caffè macinato. Avvita e metti sul fuoco.");
        }

        // override perché ToString() esiste già in Object, ed è virtual lì
        public override string ToString()
        {
               return $"------- SCHEDA TECNICA -------\n" +
               $"Miscela: {Miscela}\n" +
               $"Prezzo al Kg: {PrezzoAlChilo:C}\n" +
               $"------------------------------";
        }
    }
}
