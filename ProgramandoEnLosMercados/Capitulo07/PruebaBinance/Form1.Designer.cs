namespace PruebaBinance
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.bntRegla = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPar = new System.Windows.Forms.TextBox();
            this.btnTenencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Puntas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Onbutton1_Click);
            // 
            // txtSalida
            // 
            this.txtSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalida.Location = new System.Drawing.Point(202, 12);
            this.txtSalida.Multiline = true;
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSalida.Size = new System.Drawing.Size(451, 264);
            this.txtSalida.TabIndex = 1;
            // 
            // bntRegla
            // 
            this.bntRegla.Location = new System.Drawing.Point(12, 12);
            this.bntRegla.Name = "bntRegla";
            this.bntRegla.Size = new System.Drawing.Size(163, 23);
            this.bntRegla.TabIndex = 2;
            this.bntRegla.Text = "Obtener Toidas las reglas";
            this.bntRegla.UseVisualStyleBackColor = true;
            this.bntRegla.Click += new System.EventHandler(this.OnbtnRegla_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Reglas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Onbutton2_Click);
            // 
            // txtPar
            // 
            this.txtPar.Location = new System.Drawing.Point(93, 44);
            this.txtPar.Name = "txtPar";
            this.txtPar.Size = new System.Drawing.Size(82, 20);
            this.txtPar.TabIndex = 4;
            this.txtPar.Text = "BTCUSDT";
            // 
            // btnTenencia
            // 
            this.btnTenencia.Location = new System.Drawing.Point(12, 81);
            this.btnTenencia.Name = "btnTenencia";
            this.btnTenencia.Size = new System.Drawing.Size(75, 23);
            this.btnTenencia.TabIndex = 5;
            this.btnTenencia.Text = "Tenencia";
            this.btnTenencia.UseVisualStyleBackColor = true;
            this.btnTenencia.Click += new System.EventHandler(this.OnbtnTenencia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 288);
            this.Controls.Add(this.btnTenencia);
            this.Controls.Add(this.txtPar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bntRegla);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.Button bntRegla;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPar;
        private System.Windows.Forms.Button btnTenencia;
    }
}

