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
using API_Binance.ClasesAuxiliares;

namespace PruebaBinance
{
    public partial class Form1 : Form
    {
        readonly Queue<WebSocket.DatosEventos> ListaDeOperaciones = new Queue<WebSocket.DatosEventos>();
        readonly Queue<WebSocket.DatosEventosFuturos> ListaDeOperacionesFuturos = new Queue<WebSocket.DatosEventosFuturos>();

        readonly Spot SPT = null;
        readonly Futuro FUT = null;
        public Form1()
        {
            InitializeComponent();
            SPT = new Spot(Application.StartupPath) ;
            FUT = new Futuro(Application.StartupPath);

            SPT.Ordenes.OnNuevaOperacion += RecargarOperaciones;
            FUT.Ordenes.OnNuevaOperacion += RecargarOperacionesFuturos;
            tmActualizarPrecios.Start();
        }

        private void RecargarOperacionesFuturos(WebSocket.DatosEventosFuturos operacion)
        {
            ListaDeOperacionesFuturos.Enqueue(operacion);
        }

        private void RecargarOperaciones(WebSocket.DatosEventos operacion)
        {
            ListaDeOperaciones.Enqueue(operacion);
        }
        private void RecargarListaDeOperaciones()
        {
            if (ListaDeOperaciones.Count != 0)
            {
                WebSocket.DatosEventos operacion = ListaDeOperaciones.Dequeue();                
                ListViewItem i = lvOperaciones.Items.Add(operacion.Simbolo);
                i.SubItems.Add(operacion.Lado);
                i.SubItems.Add(operacion.TipoOrden);
                i.SubItems.Add(operacion.Novedad);
                i.SubItems.Add(operacion.Cantidad.ToString("0.00000"));
                i.SubItems.Add(operacion.Precio.ToString("0.00000"));           
            }
            if (ListaDeOperacionesFuturos.Count != 0)
            {
                WebSocket.DatosEventosFuturos operacion = ListaDeOperacionesFuturos.Dequeue();

                if(operacion.O != null){
                    ListViewItem i = lvOperaciones.Items.Add(operacion.Simbolo);
                    i.SubItems.Add(operacion.Lado);
                    i.SubItems.Add(operacion.TipoOperacion);
                    i.SubItems.Add(operacion.Novedad);
                    i.SubItems.Add(operacion.Cantidad.ToString("0.00000"));
                    i.SubItems.Add(operacion.Precio.ToString("0.00000"));
                }
            }


        }

        private void Onbutton1_Click(object sender, EventArgs e)
        {
            ClasesBinance.Puntas puntas = SPT.Precios.ObtenerPuntas(txtReglasParSpot.Text, 20);

            string s = "Compradores:\r\n";
            foreach( ClasesBinance.Punta p in puntas.Compradores)
            {
                s += "precio:" + p.Precio.ToString() + "  Cantidad:" + p.Cantidad.ToString() + "\r\n";
            }
            s += "Vendedores:\r\n";
            foreach (ClasesBinance.Punta p in puntas.Vendedores)
            {
                s += "precio:" + p.Precio.ToString() + "  Cantidad:" + p.Cantidad.ToString() + "\r\n";
            }

            txtSalida.Text = s;             
            
        }

        private void OnbtnRegla_Click(object sender, EventArgs e)
        {
            ClasesBinance.Reglas Reglas = SPT.Consultas.ObtenerRelgas();
            ClasesBinance.Simbolo ethusdt = Reglas.ObtenerSimbolo("ETHUSDT");

            txtSalida.Text = "Cantidad de decimales en el precio:" + ethusdt.CantidadDecimalesPrecioMinimo.ToString() ;
            txtSalida.Text += "\r\nCantidad de decimales en la cantidad:" + ethusdt.CantidadDecimalesCantidadMinima.ToString();
            txtSalida.Text += "\r\nMoneda Base:" + ethusdt.MonedaBase;

        }

        private void Onbutton2_Click(object sender, EventArgs e)
        {
            ClasesBinance.Simbolo ethusdt = SPT.Reglas.ObtenerSimbolo(txtReglasParSpot.Text);
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
            ClasesBinance.Tenencias tenencia = SPT.Consultas.ObtenerTenencia();
            txtSalida.Text = "TENENCIAS:" + tenencia.DescripcionError;
            txtSalida.Text += "\r\n----------";

            foreach ( ClasesBinance.Balance b in tenencia.Monedas)
            {
                txtSalida.Text += "\r\nMoneda:" + b.NombreMoneda  +  " : " + b.Disponible.ToString();
            }

        }

        private void BtnEndPoint_Click(object sender, EventArgs e)
        {
            if (!chkFuturo.Checked)
            {
                Dictionary<string, string> par = new Dictionary<string, string>();
                string[] s = txtParametro.Text.Split(',');
                if (s[0] != "") { 
                    foreach( string p in s)
                    {
                        string[] s2 = p.Split('=');
                        par.Add(s2[0], s2[1]);
                    }
                }

                txtSalida.Text = SPT.Consultas.ObtenerEndPoint(txtEndPoint.Text, cbxMetodo.Text, chkFirmar.Checked, chkEnviarKey.Checked, chkTimeStamp.Checked,par);  
            }
            else
            {

                Dictionary<string, string> par = new Dictionary<string, string>();
                string[] s = txtParametro.Text.Split(',');
                if (s[0] != "")
                {
                    foreach (string p in s)
                    {
                        string[] s2 = p.Split('=');
                        par.Add(s2[0], s2[1]);
                    }
                }


                txtSalida.Text = FUT.Consultas.ObtenerEndPoint(txtEndPoint.Text, cbxMetodo.Text, chkFirmar.Checked, chkEnviarKey.Checked, chkTimeStamp.Checked, par);
                txtSalida.Text += "\r\nError:" + FUT.DescripcionError;
            }

        }

        private void BtnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSalida.Text);

        }

        private void OnbtnPrecio_Click(object sender, EventArgs e)
        {
            ClasesBinance.Precio precio = SPT.Precios.ObtenerPrecio(txtReglasParSpot.Text);
            txtSalida.Text = precio.Simbolo + " : " + precio.Precio;
        }

        private void OnbtnPrecios_Click(object sender, EventArgs e)
        {
            txtSalida.Text = "";
            ClasesBinance.Precios precios = SPT.Precios.ObtenerPrecios();
            if (precios.TodoOk) 
                foreach( ClasesBinance.Precio p in precios.Simbolos)
                {
                    txtSalida.Text += p.Simbolo + ": " + p.Precio.ToString() + "\r\n";
                }   
        }

        private void OnbtnVelas_Click(object sender, EventArgs e)
        {

            ClasesBinance.Velas velas = SPT.Precios.ObtenerVelas(txtSimboloVelas.Text, GetIntervalos(), txtDesde.Text, txtHasta.Text);
            string s = "";
            if (velas.TodoOk)
            {
                foreach (ClasesBinance.Vela v in velas.ListaDeVelas)
                {
                    s += v.FechaApertura.ToString() + " -> " + v.Cierre.ToString("0.00") + "  // " + v.Volumen.ToString() + "\r\n";
                }
                txtSalida.Text = s;
            }
            else
                txtSalida.Text = velas.DescripcionError;            
        }
        private Utilidades.Intervalos GetIntervalos()
        {
            if (rb1m.Checked)
                return Utilidades.Intervalos.m1;
            else if (rb5m.Checked)
                return Utilidades.Intervalos.m5;
            else if (rb1h.Checked)
                return Utilidades.Intervalos.h1;
            else if (rb1d.Checked)
                return Utilidades.Intervalos.d1;
            else
                return Utilidades.Intervalos.d1;
        }

        private void OnbtnEscuchar_Click(object sender, EventArgs e)
        {
            SPT.WS_Precios.Escuchar("ETHUSDT");
            FUT.WS_Futuros.Escuchar("ETHUSDT_210625");
        }

        private void OntmActualizarPrecios_Tick(object sender, EventArgs e)
        {
            decimal Spot  = SPT.WS_Precios.Buffer.Obtener("ethusdt".ToUpper());
            decimal Futuro = FUT.WS_Futuros.Buffer.Obtener("ethusdt_210625".ToUpper());


            lbSpot.Text =  Spot.ToString("0.0000");
            lbFuturo.Text = Futuro.ToString("0.0000");
            if (Spot != 0) 
                lbTasa.Text = (Futuro * 100 / Spot - 100).ToString("0.00");

            RecargarListaDeOperaciones();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        decimal Val(string valor)
        {
            return Convert.ToDecimal(valor, System.Globalization.CultureInfo.InvariantCulture);
        }


        private void OnbtnCancelarOrdenes_Click(object sender, EventArgs e)
        {
            SPT.Ordenes.CancelarTodasLasOrdenesPendientesDeUnSimbolo(txtSpotTicker.Text);
            FUT.Ordenes.CancelarTodasLasOrdenesPendientesDeUnSimbolo(txtFuturoTicker.Text);

        }

        private void OnbtnOCO_Vender_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = SPT.Ordenes.OrdenVentaOCO(txtOCO_Simbolo.Text, "", Val(txtOCO_Cantidad.Text), Val(txtOCO_Precio.Text), Val(txtOCO_Stop.Text), Val(txtOCO_Limite.Text));
            if (orden != null)
            {
                if (orden.TodoOk)
                    txtSalida.Text = "Symbol:" + orden.Simbolo + "Ordenes:" + orden.Ordenes.Count.ToString() + " Reports:" + orden.ReporteDeOrdenes.Count.ToString();
                else
                    txtSalida.Text = orden.DescripcionError;
            }
            else
            {
                txtSalida.Text = "El servidor devolvio null";
            }

        }

        private void OnbtnOCO_Comprar_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = SPT.Ordenes.OrdenCompraOCO(txtOCO_Simbolo.Text, "", Val(txtOCO_Cantidad.Text), Val(txtOCO_Precio.Text), Val(txtOCO_Stop.Text), Val(txtOCO_Limite.Text));
            if (orden != null)
            {
                if (orden.TodoOk)
                    txtSalida.Text = "Symbol:" + orden.Simbolo + "Ordenes:" + orden.Ordenes.Count.ToString() + " Reports:" + orden.ReporteDeOrdenes.Count.ToString();
                else
                    txtSalida.Text = orden.DescripcionError;
            }
            else
            {
                txtSalida.Text = "El servidor devolvio null";
            }
        }

        private void OnbtnPendientes_Click(object sender, EventArgs e)
        {
            lvOrdenes.Items.Clear();
            ClasesBinance.Ordenes ordenes = SPT.Ordenes.ObtenerEstadoOrdenesPendientes(txtOrdenes_Ticker.Text);
            if (ordenes.TodoOk)
            {
                foreach( ClasesBinance.Orden o in ordenes.ListaDeOrdenes)
                {
                    ListViewItem i = lvOrdenes.Items.Add(o.Simbolo);
                    i.SubItems.Add(o.OrdenId.ToString());
                    i.SubItems.Add(o.Precio.ToString());
                    i.SubItems.Add(o.Cantidad.ToString());
                    i.SubItems.Add(o.Estado);
                    i.SubItems.Add(o.Tipo);
                }
            }            
            
        }

        private void OnbtnActualizarReglasFuturos_Click(object sender, EventArgs e)
        {
            ClasesBinance.Futuros.Reglas Reglas = FUT.Consultas.ObtenerRelgas();
            foreach( ClasesBinance.Futuros.SimboloFuturo fut in Reglas.Simbolos)
            {
                txtSalida.Text += fut.Simbolo + " / " + fut.Par + "  Precio: " + fut.CantidadDecimalesPrecioMinimo.ToString() + " Cant:" + fut.CantidadDecimalesCantidadMinima.ToString() + "\r\n";
            }
        }

        private void OnbtnReglasFuturos_Click(object sender, EventArgs e)
        {
            ClasesBinance.Futuros.SimboloFuturo fut = FUT.Reglas.ObtenerSimbolo(txtReglasParFuturo.Text);
            if (fut != null)
            {
                txtSalida.Text = "Información simbolo:" + fut.Simbolo + "\r\n";
                if (fut != null)
                    txtSalida.Text += " Par " + fut.Par + "  Precio: " + fut.CantidadDecimalesPrecioMinimo.ToString() + "\r\n Cant:" + fut.CantidadDecimalesCantidadMinima.ToString() + "\r\n";
                txtSalida.Text += " fechaEnvio: " + fut.FechaVencimiento.ToString() + "  fecha vto:" + fut.FechaLanzamiento.ToString();
            }
            else
            {
                txtSalida.Text = Futuro.UltimoError;
            }
        }

        private void OnbtnOrdenes_Consultar_Click(object sender, EventArgs e)
        {
            lvOrdenes.Items.Clear();
            ClasesBinance.Ordenes  ordenes = SPT.Ordenes.ObtenerEstadoOrdenes(txtOrdenes_Ticker.Text,txtOrdenes_Desde.Text, txtOrdenes_Hasta.Text);
            if (ordenes.TodoOk)
            {
                foreach (ClasesBinance.Orden o in ordenes.ListaDeOrdenes)
                {
                    ListViewItem i = lvOrdenes.Items.Add(o.Simbolo);
                    i.SubItems.Add(o.OrdenId.ToString());
                    i.SubItems.Add(o.Precio.ToString());
                    i.SubItems.Add(o.Cantidad.ToString());
                    i.SubItems.Add(o.Estado);
                    i.SubItems.Add(o.Tipo);
                }
            }
            else { txtSalida.Text = ordenes.DescripcionError; }            
        }

        private void OnbtnSpotVender_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = null;

            txtSalida.Text = orden.DescripcionError + ", " + orden.Estado;
        }

        private void Salida(ClasesBinance.Orden orden)
        {
            if (orden.HuboError) txtSalida.Text = orden.DescripcionError;
            else
            {
                txtSalida.Text = "Orden correcta, Simbolo:" + orden.Simbolo + ", Canitdad:" + orden.Cantidad.ToString() + " Precio:" + orden.Precio.ToString();
            }
        }


        private void OnbtnComprarFuturo_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.Comprar(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text), Val(txtFuturoPrecio.Text));
            Salida(orden);
        }
        private void OnbtnVenderFuturo_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.Vender(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text), Val(txtFuturoPrecio.Text));
            Salida(orden);
        }

        private void OnbtnTakeProfitDeCompra_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.TakeProfitDeCompra(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text), Val(txtFuturoPrecio.Text));
            Salida(orden);
        }

        private void OnbtnTakeProfitDeVenta_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.TakeProfitDeVenta(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text), Val(txtFuturoPrecio.Text));
            Salida(orden);
        }

        private void OnbtnStopLossDeCompra_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.StopLossDeCompra(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text), Val(txtFuturoPrecio.Text), Val(txtFuturoGatillo.Text));
            Salida(orden);
        }

        private void OnbtnStopLossDeVenta_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.StopLossDeVenta(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text), Val(txtFuturoPrecio.Text), Val(txtFuturoGatillo.Text));
            Salida(orden);
        }

        private void OnbtnnTenenciaFuturos_Click(object sender, EventArgs e)
        {
            ClasesBinance.Tenencias tenencias = FUT.Consultas.ObtenerTenencia();
            txtSalida.Text = tenencias.TotalBilletera.ToString("0.00");
            txtSalida.Text = tenencias.JSon;
        }

        private void OnbtnComprarMarket_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.ComprarMarket(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text));
            Salida(orden);
        }

        private void OnbtnVenderMarket_Click(object sender, EventArgs e)
        {
            ClasesBinance.Orden orden = FUT.Ordenes.VenderMarket(txtFuturoTicker.Text, Val(txtFuturoCantidad.Text));
            Salida(orden);

        }
    }
}
