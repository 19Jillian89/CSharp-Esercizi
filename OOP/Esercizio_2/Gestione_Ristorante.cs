using System;

namespace Gestione_Ristorante
{
    internal class Ordinazione
    {
        public enum TipoMenu
        {
            Vegano,
            Carne,
            Pesce
        }

        public static int TotaleMenu = 0;
        public static int TotaleVegano = 0;
        public static int TotaleCarne = 0;
        public static int TotalePesce = 0;

        public int IdTavolo { get; }
        public TipoMenu Tipo { get; }

        public Ordinazione(int idTavolo, TipoMenu tipo)
        {
            IdTavolo = idTavolo;
            Tipo = tipo;

            TotaleMenu++;

            switch (tipo) 
            {
                case TipoMenu.Vegano:
                    TotaleVegano++;
                    break;

                case TipoMenu.Carne:
                    TotaleCarne++;
                    break;

                case TipoMenu.Pesce:
                    TotalePesce++;
                    break;
            }
        }
    }
}
