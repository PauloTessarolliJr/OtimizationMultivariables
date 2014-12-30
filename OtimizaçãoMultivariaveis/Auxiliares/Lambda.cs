using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtimizaçãoMultivariaveis
{
    class Lambda
    {
        const double e = 0.000001;
        string fxAux;
        string x;
        string y;
        public string GeraExpLambda(string fx, double y1, double y2, double d1, double d2)
        {
            string l1 = "("+ Math.Round(y1,4).ToString() + "+" + d1.ToString() + "*x)";
            string l2 = "(" + Math.Round(y2, 4).ToString() + "+" + d2.ToString() + "*x)";

            fxAux = fx;

            x = fxAux.Replace("x", l1);
            y = x.Replace("y", l2);

            //System.Windows.Forms.MessageBox.Show(y);

            return y;
        }

        public double Minimiza(string fx, double ponto)
        {
            BuscaBissecao b = new BuscaBissecao(fx);
            double minimiza = b.Calcula(-5,5,0.001);
            Console.WriteLine("Lambda: "+minimiza);
            return minimiza;
        }
        public double Minimiza2(string fx, double ponto)
        {
            BuscaNewton b = new BuscaNewton(fx);
            return b.Calcula(2,0.001);
        }
        
        public double GeraLambda(Double[] y, Double[] d, string funcao)
        {
            string expressaoLambda;
            expressaoLambda = GeraExpLambda(funcao, y[0], y[1], d[0], d[1]);
            return Minimiza(expressaoLambda, -1);
        }
    }
}
