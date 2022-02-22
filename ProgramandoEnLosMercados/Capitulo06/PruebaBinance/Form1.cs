using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API_Binance.Binance;

namespace PruebaBinance
{
    public partial class Form1 : Form
    {

        API_Binance.Binance.API_Binance API = null;
        public Form1()
        {
            InitializeComponent();
            API = new API_Binance.Binance.API_Binance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string puntas = API.ObtenerPuntas("ETHUSDT", 20);
            txtSalida.Text = puntas;

        }
    }
}
