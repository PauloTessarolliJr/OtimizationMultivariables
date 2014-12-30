using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using YAMP;
namespace OtimizaçãoMultivariaveis
{
    class BuscaBissecao
    {
        private NumberStyles style;
        private CultureInfo culture;
        private Parser p;
        private string func,funcaoNova;
        private double valorX, valorDerivada;
        DerivadaPrimeira d1;


        public BuscaBissecao(string func)
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

        public double Calcula(double a, double b, double l)
        {
            while ((b - a) > l)
            {
                valorX = (a + b) / 2;
                funcaoNova = this.func.Replace(",", ".");
                d1 = new DerivadaPrimeira(funcaoNova);
                valorDerivada = d1.Calcula(valorX);
                if (valorDerivada < 0)
                {
                    a = valorX;
                }
                if (valorDerivada > 0)
                {
                    b = valorX;
                }
                if (valorDerivada == 0)
                {
                    return valorX;
                }
            }
            return valorX;

        }
    }
}
