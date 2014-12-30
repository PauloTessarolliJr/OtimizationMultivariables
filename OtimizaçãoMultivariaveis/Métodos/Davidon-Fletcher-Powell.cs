using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{
    class Davidon_Fletcher_Powell
    {
        Funcoes funcClasse;
        string funcao;
        double e = 0.0001;
        Double[,] matriz = new Double[2,2];
        Double[,] matrizNova = new Double[2,2];
        Double[] gradiente;
        Double[] gradienteNovo;
        Double[] d = new Double[2];
        Double[] x = new Double[2];
        Double[] xNovo = new Double[2];
        double ponto;
        Lambda lambdaValor = new Lambda();


        public Davidon_Fletcher_Powell(string funcao, Funcoes func)
        {
            this.funcao = funcao;
            funcClasse = func;
        }


        public Double[] Calcula(Double[] xInicial)
        {
            x = xInicial;
            gradiente = Gradiente(x);
            d = calculaDirecao();
            while (calculaNorma(Gradiente(x)) > e)
            {
                for (int k = 0; k < 2; k++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        xNovo[i] = x[i] + alfa() * d[i];
                    }
                    gradienteNovo = Gradiente(xNovo);

                    if (k < 1)
                    {
                        matriz = novaMatriz();
                        d = calculaDirecao();
                    }
                }
                x = xNovo;

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
        double alfa()
        {
            return lambdaValor.GeraLambda(x, d, funcao);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Double[,] novaMatriz()
        {
            Double[,] resultado = new Double[2,2];              //divisao 1 termo       //

            resultado[0, 0] = matriz[0, 0] + p()[0] * p()[0] / (p()[0] * q()[0] + p()[1] * q()[1]) - ((matriz[0, 0] * q()[0] + matriz[0,1]  * q()[1]) * q()[0] * matriz[0, 0]  + (matriz[0,0]  * q()[0] + matriz[0,1]  * q()[1]) * q()[1] * matriz[1, 0]) / (q()[0] * matriz[0, 0] + q()[1] * matriz[1, 0]) * q()[0] + (q()[0] * matriz[0, 1] + q()[1] * matriz[1, 1]) * q()[1];
            resultado[0, 1] = matriz[0, 1] + p()[0] * p()[1] / (p()[0] * q()[0] + p()[1] * q()[1]) - ((matriz[0, 0] * q()[0] + matriz[0, 1] * q()[1]) * q()[0] * matriz[0, 1] + (matriz[0, 0] * q()[0] + matriz[0, 1] * q()[1]) * q()[1] * matriz[1, 1]) / (q()[0] * matriz[0, 0] + q()[1] * matriz[1, 0]) * q()[0] + (q()[0] * matriz[0, 1] + q()[1] * matriz[1, 1]) * q()[1];
            resultado[1, 0] = matriz[1, 0] + p()[1] * p()[0] / (p()[0] * q()[0] + p()[1] * q()[1]) - ((matriz[1, 0] * q()[0] + matriz[1, 1] * q()[1]) * q()[0] * matriz[0, 0] + (matriz[1, 0] * q()[0] + matriz[1, 1] * q()[1]) * q()[1] * matriz[1, 0]) / (q()[0] * matriz[0, 0] + q()[1] * matriz[1, 0]) * q()[0] + (q()[0] * matriz[0, 1] + q()[1] * matriz[1, 1]) * q()[1];
            resultado[1, 1] = matriz[1, 1] + p()[1] * p()[1] / (p()[0] * q()[0] + p()[1] * q()[1]) - ((matriz[1, 0] * q()[0] + matriz[1, 1] * q()[1]) * q()[1] * matriz[0, 1] + (matriz[1, 0] * q()[0] + matriz[1, 1] * q()[1]) * q()[1] * matriz[1, 1]) / (q()[0] * matriz[0, 0] + q()[1] * matriz[1, 0]) * q()[0] + (q()[0] * matriz[0, 1] + q()[1] * matriz[1, 1]) * q()[1];

            return resultado;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Double[] p()
        {
            Double[] valor = new Double[2];
            valor[0] = alfa() * d[0];
            valor[1] = alfa() * d[1];
            return valor;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Double[] q()
        {
            Double[] valor = new Double[2];
            valor[0] = gradienteNovo[0] * gradiente[0];
            valor[1] = gradienteNovo[1] * gradiente[1];
            return valor;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Double[] calculaDirecao()
        {
            Double[] direcao = new Double[2];
            gradiente = Gradiente(x);
            direcao[0] = -(matriz[0, 0] * gradiente[0] + matriz[0, 1] * gradiente[1]);
            direcao[1] = -(matriz[1, 0] * gradiente[0] + matriz[1, 1] * gradiente[1]);

            return direcao;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
