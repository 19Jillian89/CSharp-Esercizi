using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivo
{
    internal class Smartphone : Dispositivo
    {

        public override void Accendi() 
        {
            Console.WriteLine("Schermo sbloccato, smartphone acceso!");
        }
    }
}
