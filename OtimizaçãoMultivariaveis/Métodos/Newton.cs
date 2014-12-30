using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{
    class Newton
    {
        Funcoes funcClasse;
        double e = 0.0001;
        double norma = 1;
        Double[] gradiente;
        Double[] g;
        Double[] d = new Double[2];
        //Double[] x = new Double[2];
        Double[,] inversaHessiana = new Double[2, 2];


        public Newton(Funcoes func)
        {
            funcClasse = func;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Double[] Calcula(Double[] xInicial)
        {
            Double[] b = new Double[2];
            b = xInicial;

            while (norma > e)
            {
                g = Gradiente(b[0], b[1]);
                inversaHessiana = funcClasse.InversaHessiana(b);
                d[0] = -1 * (inversaHessiana[0, 0] * g[0] + inversaHessiana[0, 1] * g[1]);
                d[1] = -1 * (inversaHessiana[1, 0] * g[0] + inversaHessiana[1, 1] * g[1]);
                b[0] = b[0] + d[0];
                b[1] = b[1] + d[1];

                norma = calculaNorma(g);
                Console.WriteLine(norma);
            }

            return b;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Double[] Gradiente(Double a, Double b)
        {
            Double[] grad = new Double[2];
            Double[] aux = new Double[2];
            aux[0] = a;
            aux[1] = b;
            grad[0] = funcClasse.DerivadaParcialX1(aux);
            grad[1] = funcClasse.DerivadaParcialX2(aux);
            return grad;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        double calculaNorma(Double[] x)
        {
            return Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2));
        }
    }
}
