using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffè
{
    //un'interfaccia è sempre public, e contiene solo la "firma" dei metodi, senza corpo.
    //le interfacce iniziano con la I maiuscola
    public interface IPreparazione
    {
        void Prepara();
    }
}
