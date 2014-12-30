using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using YAMP;

namespace OtimizaçãoMultivariaveis
{
    class DerivadaPrimeira
    {
        private readonly double e = 0.001;
        private readonly int diminui = 2;
        private NumberStyles style;
        private CultureInfo culture;
        private Parser p;
        private int contador;
        private string func;
        private double erro;
        private double h;

        private double maisH, menosH;
        private double valorAtual, valorAnterior;

        public DerivadaPrimeira(string func)
        {
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("en-GB");
            this.func = func;
            this.h = 0.1f;
            this.contador = 0;
            this.erro = 1;
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

        public double Calcula(double valor)
        {
            
            this.valorAnterior = this.valorAtual;
            Parser.AddCustomConstant("x", (valor + this.h));
            double.TryParse(p.Execute().ToString(), style, culture, out maisH);
            Parser.AddCustomConstant("x", (valor - this.h));
            double.TryParse(p.Execute().ToString(), style, culture, out menosH);
            valorAtual = (maisH - menosH) / (2 * this.h);
                
            return valorAtual;
        }

    }
}
