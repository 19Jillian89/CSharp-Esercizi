using System;

namespace Autofficina
{
    internal class Cliente
    {
        private const decimal TariffaOraria = 40.00m;
        private const decimal CostoDiagnosi = 30m;
        private const decimal Iva = 0.22m;

        private decimal _oreManodopera;
        private static decimal oreManodoperaTotali = 0;

        private string _targa;
        private string _nome;

        public Cliente(string nome, string targa, decimal oreManodopera)
        {
            _nome = nome;
            _targa = targa;
            _oreManodopera = oreManodopera;

            oreManodoperaTotali += oreManodopera; 
        }

        /* Proprietà del SINGOLO CLIENTE: calcola il prezzo del suo intervento (senza IVA)
         * moltiplicando le sue ore per la tariffa oraria e aggiungendo il costo fisso della diagnosi.*/
        public decimal ContoTotale 
        {
            get { return (_oreManodopera * TariffaOraria) + CostoDiagnosi; }
        }

        /*Proprietà STATICA (dell'OFFICINA): permette di leggere dal Main il contatore globale 
         * e tiene traccia della somma di tutte le ore lavorate su tutte le macchine*/
        public static decimal OreManodoperaTotali
        {
            get { return oreManodoperaTotali; }
        }

        public decimal CalcoloIva() 
        {
            /*Calcola la parcella del singolo cliente moltiplicando le sue ore lavorate 
             * per la tariffa oraria (40€), e aggiunge l'IVA al 22%, 
             * moltiplicando per 1.22 (1 + 0.22)*/
            return _oreManodopera * TariffaOraria * (1 + Iva);
        }
    }
}
