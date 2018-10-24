using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSeñales
{
    abstract class Señal
    {
        public List<Muestra> Muestras { get; set; }
        public double AmplitudMaxima { get; set; }

        public double Umbral { get; set; }

        public double TiempoInicial { get; set; }
        public double TiempoFinal { get; set; }
        public double FrecuenciaMuestreo { get; set; }

        public double Alpha { get; set; }

        public abstract double evaluar(double tiempo);

        public void construirSeñalDigital()
        {
            double periodoMuestreo = 1 / FrecuenciaMuestreo;

            for (double i = TiempoInicial; i <= TiempoFinal; i += periodoMuestreo)
            {
                double valorMuestra = evaluar(i);

                Muestras.Add(new Muestra(i, valorMuestra));

                if (Math.Abs(valorMuestra) > AmplitudMaxima)
                {
                    AmplitudMaxima = Math.Abs(valorMuestra);

                }

            }
            
        }

        public void escalar(double factor)
        {
            foreach(Muestra muestra in Muestras)
            {
                muestra.Y *= factor; //Se va a multiplicar  
                                
            }

        }

        public void actualizarAmplitudMaxima() //La resetea
        {
            AmplitudMaxima = 0;
            foreach(Muestra muestra in Muestras)
            {
                if (Math.Abs(muestra.Y) > AmplitudMaxima)
                {
                    AmplitudMaxima = Math.Abs(muestra.Y);

                }

            }

        }

        public void desplazarY(double factor)
        {
            foreach (Muestra muestra in Muestras)
            {
                muestra.Y += factor;  

            }
        }

        public void truncar(double umbral)
        {
            
            foreach (Muestra muestra in Muestras)
            {
                if (muestra.Y > umbral)
                {
                    muestra.Y = umbral;
                }
                else if (muestra.Y < (- 1 * umbral))
                {
                    muestra.Y = -1 * umbral;
                }

            }

        }

        //....................Suma de señales......................//
        public static Señal sumar(Señal sumando1, Señal sumando2)
        {
            SeñalPersonalizada resultado = new SeñalPersonalizada();
            resultado.TiempoInicial = sumando1.TiempoInicial;
            resultado.TiempoFinal = sumando1.TiempoFinal;
            resultado.FrecuenciaMuestreo = sumando1.FrecuenciaMuestreo;

            int indice = 0;
            foreach (Muestra muestra in sumando1.Muestras)
            {
                Muestra muestraResultado = new Muestra();
                muestraResultado.X = muestra.X;
                muestraResultado.Y = muestra.Y + sumando2.Muestras[indice].Y;
                indice++;
                resultado.Muestras.Add(muestraResultado);
            }



            return resultado;
        }
        public static Señal multiplicar(Señal multiplica1, Señal multiplica2)
        {
            SeñalPersonalizada resultado = new SeñalPersonalizada();
            resultado.TiempoInicial = multiplica1.TiempoInicial;
            resultado.TiempoFinal = multiplica1.TiempoFinal;
            resultado.FrecuenciaMuestreo = multiplica1.FrecuenciaMuestreo;

            int indice = 0;
            foreach (Muestra muestra in multiplica1.Muestras)
            {
                Muestra muestraResultado = new Muestra();
                muestraResultado.X = muestra.X;
                muestraResultado.Y = muestra.Y * multiplica2.Muestras[indice].Y;
                indice++;
                resultado.Muestras.Add(muestraResultado);
            }



            return resultado;
        }
        }

}
