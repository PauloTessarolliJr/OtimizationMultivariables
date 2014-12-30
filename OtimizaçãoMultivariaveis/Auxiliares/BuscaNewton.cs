using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using YAMP;

namespace OtimizaçãoMultivariaveis
{

    class BuscaNewton
    {
        private NumberStyles style;
        private CultureInfo culture;
        private Parser p;
        private string func;
        private double valorX, valorDerivada1, valorXAnterior, valorDerivada2;
        DerivadaPrimeira d1;
        DerivadaSegunda d2;

        public BuscaNewton(string func)
        {
            this.func = func;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("en-GB");
            this.tryParse(this.func);
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

        public double Calcula(double a, double e)
        {
            valorX = a;
            while (true)
            {
                d1 = new DerivadaPrimeira(this.func);
                valorDerivada1 = d1.Calcula(valorX);
                
                //Console.WriteLine("VALORD1: " + valorDerivada1);
                if (Math.Abs(valorDerivada1) < e)
                {
                    //Console.WriteLine("VALORXantes: " + valorX);
                    break;
                    //return valorX;
                }
                d2 = new DerivadaSegunda(this.func);
                valorDerivada2 = d2.Calcula(valorX);
                valorXAnterior = valorX;
                //Console.WriteLine("VALORXant: " + valorXAnterior);
                valorX = valorXAnterior - valorDerivada1 / valorDerivada2;
                //Console.WriteLine("VALORX2: " + valorX);
                //Console.WriteLine("VALORD2: " + valorDerivada2);
                //Console.WriteLine("VALORX: " + valorX);
                
                if((valorX - valorXAnterior)/Math.Max(1,valorX) < e)
                {
                    //Console.WriteLine("VALORX: " + valorX);
                    break;
                    //return valorX;
                }
 
            }
            return valorX;

        }
    }
}
