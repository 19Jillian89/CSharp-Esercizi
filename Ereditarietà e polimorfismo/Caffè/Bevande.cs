using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffè
{
    //Caffe implementa l'interfaccia (basta aggiungere : IPreparazione accanto al nome della classe)
    public class Bevande : IPreparazione
    {
        public string Tipo { get; set; }
        public int MinutiCottura{get; set; }
        public double PrezzoAlChilo { get; set; }
        public double GrammiConfezione { get; set; }

        public Bevande(string tipo, int minutiCottura, double prezzoAlChilo, double grammiConfezione) 
        {
            Tipo = tipo;
            MinutiCottura = minutiCottura;
            PrezzoAlChilo = prezzoAlChilo;
            GrammiConfezione = grammiConfezione;
        }

        // Metodo per calcolare il costo del barattolo/confezione solubile
        public double CostoConfezioneBevanda()
        {
            return PrezzoAlChilo * (GrammiConfezione / 1000);
        }

        public void Prepara() 
        {
            Console.WriteLine("Preparazione della bevanda: ");
            Console.WriteLine($"{Tipo}! Versa del latte e lascia cuocere per {MinutiCottura} minuti.\n");
        }

        public override string ToString()
        {
               return $"--- SCHEDA TECNICA BEVANDA ---\n" +
               $"Bevanda: {Tipo}\n" +
               $"Tempo di cottura: {MinutiCottura} minuti\n" +
               $"------------------------------";
        }
    }
}
