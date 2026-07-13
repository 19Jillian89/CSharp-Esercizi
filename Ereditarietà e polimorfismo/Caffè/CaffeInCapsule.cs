using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffè
{
    class CaffeInCapsule : Caffe
    {
        public string MaterialeCapsula { get; set; }
        public string Compatibilita { get; set; }

        public double PesoCapsula { get; set; }
        public int PezzoConfezione { get; set; }

        // : base(...) passa Miscela e PrezzoAlChilo al costruttore del padre,
        // poi il corpo inizializza le proprietà aggiuntive di questa classe
        public CaffeInCapsule(string miscela, double prezzoAlChilo, string materialeCapsula, string compatibilita, double pesoCapsula, int pezzoConfezione)
            : base(miscela, prezzoAlChilo)
        {
            MaterialeCapsula = materialeCapsula;
            Compatibilita = compatibilita;
            PesoCapsula = pesoCapsula;
            PezzoConfezione = pezzoConfezione;
        }

        public double CostoCapsulaSingola() 
        {
            double prezzoGrammo = PrezzoAlChilo / 1000;
            return prezzoGrammo * PesoCapsula;
        }

        public double CostoConfezione() 
        {
            return CostoCapsulaSingola() * PezzoConfezione;
        }

        // override reale: stessa firma di Caffe.Prepara(), comportamento specifico
        public override void Prepara()
        {
            Console.WriteLine($"Preparazione del caffè con miscela {Miscela}...");
            Console.WriteLine($"Inserisci la capsula in {MaterialeCapsula} nella macchina {Compatibilita} e premi il tasto di erogazione.\n");
        }

        // override che riusa il ToString del padre con base.ToString(), poi aggiunge i dettagli della capsula
        public override string ToString()
        {
               return $"\n--- SCHEDA TECNICA CAPSULA ---\n" +
               $"Miscela: {Miscela}\n" +
               $"Prezzo al Kg: {PrezzoAlChilo:C}\n" +
               $"Materiale: {MaterialeCapsula}\n" +
               $"Compatibilità: {Compatibilita}\n" +
               $"------------------------------";
        }
    }
}
