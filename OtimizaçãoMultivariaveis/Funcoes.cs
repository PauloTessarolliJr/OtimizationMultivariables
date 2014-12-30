using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using YAMP;

namespace OtimizaçãoMultivariaveis
{
    class Funcoes
    {

        private NumberStyles style;
        private CultureInfo culture;
        private Parser p;
        double resultado;

        double h, epson, xi, xj, d1, d2, f1, f2, f3, f4;
        string funcao;

        public Funcoes(string func)
        {
            funcao = func;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("en-GB");
            this.tryParse(funcao);
        }

        private bool tryParse(string func)
        {
            try
            {
                p = Parser.Parse(func);
                return true;
            }
            catch
            {
                return false;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public double CalculaFuncao(double x1, double x2)
        {
            Parser.AddCustomConstant("x", x1);
            Parser.AddCustomConstant("y", x2);

            double.TryParse(p.Execute().ToString(), style, culture, out resultado);
            return resultado;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public Double[] CalculaGradiente(Double[] x)
        {
            Double[] d = new Double[2];
            d[0] = DerivadaParcialX1(x);
            d[1] = DerivadaParcialX2(x);
            Console.WriteLine("Gradiente: [" + d[0] + ", " + d[1] + "]");
            return d;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public double Derivada(double x1, double x2)
        {
            double h = 0.2f;
            double precisao = 0.001;
            double valor = x1 + h;
            double auxAtual = (CalculaFuncao(x1,x2) - CalculaFuncao(x1-h,x2-h)) / (2 * h);
            double auxAnterior = auxAtual;
            double erroAnterior = 1000;
            double erroAtual = 0;
            int contador = 0;

            do
            {
                erroAnterior = erroAtual;
                auxAnterior = auxAtual;

                h = h / 2;
                auxAtual = (CalculaFuncao(x1,x2) - CalculaFuncao(x1-h,x2-h)) / (2 * h);

                if (1 > auxAtual)
                    erroAtual = (auxAtual - auxAnterior);
                else
                    erroAtual = (auxAtual - auxAnterior) / auxAtual;

                contador++;
            } while (Math.Abs(erroAtual) > precisao && Math.Abs(erroAnterior) < Math.Abs(erroAtual));

            return auxAtual;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public double DerivadaParcialX1(Double[] x)
        {
            h = 1;
            epson = 0.001;
            d1 = 0;
            xi = x[0];
            do
            {
                d1 = d2;

                x[0] = xi + h;
                f1 = CalculaFuncao(x[0], x[1]);

                x[0] = xi - h;
                f2 = CalculaFuncao(x[0], x[1]);

                d2 = (f1 - f2) / (2 * h);

                h = h / 2;
                
            } while (Math.Abs(d2 - d1) > epson);

            return d2;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public double DerivadaParcialX2(Double[] x)
        {
            h = 1;
            epson = 0.001;
            d1 = 0;
            xi = x[1];
            do
            {
                d1 = d2;

                x[1] = xi + h;
                f1 = CalculaFuncao(x[0], x[1]);

                x[1] = xi - h;
                f2 = CalculaFuncao(x[0], x[1]);

                d2 = (f1 - f2) / (2 * h);

                h = h / 2;

            } while (Math.Abs(d2 - d1) > epson);

            return d2;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public double DerivadaParcialSegundaOrdem(Double[] x, int i, int j)
        {
            double comp, compOld = 0;
            int k = 0;
            h = 1;
            epson = 0.001;
            d1 = 0;
            while (true)
            {
                x[i] = x[i] + h;
                x[j] = x[j] + h;
                f1 = CalculaFuncao(x[0], x[1]);

                x[i] = x[i] - 2 * h;
                f2 = CalculaFuncao(x[0], x[1]);

                x[j] = x[j] - 2 * h;
                f3 = CalculaFuncao(x[0], x[1]);

                x[i] = x[i] + 2 * h;
                f4 = CalculaFuncao(x[0], x[1]);

                d2 = (f1 - f2 + f3 - f4) / (4 * h * h);
                x[i] = x[i] - h;
                x[j] = x[j] + h;

                comp = Math.Abs(d2 - d1);

                if (comp < epson)
                {
                    break;
                }

                if (comp >= compOld && k > 0)
                {
                    break;
                }

                compOld = comp;
                d1 = d2;
                h = h / 2;
                k++;
            }
            return d2;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Double[,] Hessiana(Double[] x)
        {
            Double[,] valorHessiana = new Double[2, 2];
            valorHessiana[0, 0] = DerivadaParcialSegundaOrdem(x, 0, 0);
            valorHessiana[0, 1] = DerivadaParcialSegundaOrdem(x, 0, 1);
            valorHessiana[1, 0] = DerivadaParcialSegundaOrdem(x, 1, 0);
            valorHessiana[1, 1] = DerivadaParcialSegundaOrdem(x, 1, 1);
            return valorHessiana;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public double calculaDeterminante(Double[,] matriz)
        {
            return ((matriz[0, 0] * matriz[1, 1]) - (matriz[0, 1] * matriz[1, 0]));
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Double[,] InversaHessiana(Double[] x)
        {
            Double[,] matriz = Hessiana(x);
            double inverte, det;
            det = calculaDeterminante(matriz);
            inverte = matriz[0, 0];
            matriz[0, 0] = matriz[1, 1] / det;
            matriz[1, 1] = inverte / det;
            matriz[1, 0] = -matriz[1, 0] / det;
            matriz[0, 1] = -matriz[0, 1] / det;

            return matriz;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
