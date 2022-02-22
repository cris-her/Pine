
namespace PruebaC
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
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.btnPortafolio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTicker = new System.Windows.Forms.TextBox();
            this.btnCotizacion = new System.Windows.Forms.Button();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.btnPanelMerval = new System.Windows.Forms.Button();
            this.btnCedears = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSalida
            // 
            this.txtSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalida.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalida.Location = new System.Drawing.Point(170, 30);
            this.txtSalida.Multiline = true;
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.Size = new System.Drawing.Size(618, 277);
            this.txtSalida.TabIndex = 3;
            // 
            // btnPortafolio
            // 
            this.btnPortafolio.Location = new System.Drawing.Point(13, 27);
            this.btnPortafolio.Name = "btnPortafolio";
            this.btnPortafolio.Size = new System.Drawing.Size(95, 23);
            this.btnPortafolio.TabIndex = 2;
            this.btnPortafolio.Text = "Portafolio";
            this.btnPortafolio.UseVisualStyleBackColor = true;
            this.btnPortafolio.Click += new System.EventHandler(this.btnPortafolio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ticker";
            // 
            // txtTicker
            // 
            this.txtTicker.Location = new System.Drawing.Point(56, 62);
            this.txtTicker.Name = "txtTicker";
            this.txtTicker.Size = new System.Drawing.Size(75, 20);
            this.txtTicker.TabIndex = 5;
            // 
            // btnCotizacion
            // 
            this.btnCotizacion.Location = new System.Drawing.Point(56, 88);
            this.btnCotizacion.Name = "btnCotizacion";
            this.btnCotizacion.Size = new System.Drawing.Size(75, 23);
            this.btnCotizacion.TabIndex = 6;
            this.btnCotizacion.Text = "Cotizacion";
            this.btnCotizacion.UseVisualStyleBackColor = true;
            // 
            // btnOpciones
            // 
            this.btnOpciones.Location = new System.Drawing.Point(56, 117);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(75, 23);
            this.btnOpciones.TabIndex = 7;
            this.btnOpciones.Text = "Opciones";
            this.btnOpciones.UseVisualStyleBackColor = true;
            // 
            // btnPanelMerval
            // 
            this.btnPanelMerval.Location = new System.Drawing.Point(15, 146);
            this.btnPanelMerval.Name = "btnPanelMerval";
            this.btnPanelMerval.Size = new System.Drawing.Size(75, 23);
            this.btnPanelMerval.TabIndex = 8;
            this.btnPanelMerval.Text = "Merval";
            this.btnPanelMerval.UseVisualStyleBackColor = true;
            // 
            // btnCedears
            // 
            this.btnCedears.Location = new System.Drawing.Point(15, 175);
            this.btnCedears.Name = "btnCedears";
            this.btnCedears.Size = new System.Drawing.Size(75, 23);
            this.btnCedears.TabIndex = 9;
            this.btnCedears.Text = "CEDEARs";
            this.btnCedears.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCedears);
            this.Controls.Add(this.btnPanelMerval);
            this.Controls.Add(this.btnOpciones);
            this.Controls.Add(this.btnCotizacion);
            this.Controls.Add(this.txtTicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.btnPortafolio);
            this.Name = "Form1";
            this.Text = "Prueba C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtSalida;
        internal System.Windows.Forms.Button btnPortafolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTicker;
        private System.Windows.Forms.Button btnCotizacion;
        private System.Windows.Forms.Button btnOpciones;
        private System.Windows.Forms.Button btnPanelMerval;
        private System.Windows.Forms.Button btnCedears;
    }
}

