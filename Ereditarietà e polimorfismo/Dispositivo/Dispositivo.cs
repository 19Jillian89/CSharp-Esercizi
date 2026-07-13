using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivo
{
    internal class Dispositivo
    {
        public virtual void Accendi()
        {
            Console.WriteLine("Il dispositivo si sta accendendo ");
        }
    }
}
