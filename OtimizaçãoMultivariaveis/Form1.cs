using OtimizaçãoMultivariaveis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YAMP;

namespace OtimizaçãoMultivariaveis
{
    public partial class Form1 : Form
    {
        public static int funcao;
        Double[] x = new double[2];
        Double[] teste = new double[2];
        string fx;

        Funcoes funcaoClasse;

        Lambda l = new Lambda();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcula_Click(object sender, EventArgs e)
        {

            double.TryParse(x1Box.Text, out x[0]);
            double.TryParse(x2Box.Text, out x[1]);
            fx = txbFx.Text;
            funcaoClasse = new Funcoes(fx);
            //teste[0] = 0;
            //teste[1] = 3;
            //Console.WriteLine(funcaoClasse.CalculaFuncao(teste[0], teste[1]));
            //Console.WriteLine(funcaoClasse.CalculaGradiente(teste)[1]);
            //Console.WriteLine(funcaoClasse.CalculaGradiente(teste)[0]);
            if (rdbCic.Checked)
            {
                CoordenadaCiclica c = new CoordenadaCiclica(fx);
                MessageBox.Show("[" + c.Calcula(x)[0].ToString() + ", " + c.Calcula(x)[1].ToString()+"]");
            }
            if (rdbHJ.Checked)
            {
                HookeJeeves h = new HookeJeeves(fx);
                MessageBox.Show("[" + h.Calcula(x)[0].ToString() + ", " + h.Calcula(x)[1].ToString() + "]");
            }
            if (rdbGrad.Checked)
            {
                Gradiente g = new Gradiente(fx, funcaoClasse);
                MessageBox.Show("[" + g.Calcula(x)[0].ToString() + ", " + g.Calcula(x)[1].ToString() + "]");
            }
            if (rdbNewton.Checked)
            {
                Newton n = new Newton(funcaoClasse);
                MessageBox.Show("[" + n.Calcula(x)[0].ToString() + ", " + n.Calcula(x)[1].ToString() + "]");
            }
            if (rdbFR.Checked)
            {
                Fletcher_Reeves f = new Fletcher_Reeves(fx, funcaoClasse);
                MessageBox.Show("[" + f.Calcula(x)[0].ToString() + ", " + f.Calcula(x)[1].ToString() + "]");
            }
            if (rdbDFP.Checked)
            {
                Davidon_Fletcher_Powell d = new Davidon_Fletcher_Powell(fx, funcaoClasse);
                MessageBox.Show("[" + d.Calcula(x)[0].ToString() + ", " + d.Calcula(x)[1].ToString() + "]");
            }
        }

        private void txbFx_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
