using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivo
{
    internal class Televisore : Dispositivo
    {
        public new void Accendi()
        {
            Console.WriteLine("Televisore acceso!");
        }
    }
}
