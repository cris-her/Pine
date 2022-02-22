using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API_Binance;

namespace PruebaBinance
{
    public partial class Form1 : Form
    {
        readonly Spot API = null;
        public Form1()
        {
            InitializeComponent();
            API = new Spot( Application.StartupPath) ;
        }

        private void Onbutton1_Click(object sender, EventArgs e)
        {
            string puntas = API.Precios.ObtenerPuntas("ETHUSDT", 20);
            txtSalida.Text = puntas;             
            
        }

        private void OnbtnRegla_Click(object sender, EventArgs e)
        {
            ClasesBinance.Reglas Reglas = API.Consultas.ObtenerRelgas();
            ClasesBinance.Simbolo ethusdt = Reglas.ObtenerSimbolo("ETHUSDT");

            txtSalida.Text = "Cantidad de decimales en el precio:" + ethusdt.CantidadDecimalesPrecioMinimo.ToString() ;
            txtSalida.Text += "\r\nCantidad de decimales en la cantidad:" + ethusdt.CantidadDecimalesCantidadMinima.ToString();
            txtSalida.Text += "\r\nMoneda Base:" + ethusdt.MonedaBase;

        }

        private void Onbutton2_Click(object sender, EventArgs e)
        {
            ClasesBinance.Simbolo ethusdt = API.Reglas.ObtenerSimbolo(txtPar.Text);
            if (ethusdt != null)
            {
                txtSalida.Text = "Cantidad de decimales en el precio:" + ethusdt.CantidadDecimalesPrecioMinimo.ToString();
                txtSalida.Text += "\r\nCantidad de decimales en la cantidad:" + ethusdt.CantidadDecimalesCantidadMinima.ToString();
                txtSalida.Text += "\r\nMoneda Base:" + ethusdt.MonedaBase;
            }
            else {
                txtSalida.Text = "No se encontro el par de monedas, o todavía nunca ejecutó obtener todas las reglas desde Binance";
            }
        }

        private void OnbtnTenencia_Click(object sender, EventArgs e)
        {
            ClasesBinance.Tenencias tenencia = API.Consultas.ObteneTenencia();
            txtSalida.Text = "TENENCIAS:";
            txtSalida.Text += "\r\n----------";

            foreach ( ClasesBinance.Balance b in tenencia.Monedas)
            {
                txtSalida.Text += "\r\nMoneda:" + b.NombreMoneda  +  " : " + b.Disponible.ToString();
            }

        }
    }
}
