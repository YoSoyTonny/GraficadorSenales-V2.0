using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSeñales
{
    class SeñalRectangular : Señal
    {
        public SeñalRectangular()
        {
            Alpha = 1.0;
            Umbral = 0.0;
            Muestras = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }

    }
}
