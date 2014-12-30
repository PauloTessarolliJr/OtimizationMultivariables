using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{
    class Gradiente
    {
        Funcoes funcClasse;
        double e = 0.0001;
        Double[] gradiente;
        Double[] d = new Double[2];
        Double[] grad = new Double[2];
        Double[] x = new Double[2];
        Double norma = 1;
        double lambdaAux;
        double normaOld;
        string funcao;
        Lambda lambdaValor = new Lambda();


        public Gradiente(string funcao, Funcoes func)
        {
            this.funcao = funcao;
            funcClasse = func;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Double[] Calcula(Double[] xInicial)
        {
            Double[] xValor = xInicial;
            x = xInicial;
            while(norma > e)
            {
                Console.WriteLine("Xk: [" + xValor[0] + ", " + xValor[1] + "]");
                grad = funcClasse.CalculaGradiente(xValor);

                d[0] = -grad[0];
                d[1] = -grad[1];

                lambdaAux = lambda();

                for (int i = 0; i < 2; i++)
                {
                    x[i] = x[i] + lambdaAux * d[i];
                }

                norma = calculaNorma(grad);
                if (norma >= normaOld)
                    break;
                Console.WriteLine("Norma: " + norma);
                xValor = x;
                normaOld = norma;
            }

            return x;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        double calculaNorma(Double[] x)
        {
            return Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Double[] GradienteValor(Double[] x)
        {
            gradiente = new Double[2];
            gradiente[0] = funcClasse.DerivadaParcialX1(x);
            gradiente[1] = funcClasse.DerivadaParcialX2(x);
            return gradiente;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        double lambda()
        {
            return lambdaValor.GeraLambda(x, d, funcao);
        }
    }
}
