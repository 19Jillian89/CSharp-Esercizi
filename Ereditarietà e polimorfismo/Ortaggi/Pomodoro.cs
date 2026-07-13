using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ortaggi
{
    internal class Pomodoro : Ortaggio
    {
        // costruttore che passa "nome" al costruttore di Ortaggio
        public Pomodoro(string nome) : base(nome) { }
        public void Irriga()
        {
            Console.WriteLine($"Innaffiamo: {Nome}");

            if (statoCrescita == "Seminato")
            {
                statoCrescita = "In Fioritura";
                Console.WriteLine($"Pomodoro {Nome} è: {statoCrescita}");
            }
            else if (statoCrescita == "In Fioritura")
            {
                statoCrescita = "Maturo";
                Console.WriteLine($"Pomodoro {Nome} è {statoCrescita}!");
            }
            else
            {
                Console.WriteLine($"Possiamo raccogliere i nostri {Nome}!");
            }
        }
    }
}
