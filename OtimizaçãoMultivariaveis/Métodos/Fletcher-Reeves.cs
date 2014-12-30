using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{
    class Fletcher_Reeves
    {
        Funcoes funcClasse;
        double e = 0.0001;
        Double[] grad;
        Double[] newGrad;
        Double[] gradienteNovo;
        Double[] d = new Double[2];
        Double[] x = new Double[2];
        Double[] xNovo = new Double[2];
        Double norma = 1;
        double normaOld;
        string funcao;
        Lambda lambdaValor = new Lambda();
        Double lambdaAux;
        double betaAux;
        int counter = 0;

        public Fletcher_Reeves(string funcao, Funcoes func)
        {
            this.funcao = funcao;
            funcClasse = func;
        }

        public Double[] Calcula(Double[] xInicial)
        {
            Double[] xValor = xInicial;
            x = xInicial;
            while (norma > e)
            {
                Console.WriteLine("Xk: [" + xValor[0] + ", " + xValor[1] + "]");
                for (int j = 0; j < 2; j++)
                {
                    if (norma >= normaOld && counter > 0)
                        return x;

                    grad = funcClasse.CalculaGradiente(xValor);

                    d[0] = -grad[0];
                    d[1] = -grad[1];

                    lambdaAux = lambda();

                    for (int i = 0; i < 2; i++)
                    {
                        x[i] = x[i] + lambdaAux * d[i];
                    }
                    Console.WriteLine("Xk: [" + x[0] + ", " + x[1] + "]");
                    if (j < 1)
                    {
                        newGrad = funcClasse.CalculaGradiente(x);
                        betaAux = beta(newGrad[0], newGrad[1], grad[0], grad[1]);
                        d[0] = -newGrad[0] + betaAux;
                        d[1] = -newGrad[1] + betaAux;
                        lambdaAux = lambda();
                        for (int l = 0; l < 2; l++)
                        {
                            x[l] = x[l] + lambdaAux * d[l];
                        }
                    }

                    norma = calculaNorma(grad);
                    Console.WriteLine("Norma: " + norma);
                    xValor = x;
                    normaOld = norma;
                    counter++;
                }
            }

            return x;
        }




        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        double calculaNorma(Double[] x)
        {
            return Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Double[] Gradiente(Double[] x)
        {
            Double[] gradiente;
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

        double beta(Double a, Double b, Double c, Double d)
        {
            return ((a * a + b * b) / (c * c + d * d));
        }
    }
}
