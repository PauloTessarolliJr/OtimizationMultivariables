using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{    
    class HookeJeeves
    {
        Funcoes func;
        double e = 0.001;
        Double[] diferencaX = new Double[2];
        Double[] x = new Double[2];
        Double[] y = new Double[2];
        Double[] direcao = new Double[2];
        int j;
        int k = 0;
        string funcao;
        Lambda lambdaValor = new Lambda();



        public HookeJeeves(string funcao)
        {
            this.funcao = funcao;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Double[] Calcula(Double[] xInicial)
        {
            x = xInicial;
            do
            {
                k++;
                y = x;
                for (j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        direcao[0] = 1;
                        direcao[1] = 0;
                    }
                    else
                    {
                        direcao[0] = 0;
                        direcao[1] = 1;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        x[i] = y[i] + lambda() * direcao[i];                       
                    }
                    //Console.WriteLine(x[0] + " -- " + x[1]);
                    //Console.WriteLine(y[0] + " -- " + y[1]);
                }
                diferencaX[0] = x[0] - y[0];
                diferencaX[1] = x[1] - y[1];
                if(calculaNorma(diferencaX) > e)
                {
                    direcao = diferencaX;
                    y = x;
                    for (int i = 0; i < 2; i++)
                    {
                        x[i] = y[i] + lambda() * direcao[i];
                    }
                    diferencaX[0] = x[0] - y[0];
                    diferencaX[1] = x[1] - y[1];                   
                }
                //Console.WriteLine(x[0] + " -- " + x[1]);
                //Console.WriteLine(y[0] + " -- " + y[1]);
                //Console.WriteLine(calculaNorma(diferencaX));
                //Console.ReadKey();
            } while (lambda() > e);

            return x;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        double calculaNorma(Double[] x)
        {
            return Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        double lambda()
        {
            return lambdaValor.GeraLambda(x, direcao, funcao);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
