namespace OtimizaçãoMultivariaveis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbFx = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbDFP = new System.Windows.Forms.RadioButton();
            this.rdbHJ = new System.Windows.Forms.RadioButton();
            this.rdbFR = new System.Windows.Forms.RadioButton();
            this.rdbNewton = new System.Windows.Forms.RadioButton();
            this.rdbCic = new System.Windows.Forms.RadioButton();
            this.rdbGrad = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.x1Box = new System.Windows.Forms.TextBox();
            this.x2Box = new System.Windows.Forms.TextBox();
            this.btnCalcula = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbFx);
            this.groupBox1.Location = new System.Drawing.Point(43, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(238, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funções";
            // 
            // txbFx
            // 
            this.txbFx.Location = new System.Drawing.Point(5, 23);
            this.txbFx.Name = "txbFx";
            this.txbFx.Size = new System.Drawing.Size(228, 20);
            this.txbFx.TabIndex = 0;
            this.txbFx.TextChanged += new System.EventHandler(this.txbFx_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rdbDFP);
            this.groupBox2.Controls.Add(this.rdbHJ);
            this.groupBox2.Controls.Add(this.rdbFR);
            this.groupBox2.Controls.Add(this.rdbNewton);
            this.groupBox2.Controls.Add(this.rdbCic);
            this.groupBox2.Controls.Add(this.rdbGrad);
            this.groupBox2.Location = new System.Drawing.Point(9, 63);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(307, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Métodos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Com Derivadas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sem Derivadas:";
            // 
            // rdbDFP
            // 
            this.rdbDFP.AutoSize = true;
            this.rdbDFP.Location = new System.Drawing.Point(146, 106);
            this.rdbDFP.Margin = new System.Windows.Forms.Padding(2);
            this.rdbDFP.Name = "rdbDFP";
            this.rdbDFP.Size = new System.Drawing.Size(140, 17);
            this.rdbDFP.TabIndex = 3;
            this.rdbDFP.TabStop = true;
            this.rdbDFP.Text = "Davidon-Fletcher-Powell";
            this.rdbDFP.UseVisualStyleBackColor = true;
            // 
            // rdbHJ
            // 
            this.rdbHJ.AutoSize = true;
            this.rdbHJ.Location = new System.Drawing.Point(7, 61);
            this.rdbHJ.Margin = new System.Windows.Forms.Padding(2);
            this.rdbHJ.Name = "rdbHJ";
            this.rdbHJ.Size = new System.Drawing.Size(94, 17);
            this.rdbHJ.TabIndex = 1;
            this.rdbHJ.TabStop = true;
            this.rdbHJ.Text = "Hooke-Jeeves";
            this.rdbHJ.UseVisualStyleBackColor = true;
            // 
            // rdbFR
            // 
            this.rdbFR.AutoSize = true;
            this.rdbFR.Location = new System.Drawing.Point(146, 83);
            this.rdbFR.Margin = new System.Windows.Forms.Padding(2);
            this.rdbFR.Name = "rdbFR";
            this.rdbFR.Size = new System.Drawing.Size(103, 17);
            this.rdbFR.TabIndex = 2;
            this.rdbFR.TabStop = true;
            this.rdbFR.Text = "Fletcher-Reeves";
            this.rdbFR.UseVisualStyleBackColor = true;
            // 
            // rdbNewton
            // 
            this.rdbNewton.AutoSize = true;
            this.rdbNewton.Location = new System.Drawing.Point(147, 61);
            this.rdbNewton.Margin = new System.Windows.Forms.Padding(2);
            this.rdbNewton.Name = "rdbNewton";
            this.rdbNewton.Size = new System.Drawing.Size(62, 17);
            this.rdbNewton.TabIndex = 1;
            this.rdbNewton.TabStop = true;
            this.rdbNewton.Text = "Newton";
            this.rdbNewton.UseVisualStyleBackColor = true;
            // 
            // rdbCic
            // 
            this.rdbCic.AutoSize = true;
            this.rdbCic.Location = new System.Drawing.Point(7, 38);
            this.rdbCic.Margin = new System.Windows.Forms.Padding(2);
            this.rdbCic.Name = "rdbCic";
            this.rdbCic.Size = new System.Drawing.Size(129, 17);
            this.rdbCic.TabIndex = 0;
            this.rdbCic.TabStop = true;
            this.rdbCic.Text = "Coordenadas Cíclicas";
            this.rdbCic.UseVisualStyleBackColor = true;
            // 
            // rdbGrad
            // 
            this.rdbGrad.AutoSize = true;
            this.rdbGrad.Location = new System.Drawing.Point(147, 38);
            this.rdbGrad.Margin = new System.Windows.Forms.Padding(2);
            this.rdbGrad.Name = "rdbGrad";
            this.rdbGrad.Size = new System.Drawing.Size(71, 17);
            this.rdbGrad.TabIndex = 0;
            this.rdbGrad.TabStop = true;
            this.rdbGrad.Text = "Gradiente";
            this.rdbGrad.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "x1:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "x2:";
            // 
            // x1Box
            // 
            this.x1Box.Location = new System.Drawing.Point(32, 208);
            this.x1Box.Margin = new System.Windows.Forms.Padding(2);
            this.x1Box.Name = "x1Box";
            this.x1Box.Size = new System.Drawing.Size(33, 20);
            this.x1Box.TabIndex = 4;
            // 
            // x2Box
            // 
            this.x2Box.Location = new System.Drawing.Point(32, 232);
            this.x2Box.Margin = new System.Windows.Forms.Padding(2);
            this.x2Box.Name = "x2Box";
            this.x2Box.Size = new System.Drawing.Size(33, 20);
            this.x2Box.TabIndex = 5;
            // 
            // btnCalcula
            // 
            this.btnCalcula.Location = new System.Drawing.Point(157, 310);
            this.btnCalcula.Name = "btnCalcula";
            this.btnCalcula.Size = new System.Drawing.Size(156, 43);
            this.btnCalcula.TabIndex = 6;
            this.btnCalcula.Text = "Calcular";
            this.btnCalcula.UseVisualStyleBackColor = true;
            this.btnCalcula.Click += new System.EventHandler(this.btnCalcula_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 365);
            this.Controls.Add(this.btnCalcula);
            this.Controls.Add(this.x2Box);
            this.Controls.Add(this.x1Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "7";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbHJ;
        private System.Windows.Forms.RadioButton rdbCic;
        private System.Windows.Forms.RadioButton rdbDFP;
        private System.Windows.Forms.RadioButton rdbFR;
        private System.Windows.Forms.RadioButton rdbNewton;
        private System.Windows.Forms.RadioButton rdbGrad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox x1Box;
        private System.Windows.Forms.TextBox x2Box;
        private System.Windows.Forms.Button btnCalcula;
        private System.Windows.Forms.TextBox txbFx;
    }
}

