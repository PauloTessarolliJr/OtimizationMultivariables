using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{
    class CoordenadaCiclica
    {
        //Funcoes func;
        double e = 0.0001;
        string funcao;
        Double[] x =  new Double[2];
        Double[] y =  new Double[2];
        Double[] direcao =  new Double[2];
        Lambda lambdaValor = new Lambda();
        int j;
        int k = 0;

        
        public CoordenadaCiclica(string funcao)
        {
            this.funcao = funcao;
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                        x[i] = y[i] + lambda(j) * direcao[i];
                    }
                    //Console.WriteLine("X1: " + x[0] + " X2: " + x[1]);
                }
                
            } while (lambda(j) > e);

            return x;
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////
    double calculaNorma(Double[] x)
    {
        return Math.Sqrt(Math.Pow(x[0],2) + Math.Pow(x[1],2));
    }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public double lambda(int i)
    {
        return lambdaValor.GeraLambda(x, direcao, funcao);
    }





    }
}