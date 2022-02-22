using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API_InvertirOnLine;

namespace PruebaC
{
    public partial class Form1 : Form
    {
        API_IOL API;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            API = new API_IOL(configuracion.Usuario, configuracion.Clave, Application.StartupPath);
        }

        private void btnPortafolio_Click(object sender, EventArgs e)
        {
            API_IOL.Portafolio porta = API.ObtenerPortafolio();
            if (porta != null)
                txtSalida.Text = porta.ToString();
        }


    }
}
