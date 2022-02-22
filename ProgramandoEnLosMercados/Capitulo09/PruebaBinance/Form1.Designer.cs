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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.bntRegla = new System.Windows.Forms.Button();
            this.btnReglasSpot = new System.Windows.Forms.Button();
            this.txtReglasParSpot = new System.Windows.Forms.TextBox();
            this.btnTenencia = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnEndPoint = new System.Windows.Forms.Button();
            this.txtEndPoint = new System.Windows.Forms.TextBox();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFirmar = new System.Windows.Forms.CheckBox();
            this.chkEnviarKey = new System.Windows.Forms.CheckBox();
            this.chkTimeStamp = new System.Windows.Forms.CheckBox();
            this.cbxMetodo = new System.Windows.Forms.ComboBox();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.btnPrecios = new System.Windows.Forms.Button();
            this.btnVelas = new System.Windows.Forms.Button();
            this.txtSimboloVelas = new System.Windows.Forms.TextBox();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rb1m = new System.Windows.Forms.RadioButton();
            this.rb5m = new System.Windows.Forms.RadioButton();
            this.rb1h = new System.Windows.Forms.RadioButton();
            this.rb1d = new System.Windows.Forms.RadioButton();
            this.chkFuturo = new System.Windows.Forms.CheckBox();
            this.btnEscuchar = new System.Windows.Forms.Button();
            this.tmActualizarPrecios = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lbSpot = new System.Windows.Forms.Label();
            this.lbFuturo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTasa = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnVenderFuturo = new System.Windows.Forms.Button();
            this.txtFuturoTicker = new System.Windows.Forms.TextBox();
            this.btnComprarFuturo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFuturoCantidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFuturoPrecio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelarOrdenes = new System.Windows.Forms.Button();
            this.txtFuturoGatillo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOCO_Stop = new System.Windows.Forms.TextBox();
            this.txtOCO_Precio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOCO_Cantidad = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOCO_Simbolo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOCO_Limite = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnOCO_Vender = new System.Windows.Forms.Button();
            this.btnOCO_Comprar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnVenderMarket = new System.Windows.Forms.Button();
            this.btnComprarMarket = new System.Windows.Forms.Button();
            this.btnStopLossDeVenta = new System.Windows.Forms.Button();
            this.btnStopLossDeCompra = new System.Windows.Forms.Button();
            this.btnTakeProfitDeCompra = new System.Windows.Forms.Button();
            this.btnTakeProfitDeVenta = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSpotVender = new System.Windows.Forms.Button();
            this.btnSpotComprar = new System.Windows.Forms.Button();
            this.txtSpotTicker = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtSpotCantidad = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSpotPrecio = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbSpotTakeProfit = new System.Windows.Forms.RadioButton();
            this.rbSpotStopLoss = new System.Windows.Forms.RadioButton();
            this.rbSpotMarket = new System.Windows.Forms.RadioButton();
            this.rbSpotLimit = new System.Windows.Forms.RadioButton();
            this.txtSpotPrecioLimit = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPendientes = new System.Windows.Forms.Button();
            this.btnOrdenes_Consultar = new System.Windows.Forms.Button();
            this.txtOrdenes_Hasta = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtOrdenes_Desde = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtOrdenes_Ticker = new System.Windows.Forms.TextBox();
            this.lvOrdenes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvOperaciones = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnActualizarReglasFuturos = new System.Windows.Forms.Button();
            this.txtReglasParFuturo = new System.Windows.Forms.TextBox();
            this.btnReglasFuturos = new System.Windows.Forms.Button();
            this.btnnTenenciaFuturos = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Puntas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Onbutton1_Click);
            // 
            // txtSalida
            // 
            this.txtSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalida.Location = new System.Drawing.Point(246, 5);
            this.txtSalida.Multiline = true;
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSalida.Size = new System.Drawing.Size(524, 198);
            this.txtSalida.TabIndex = 1;
            // 
            // bntRegla
            // 
            this.bntRegla.Location = new System.Drawing.Point(12, 1);
            this.bntRegla.Name = "bntRegla";
            this.bntRegla.Size = new System.Drawing.Size(115, 34);
            this.bntRegla.TabIndex = 2;
            this.bntRegla.Text = "Actualizar Reglas\r\nSPOT";
            this.bntRegla.UseVisualStyleBackColor = true;
            this.bntRegla.Click += new System.EventHandler(this.OnbtnRegla_Click);
            // 
            // btnReglasSpot
            // 
            this.btnReglasSpot.Location = new System.Drawing.Point(12, 41);
            this.btnReglasSpot.Name = "btnReglasSpot";
            this.btnReglasSpot.Size = new System.Drawing.Size(91, 23);
            this.btnReglasSpot.TabIndex = 3;
            this.btnReglasSpot.Text = "Reglas Spot";
            this.btnReglasSpot.UseVisualStyleBackColor = true;
            this.btnReglasSpot.Click += new System.EventHandler(this.Onbutton2_Click);
            // 
            // txtReglasParSpot
            // 
            this.txtReglasParSpot.Location = new System.Drawing.Point(113, 44);
            this.txtReglasParSpot.Name = "txtReglasParSpot";
            this.txtReglasParSpot.Size = new System.Drawing.Size(82, 20);
            this.txtReglasParSpot.TabIndex = 4;
            this.txtReglasParSpot.Text = "BTCUSDT";
            // 
            // btnTenencia
            // 
            this.btnTenencia.Location = new System.Drawing.Point(15, 128);
            this.btnTenencia.Name = "btnTenencia";
            this.btnTenencia.Size = new System.Drawing.Size(75, 23);
            this.btnTenencia.TabIndex = 5;
            this.btnTenencia.Text = "Tenencia";
            this.btnTenencia.UseVisualStyleBackColor = true;
            this.btnTenencia.Click += new System.EventHandler(this.OnbtnTenencia_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiar.Location = new System.Drawing.Point(695, 205);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 23);
            this.btnCopiar.TabIndex = 6;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.BtnCopiar_Click);
            // 
            // btnEndPoint
            // 
            this.btnEndPoint.Location = new System.Drawing.Point(121, 300);
            this.btnEndPoint.Name = "btnEndPoint";
            this.btnEndPoint.Size = new System.Drawing.Size(75, 23);
            this.btnEndPoint.TabIndex = 13;
            this.btnEndPoint.Text = "EndPoint";
            this.btnEndPoint.UseVisualStyleBackColor = true;
            this.btnEndPoint.Click += new System.EventHandler(this.BtnEndPoint_Click);
            // 
            // txtEndPoint
            // 
            this.txtEndPoint.Location = new System.Drawing.Point(12, 187);
            this.txtEndPoint.Name = "txtEndPoint";
            this.txtEndPoint.Size = new System.Drawing.Size(210, 20);
            this.txtEndPoint.TabIndex = 8;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(12, 223);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(567, 20);
            this.txtParametro.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Endpoint:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Parametros";
            // 
            // chkFirmar
            // 
            this.chkFirmar.AutoSize = true;
            this.chkFirmar.Location = new System.Drawing.Point(12, 258);
            this.chkFirmar.Name = "chkFirmar";
            this.chkFirmar.Size = new System.Drawing.Size(54, 17);
            this.chkFirmar.TabIndex = 10;
            this.chkFirmar.Text = "Firmar";
            this.chkFirmar.UseVisualStyleBackColor = true;
            // 
            // chkEnviarKey
            // 
            this.chkEnviarKey.AutoSize = true;
            this.chkEnviarKey.Location = new System.Drawing.Point(12, 281);
            this.chkEnviarKey.Name = "chkEnviarKey";
            this.chkEnviarKey.Size = new System.Drawing.Size(74, 17);
            this.chkEnviarKey.TabIndex = 11;
            this.chkEnviarKey.Text = "EnviarKey";
            this.chkEnviarKey.UseVisualStyleBackColor = true;
            // 
            // chkTimeStamp
            // 
            this.chkTimeStamp.AutoSize = true;
            this.chkTimeStamp.Location = new System.Drawing.Point(12, 304);
            this.chkTimeStamp.Name = "chkTimeStamp";
            this.chkTimeStamp.Size = new System.Drawing.Size(79, 17);
            this.chkTimeStamp.TabIndex = 12;
            this.chkTimeStamp.Text = "TimeStamp";
            this.chkTimeStamp.UseVisualStyleBackColor = true;
            // 
            // cbxMetodo
            // 
            this.cbxMetodo.FormattingEnabled = true;
            this.cbxMetodo.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.cbxMetodo.Location = new System.Drawing.Point(135, 159);
            this.cbxMetodo.Name = "cbxMetodo";
            this.cbxMetodo.Size = new System.Drawing.Size(87, 21);
            this.cbxMetodo.TabIndex = 7;
            // 
            // btnPrecio
            // 
            this.btnPrecio.Location = new System.Drawing.Point(90, 99);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(75, 23);
            this.btnPrecio.TabIndex = 14;
            this.btnPrecio.Text = "Precio";
            this.btnPrecio.UseVisualStyleBackColor = true;
            this.btnPrecio.Click += new System.EventHandler(this.OnbtnPrecio_Click);
            // 
            // btnPrecios
            // 
            this.btnPrecios.Location = new System.Drawing.Point(162, 99);
            this.btnPrecios.Name = "btnPrecios";
            this.btnPrecios.Size = new System.Drawing.Size(75, 23);
            this.btnPrecios.TabIndex = 15;
            this.btnPrecios.Text = "Precios";
            this.btnPrecios.UseVisualStyleBackColor = true;
            this.btnPrecios.Click += new System.EventHandler(this.OnbtnPrecios_Click);
            // 
            // btnVelas
            // 
            this.btnVelas.Location = new System.Drawing.Point(1, 408);
            this.btnVelas.Name = "btnVelas";
            this.btnVelas.Size = new System.Drawing.Size(64, 23);
            this.btnVelas.TabIndex = 16;
            this.btnVelas.Text = "Velas";
            this.btnVelas.UseVisualStyleBackColor = true;
            this.btnVelas.Click += new System.EventHandler(this.OnbtnVelas_Click);
            // 
            // txtSimboloVelas
            // 
            this.txtSimboloVelas.Location = new System.Drawing.Point(3, 361);
            this.txtSimboloVelas.Name = "txtSimboloVelas";
            this.txtSimboloVelas.Size = new System.Drawing.Size(82, 20);
            this.txtSimboloVelas.TabIndex = 17;
            this.txtSimboloVelas.Text = "BTCUSDT";
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(91, 361);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(65, 20);
            this.txtDesde.TabIndex = 18;
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(162, 361);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(61, 20);
            this.txtHasta.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Simbolo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Desde:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hasta:";
            // 
            // rb1m
            // 
            this.rb1m.AutoSize = true;
            this.rb1m.Checked = true;
            this.rb1m.Location = new System.Drawing.Point(3, 388);
            this.rb1m.Name = "rb1m";
            this.rb1m.Size = new System.Drawing.Size(39, 17);
            this.rb1m.TabIndex = 20;
            this.rb1m.TabStop = true;
            this.rb1m.Text = "1m";
            this.rb1m.UseVisualStyleBackColor = true;
            // 
            // rb5m
            // 
            this.rb5m.AutoSize = true;
            this.rb5m.Location = new System.Drawing.Point(46, 388);
            this.rb5m.Name = "rb5m";
            this.rb5m.Size = new System.Drawing.Size(39, 17);
            this.rb5m.TabIndex = 20;
            this.rb5m.Text = "5m";
            this.rb5m.UseVisualStyleBackColor = true;
            // 
            // rb1h
            // 
            this.rb1h.AutoSize = true;
            this.rb1h.Location = new System.Drawing.Point(91, 388);
            this.rb1h.Name = "rb1h";
            this.rb1h.Size = new System.Drawing.Size(37, 17);
            this.rb1h.TabIndex = 20;
            this.rb1h.Text = "1h";
            this.rb1h.UseVisualStyleBackColor = true;
            // 
            // rb1d
            // 
            this.rb1d.AutoSize = true;
            this.rb1d.Location = new System.Drawing.Point(131, 388);
            this.rb1d.Name = "rb1d";
            this.rb1d.Size = new System.Drawing.Size(37, 17);
            this.rb1d.TabIndex = 20;
            this.rb1d.Text = "1d";
            this.rb1d.UseVisualStyleBackColor = true;
            // 
            // chkFuturo
            // 
            this.chkFuturo.AutoSize = true;
            this.chkFuturo.Location = new System.Drawing.Point(185, 136);
            this.chkFuturo.Name = "chkFuturo";
            this.chkFuturo.Size = new System.Drawing.Size(56, 17);
            this.chkFuturo.TabIndex = 21;
            this.chkFuturo.Text = "Futuro";
            this.chkFuturo.UseVisualStyleBackColor = true;
            // 
            // btnEscuchar
            // 
            this.btnEscuchar.Location = new System.Drawing.Point(0, 475);
            this.btnEscuchar.Name = "btnEscuchar";
            this.btnEscuchar.Size = new System.Drawing.Size(64, 23);
            this.btnEscuchar.TabIndex = 22;
            this.btnEscuchar.Text = "Escuchar";
            this.btnEscuchar.UseVisualStyleBackColor = true;
            this.btnEscuchar.Click += new System.EventHandler(this.OnbtnEscuchar_Click);
            // 
            // tmActualizarPrecios
            // 
            this.tmActualizarPrecios.Interval = 400;
            this.tmActualizarPrecios.Tick += new System.EventHandler(this.OntmActualizarPrecios_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 466);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Spot:";
            // 
            // lbSpot
            // 
            this.lbSpot.Location = new System.Drawing.Point(110, 466);
            this.lbSpot.Name = "lbSpot";
            this.lbSpot.Size = new System.Drawing.Size(61, 15);
            this.lbSpot.TabIndex = 23;
            this.lbSpot.Text = "0.00";
            // 
            // lbFuturo
            // 
            this.lbFuturo.Location = new System.Drawing.Point(110, 481);
            this.lbFuturo.Name = "lbFuturo";
            this.lbFuturo.Size = new System.Drawing.Size(61, 15);
            this.lbFuturo.TabIndex = 24;
            this.lbFuturo.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 481);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Futuro:";
            // 
            // lbTasa
            // 
            this.lbTasa.Location = new System.Drawing.Point(110, 498);
            this.lbTasa.Name = "lbTasa";
            this.lbTasa.Size = new System.Drawing.Size(61, 15);
            this.lbTasa.TabIndex = 23;
            this.lbTasa.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 498);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tasa:";
            // 
            // btnVenderFuturo
            // 
            this.btnVenderFuturo.Location = new System.Drawing.Point(128, 259);
            this.btnVenderFuturo.Name = "btnVenderFuturo";
            this.btnVenderFuturo.Size = new System.Drawing.Size(64, 23);
            this.btnVenderFuturo.TabIndex = 26;
            this.btnVenderFuturo.Text = "Vender";
            this.btnVenderFuturo.UseVisualStyleBackColor = true;
            this.btnVenderFuturo.Click += new System.EventHandler(this.OnbtnVenderFuturo_Click);
            // 
            // txtFuturoTicker
            // 
            this.txtFuturoTicker.Location = new System.Drawing.Point(9, 204);
            this.txtFuturoTicker.Name = "txtFuturoTicker";
            this.txtFuturoTicker.Size = new System.Drawing.Size(89, 20);
            this.txtFuturoTicker.TabIndex = 27;
            this.txtFuturoTicker.Text = "ethusdt";
            // 
            // btnComprarFuturo
            // 
            this.btnComprarFuturo.Location = new System.Drawing.Point(128, 230);
            this.btnComprarFuturo.Name = "btnComprarFuturo";
            this.btnComprarFuturo.Size = new System.Drawing.Size(64, 23);
            this.btnComprarFuturo.TabIndex = 26;
            this.btnComprarFuturo.Text = "Comprar";
            this.btnComprarFuturo.UseVisualStyleBackColor = true;
            this.btnComprarFuturo.Click += new System.EventHandler(this.OnbtnComprarFuturo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ticker";
            // 
            // txtFuturoCantidad
            // 
            this.txtFuturoCantidad.Location = new System.Drawing.Point(104, 204);
            this.txtFuturoCantidad.Name = "txtFuturoCantidad";
            this.txtFuturoCantidad.Size = new System.Drawing.Size(54, 20);
            this.txtFuturoCantidad.TabIndex = 29;
            this.txtFuturoCantidad.Text = "0.01";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Cantidad:";
            // 
            // txtFuturoPrecio
            // 
            this.txtFuturoPrecio.Location = new System.Drawing.Point(164, 204);
            this.txtFuturoPrecio.Name = "txtFuturoPrecio";
            this.txtFuturoPrecio.Size = new System.Drawing.Size(62, 20);
            this.txtFuturoPrecio.TabIndex = 31;
            this.txtFuturoPrecio.Text = "2400";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(161, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Precio:";
            // 
            // btnCancelarOrdenes
            // 
            this.btnCancelarOrdenes.Location = new System.Drawing.Point(300, 289);
            this.btnCancelarOrdenes.Name = "btnCancelarOrdenes";
            this.btnCancelarOrdenes.Size = new System.Drawing.Size(213, 30);
            this.btnCancelarOrdenes.TabIndex = 33;
            this.btnCancelarOrdenes.Text = "Cancelar Todas las  Ordenes";
            this.btnCancelarOrdenes.UseVisualStyleBackColor = true;
            this.btnCancelarOrdenes.Click += new System.EventHandler(this.OnbtnCancelarOrdenes_Click);
            // 
            // txtFuturoGatillo
            // 
            this.txtFuturoGatillo.Location = new System.Drawing.Point(232, 204);
            this.txtFuturoGatillo.Name = "txtFuturoGatillo";
            this.txtFuturoGatillo.Size = new System.Drawing.Size(62, 20);
            this.txtFuturoGatillo.TabIndex = 34;
            this.txtFuturoGatillo.Text = "2401";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Gatillo";
            // 
            // txtOCO_Stop
            // 
            this.txtOCO_Stop.Location = new System.Drawing.Point(232, 129);
            this.txtOCO_Stop.Name = "txtOCO_Stop";
            this.txtOCO_Stop.Size = new System.Drawing.Size(64, 20);
            this.txtOCO_Stop.TabIndex = 42;
            this.txtOCO_Stop.Text = "2601";
            // 
            // txtOCO_Precio
            // 
            this.txtOCO_Precio.Location = new System.Drawing.Point(164, 129);
            this.txtOCO_Precio.Name = "txtOCO_Precio";
            this.txtOCO_Precio.Size = new System.Drawing.Size(62, 20);
            this.txtOCO_Precio.TabIndex = 41;
            this.txtOCO_Precio.Text = "2900";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(229, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Stop (Trigger)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(161, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Precio:";
            // 
            // txtOCO_Cantidad
            // 
            this.txtOCO_Cantidad.Location = new System.Drawing.Point(104, 129);
            this.txtOCO_Cantidad.Name = "txtOCO_Cantidad";
            this.txtOCO_Cantidad.Size = new System.Drawing.Size(54, 20);
            this.txtOCO_Cantidad.TabIndex = 38;
            this.txtOCO_Cantidad.Text = "0.01";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(101, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Cantidad:";
            // 
            // txtOCO_Simbolo
            // 
            this.txtOCO_Simbolo.Location = new System.Drawing.Point(9, 129);
            this.txtOCO_Simbolo.Name = "txtOCO_Simbolo";
            this.txtOCO_Simbolo.Size = new System.Drawing.Size(89, 20);
            this.txtOCO_Simbolo.TabIndex = 36;
            this.txtOCO_Simbolo.Text = "ethusdt";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Ticker";
            // 
            // txtOCO_Limite
            // 
            this.txtOCO_Limite.Location = new System.Drawing.Point(307, 129);
            this.txtOCO_Limite.Name = "txtOCO_Limite";
            this.txtOCO_Limite.Size = new System.Drawing.Size(58, 20);
            this.txtOCO_Limite.TabIndex = 45;
            this.txtOCO_Limite.Text = "2600";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(304, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "Limit";
            // 
            // btnOCO_Vender
            // 
            this.btnOCO_Vender.Location = new System.Drawing.Point(368, 127);
            this.btnOCO_Vender.Name = "btnOCO_Vender";
            this.btnOCO_Vender.Size = new System.Drawing.Size(64, 23);
            this.btnOCO_Vender.TabIndex = 46;
            this.btnOCO_Vender.Text = "Vender";
            this.btnOCO_Vender.UseVisualStyleBackColor = true;
            this.btnOCO_Vender.Click += new System.EventHandler(this.OnbtnOCO_Vender_Click);
            // 
            // btnOCO_Comprar
            // 
            this.btnOCO_Comprar.Location = new System.Drawing.Point(438, 126);
            this.btnOCO_Comprar.Name = "btnOCO_Comprar";
            this.btnOCO_Comprar.Size = new System.Drawing.Size(64, 23);
            this.btnOCO_Comprar.TabIndex = 47;
            this.btnOCO_Comprar.Text = "Comprar";
            this.btnOCO_Comprar.UseVisualStyleBackColor = true;
            this.btnOCO_Comprar.Click += new System.EventHandler(this.OnbtnOCO_Comprar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(243, 249);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(524, 345);
            this.tabControl1.TabIndex = 48;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnVenderMarket);
            this.tabPage1.Controls.Add(this.btnComprarMarket);
            this.tabPage1.Controls.Add(this.btnStopLossDeVenta);
            this.tabPage1.Controls.Add(this.btnStopLossDeCompra);
            this.tabPage1.Controls.Add(this.btnTakeProfitDeCompra);
            this.tabPage1.Controls.Add(this.btnTakeProfitDeVenta);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.btnSpotVender);
            this.tabPage1.Controls.Add(this.btnSpotComprar);
            this.tabPage1.Controls.Add(this.txtSpotTicker);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.txtSpotCantidad);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.txtSpotPrecio);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.txtSpotPrecioLimit);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnOCO_Comprar);
            this.tabPage1.Controls.Add(this.btnVenderFuturo);
            this.tabPage1.Controls.Add(this.btnOCO_Vender);
            this.tabPage1.Controls.Add(this.btnComprarFuturo);
            this.tabPage1.Controls.Add(this.txtOCO_Limite);
            this.tabPage1.Controls.Add(this.txtFuturoTicker);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtFuturoCantidad);
            this.tabPage1.Controls.Add(this.txtOCO_Stop);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtOCO_Precio);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtFuturoPrecio);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtOCO_Cantidad);
            this.tabPage1.Controls.Add(this.btnCancelarOrdenes);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtFuturoGatillo);
            this.tabPage1.Controls.Add(this.txtOCO_Simbolo);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(516, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enviar Ordenes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVenderMarket
            // 
            this.btnVenderMarket.Location = new System.Drawing.Point(368, 260);
            this.btnVenderMarket.Name = "btnVenderMarket";
            this.btnVenderMarket.Size = new System.Drawing.Size(111, 23);
            this.btnVenderMarket.TabIndex = 65;
            this.btnVenderMarket.Text = "Vender Market";
            this.btnVenderMarket.UseVisualStyleBackColor = true;
            this.btnVenderMarket.Click += new System.EventHandler(this.OnbtnVenderMarket_Click);
            // 
            // btnComprarMarket
            // 
            this.btnComprarMarket.Location = new System.Drawing.Point(368, 231);
            this.btnComprarMarket.Name = "btnComprarMarket";
            this.btnComprarMarket.Size = new System.Drawing.Size(111, 23);
            this.btnComprarMarket.TabIndex = 64;
            this.btnComprarMarket.Text = "Comprar Market";
            this.btnComprarMarket.UseVisualStyleBackColor = true;
            this.btnComprarMarket.Click += new System.EventHandler(this.OnbtnComprarMarket_Click);
            // 
            // btnStopLossDeVenta
            // 
            this.btnStopLossDeVenta.Location = new System.Drawing.Point(6, 259);
            this.btnStopLossDeVenta.Name = "btnStopLossDeVenta";
            this.btnStopLossDeVenta.Size = new System.Drawing.Size(119, 23);
            this.btnStopLossDeVenta.TabIndex = 63;
            this.btnStopLossDeVenta.Text = "Stop Loss de Venta";
            this.btnStopLossDeVenta.UseVisualStyleBackColor = true;
            this.btnStopLossDeVenta.Click += new System.EventHandler(this.OnbtnStopLossDeVenta_Click);
            // 
            // btnStopLossDeCompra
            // 
            this.btnStopLossDeCompra.Location = new System.Drawing.Point(7, 231);
            this.btnStopLossDeCompra.Name = "btnStopLossDeCompra";
            this.btnStopLossDeCompra.Size = new System.Drawing.Size(119, 23);
            this.btnStopLossDeCompra.TabIndex = 62;
            this.btnStopLossDeCompra.Text = "Stop Loss de Compra";
            this.btnStopLossDeCompra.UseVisualStyleBackColor = true;
            this.btnStopLossDeCompra.Click += new System.EventHandler(this.OnbtnStopLossDeCompra_Click);
            // 
            // btnTakeProfitDeCompra
            // 
            this.btnTakeProfitDeCompra.Location = new System.Drawing.Point(198, 230);
            this.btnTakeProfitDeCompra.Name = "btnTakeProfitDeCompra";
            this.btnTakeProfitDeCompra.Size = new System.Drawing.Size(134, 23);
            this.btnTakeProfitDeCompra.TabIndex = 61;
            this.btnTakeProfitDeCompra.Text = "Take Profit  de Compra";
            this.btnTakeProfitDeCompra.UseVisualStyleBackColor = true;
            this.btnTakeProfitDeCompra.Click += new System.EventHandler(this.OnbtnTakeProfitDeCompra_Click);
            // 
            // btnTakeProfitDeVenta
            // 
            this.btnTakeProfitDeVenta.Location = new System.Drawing.Point(200, 259);
            this.btnTakeProfitDeVenta.Name = "btnTakeProfitDeVenta";
            this.btnTakeProfitDeVenta.Size = new System.Drawing.Size(132, 23);
            this.btnTakeProfitDeVenta.TabIndex = 61;
            this.btnTakeProfitDeVenta.Text = "Take Profit  de Venta";
            this.btnTakeProfitDeVenta.UseVisualStyleBackColor = true;
            this.btnTakeProfitDeVenta.Click += new System.EventHandler(this.OnbtnTakeProfitDeVenta_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Maroon;
            this.label27.Location = new System.Drawing.Point(0, 170);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 60;
            this.label27.Text = "Futuro";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Maroon;
            this.label17.Location = new System.Drawing.Point(2, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 60;
            this.label17.Text = "Spot";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "Ticker";
            // 
            // btnSpotVender
            // 
            this.btnSpotVender.Location = new System.Drawing.Point(304, 33);
            this.btnSpotVender.Name = "btnSpotVender";
            this.btnSpotVender.Size = new System.Drawing.Size(64, 23);
            this.btnSpotVender.TabIndex = 49;
            this.btnSpotVender.Text = "Vender";
            this.btnSpotVender.UseVisualStyleBackColor = true;
            this.btnSpotVender.Click += new System.EventHandler(this.OnbtnSpotVender_Click);
            // 
            // btnSpotComprar
            // 
            this.btnSpotComprar.Location = new System.Drawing.Point(374, 32);
            this.btnSpotComprar.Name = "btnSpotComprar";
            this.btnSpotComprar.Size = new System.Drawing.Size(64, 23);
            this.btnSpotComprar.TabIndex = 50;
            this.btnSpotComprar.Text = "Comprar";
            this.btnSpotComprar.UseVisualStyleBackColor = true;
            // 
            // txtSpotTicker
            // 
            this.txtSpotTicker.Location = new System.Drawing.Point(13, 35);
            this.txtSpotTicker.Name = "txtSpotTicker";
            this.txtSpotTicker.Size = new System.Drawing.Size(89, 20);
            this.txtSpotTicker.TabIndex = 51;
            this.txtSpotTicker.Text = "ethusdt";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(105, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 13);
            this.label23.TabIndex = 52;
            this.label23.Text = "Cantidad:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 96);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(30, 13);
            this.label24.TabIndex = 59;
            this.label24.Text = "OCO";
            // 
            // txtSpotCantidad
            // 
            this.txtSpotCantidad.Location = new System.Drawing.Point(108, 35);
            this.txtSpotCantidad.Name = "txtSpotCantidad";
            this.txtSpotCantidad.Size = new System.Drawing.Size(54, 20);
            this.txtSpotCantidad.TabIndex = 53;
            this.txtSpotCantidad.Text = "5";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(165, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 13);
            this.label25.TabIndex = 54;
            this.label25.Text = "Precio:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(237, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 13);
            this.label26.TabIndex = 55;
            this.label26.Text = "Limit";
            // 
            // txtSpotPrecio
            // 
            this.txtSpotPrecio.Location = new System.Drawing.Point(168, 35);
            this.txtSpotPrecio.Name = "txtSpotPrecio";
            this.txtSpotPrecio.Size = new System.Drawing.Size(62, 20);
            this.txtSpotPrecio.TabIndex = 56;
            this.txtSpotPrecio.Text = "18.4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbSpotTakeProfit);
            this.panel2.Controls.Add(this.rbSpotStopLoss);
            this.panel2.Controls.Add(this.rbSpotMarket);
            this.panel2.Controls.Add(this.rbSpotLimit);
            this.panel2.Location = new System.Drawing.Point(13, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 26);
            this.panel2.TabIndex = 57;
            // 
            // rbSpotTakeProfit
            // 
            this.rbSpotTakeProfit.AutoSize = true;
            this.rbSpotTakeProfit.Location = new System.Drawing.Point(208, 3);
            this.rbSpotTakeProfit.Name = "rbSpotTakeProfit";
            this.rbSpotTakeProfit.Size = new System.Drawing.Size(77, 17);
            this.rbSpotTakeProfit.TabIndex = 3;
            this.rbSpotTakeProfit.Text = "Take Profit";
            this.rbSpotTakeProfit.UseVisualStyleBackColor = true;
            // 
            // rbSpotStopLoss
            // 
            this.rbSpotStopLoss.AutoSize = true;
            this.rbSpotStopLoss.Location = new System.Drawing.Point(132, 3);
            this.rbSpotStopLoss.Name = "rbSpotStopLoss";
            this.rbSpotStopLoss.Size = new System.Drawing.Size(72, 17);
            this.rbSpotStopLoss.TabIndex = 2;
            this.rbSpotStopLoss.Text = "Stop Loss";
            this.rbSpotStopLoss.UseVisualStyleBackColor = true;
            // 
            // rbSpotMarket
            // 
            this.rbSpotMarket.AutoSize = true;
            this.rbSpotMarket.Location = new System.Drawing.Point(56, 3);
            this.rbSpotMarket.Name = "rbSpotMarket";
            this.rbSpotMarket.Size = new System.Drawing.Size(58, 17);
            this.rbSpotMarket.TabIndex = 1;
            this.rbSpotMarket.Text = "Market";
            this.rbSpotMarket.UseVisualStyleBackColor = true;
            // 
            // rbSpotLimit
            // 
            this.rbSpotLimit.AutoSize = true;
            this.rbSpotLimit.Checked = true;
            this.rbSpotLimit.Location = new System.Drawing.Point(4, 3);
            this.rbSpotLimit.Name = "rbSpotLimit";
            this.rbSpotLimit.Size = new System.Drawing.Size(46, 17);
            this.rbSpotLimit.TabIndex = 0;
            this.rbSpotLimit.TabStop = true;
            this.rbSpotLimit.Text = "Limit";
            this.rbSpotLimit.UseVisualStyleBackColor = true;
            // 
            // txtSpotPrecioLimit
            // 
            this.txtSpotPrecioLimit.Location = new System.Drawing.Point(236, 35);
            this.txtSpotPrecioLimit.Name = "txtSpotPrecioLimit";
            this.txtSpotPrecioLimit.Size = new System.Drawing.Size(62, 20);
            this.txtSpotPrecioLimit.TabIndex = 58;
            this.txtSpotPrecioLimit.Text = "18.4";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPendientes);
            this.tabPage2.Controls.Add(this.btnOrdenes_Consultar);
            this.tabPage2.Controls.Add(this.txtOrdenes_Hasta);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.txtOrdenes_Desde);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.txtOrdenes_Ticker);
            this.tabPage2.Controls.Add(this.lvOrdenes);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(516, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultar Ordenes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPendientes
            // 
            this.btnPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPendientes.Location = new System.Drawing.Point(437, 297);
            this.btnPendientes.Name = "btnPendientes";
            this.btnPendientes.Size = new System.Drawing.Size(75, 23);
            this.btnPendientes.TabIndex = 35;
            this.btnPendientes.Text = "Pendientes";
            this.btnPendientes.UseVisualStyleBackColor = true;
            this.btnPendientes.Click += new System.EventHandler(this.OnbtnPendientes_Click);
            // 
            // btnOrdenes_Consultar
            // 
            this.btnOrdenes_Consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenes_Consultar.Location = new System.Drawing.Point(359, 297);
            this.btnOrdenes_Consultar.Name = "btnOrdenes_Consultar";
            this.btnOrdenes_Consultar.Size = new System.Drawing.Size(75, 23);
            this.btnOrdenes_Consultar.TabIndex = 34;
            this.btnOrdenes_Consultar.Text = "Ordenes";
            this.btnOrdenes_Consultar.UseVisualStyleBackColor = true;
            this.btnOrdenes_Consultar.Click += new System.EventHandler(this.OnbtnOrdenes_Consultar_Click);
            // 
            // txtOrdenes_Hasta
            // 
            this.txtOrdenes_Hasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrdenes_Hasta.Location = new System.Drawing.Point(275, 299);
            this.txtOrdenes_Hasta.Name = "txtOrdenes_Hasta";
            this.txtOrdenes_Hasta.Size = new System.Drawing.Size(68, 20);
            this.txtOrdenes_Hasta.TabIndex = 33;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(126, 302);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "Desde:";
            // 
            // txtOrdenes_Desde
            // 
            this.txtOrdenes_Desde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrdenes_Desde.Location = new System.Drawing.Point(167, 299);
            this.txtOrdenes_Desde.Name = "txtOrdenes_Desde";
            this.txtOrdenes_Desde.Size = new System.Drawing.Size(67, 20);
            this.txtOrdenes_Desde.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 302);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 28;
            this.label19.Text = "Ticker";
            // 
            // txtOrdenes_Ticker
            // 
            this.txtOrdenes_Ticker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrdenes_Ticker.Location = new System.Drawing.Point(52, 299);
            this.txtOrdenes_Ticker.Name = "txtOrdenes_Ticker";
            this.txtOrdenes_Ticker.Size = new System.Drawing.Size(70, 20);
            this.txtOrdenes_Ticker.TabIndex = 29;
            this.txtOrdenes_Ticker.Text = "ethusdt";
            // 
            // lvOrdenes
            // 
            this.lvOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOrdenes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvOrdenes.HideSelection = false;
            this.lvOrdenes.Location = new System.Drawing.Point(7, 10);
            this.lvOrdenes.Name = "lvOrdenes";
            this.lvOrdenes.Size = new System.Drawing.Size(503, 284);
            this.lvOrdenes.TabIndex = 0;
            this.lvOrdenes.UseCompatibleStateImageBehavior = false;
            this.lvOrdenes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Simbolo";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "OrdeID";
            this.columnHeader2.Width = 66;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Precio";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 86;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cantidad";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 71;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Estado";
            this.columnHeader5.Width = 97;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tipo";
            this.columnHeader6.Width = 91;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(239, 303);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "Hasta:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvOperaciones);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(516, 319);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WebSocket Ordenes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvOperaciones
            // 
            this.lvOperaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader7,
            this.columnHeader16,
            this.columnHeader17});
            this.lvOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOperaciones.HideSelection = false;
            this.lvOperaciones.Location = new System.Drawing.Point(0, 0);
            this.lvOperaciones.Name = "lvOperaciones";
            this.lvOperaciones.Size = new System.Drawing.Size(516, 319);
            this.lvOperaciones.TabIndex = 1;
            this.lvOperaciones.UseCompatibleStateImageBehavior = false;
            this.lvOperaciones.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Simbolo";
            this.columnHeader13.Width = 81;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Lado";
            this.columnHeader14.Width = 48;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Tipo Orden";
            this.columnHeader15.Width = 114;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Novedad";
            this.columnHeader7.Width = 95;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Cantidad";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader16.Width = 73;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Precio";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader17.Width = 75;
            // 
            // btnActualizarReglasFuturos
            // 
            this.btnActualizarReglasFuturos.Location = new System.Drawing.Point(130, 1);
            this.btnActualizarReglasFuturos.Name = "btnActualizarReglasFuturos";
            this.btnActualizarReglasFuturos.Size = new System.Drawing.Size(111, 34);
            this.btnActualizarReglasFuturos.TabIndex = 49;
            this.btnActualizarReglasFuturos.Text = "Actualizar Reglas\r\nFuturos";
            this.btnActualizarReglasFuturos.UseVisualStyleBackColor = true;
            this.btnActualizarReglasFuturos.Click += new System.EventHandler(this.OnbtnActualizarReglasFuturos_Click);
            // 
            // txtReglasParFuturo
            // 
            this.txtReglasParFuturo.Location = new System.Drawing.Point(114, 68);
            this.txtReglasParFuturo.Name = "txtReglasParFuturo";
            this.txtReglasParFuturo.Size = new System.Drawing.Size(123, 20);
            this.txtReglasParFuturo.TabIndex = 51;
            this.txtReglasParFuturo.Text = "ETHUSDT_210625";
            // 
            // btnReglasFuturos
            // 
            this.btnReglasFuturos.Location = new System.Drawing.Point(13, 65);
            this.btnReglasFuturos.Name = "btnReglasFuturos";
            this.btnReglasFuturos.Size = new System.Drawing.Size(91, 23);
            this.btnReglasFuturos.TabIndex = 50;
            this.btnReglasFuturos.Text = "Reglas Futuro";
            this.btnReglasFuturos.UseVisualStyleBackColor = true;
            this.btnReglasFuturos.Click += new System.EventHandler(this.OnbtnReglasFuturos_Click);
            // 
            // btnnTenenciaFuturos
            // 
            this.btnnTenenciaFuturos.Location = new System.Drawing.Point(96, 130);
            this.btnnTenenciaFuturos.Name = "btnnTenenciaFuturos";
            this.btnnTenenciaFuturos.Size = new System.Drawing.Size(75, 23);
            this.btnnTenenciaFuturos.TabIndex = 52;
            this.btnnTenenciaFuturos.Text = "Tenencia";
            this.btnnTenenciaFuturos.UseVisualStyleBackColor = true;
            this.btnnTenenciaFuturos.Click += new System.EventHandler(this.OnbtnnTenenciaFuturos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 595);
            this.Controls.Add(this.btnnTenenciaFuturos);
            this.Controls.Add(this.txtReglasParFuturo);
            this.Controls.Add(this.btnReglasFuturos);
            this.Controls.Add(this.btnActualizarReglasFuturos);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbFuturo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTasa);
            this.Controls.Add(this.lbSpot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEscuchar);
            this.Controls.Add(this.chkFuturo);
            this.Controls.Add(this.rb1d);
            this.Controls.Add(this.rb1h);
            this.Controls.Add(this.rb5m);
            this.Controls.Add(this.rb1m);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.txtSimboloVelas);
            this.Controls.Add(this.btnVelas);
            this.Controls.Add(this.btnPrecios);
            this.Controls.Add(this.btnPrecio);
            this.Controls.Add(this.cbxMetodo);
            this.Controls.Add(this.chkTimeStamp);
            this.Controls.Add(this.chkEnviarKey);
            this.Controls.Add(this.chkFirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.txtEndPoint);
            this.Controls.Add(this.btnEndPoint);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.btnTenencia);
            this.Controls.Add(this.txtReglasParSpot);
            this.Controls.Add(this.btnReglasSpot);
            this.Controls.Add(this.bntRegla);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.Button bntRegla;
        private System.Windows.Forms.Button btnReglasSpot;
        private System.Windows.Forms.TextBox txtReglasParSpot;
        private System.Windows.Forms.Button btnTenencia;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnEndPoint;
        private System.Windows.Forms.TextBox txtEndPoint;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFirmar;
        private System.Windows.Forms.CheckBox chkEnviarKey;
        private System.Windows.Forms.CheckBox chkTimeStamp;
        private System.Windows.Forms.ComboBox cbxMetodo;
        private System.Windows.Forms.Button btnPrecio;
        private System.Windows.Forms.Button btnPrecios;
        private System.Windows.Forms.Button btnVelas;
        private System.Windows.Forms.TextBox txtSimboloVelas;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb1m;
        private System.Windows.Forms.RadioButton rb5m;
        private System.Windows.Forms.RadioButton rb1h;
        private System.Windows.Forms.RadioButton rb1d;
        private System.Windows.Forms.CheckBox chkFuturo;
        private System.Windows.Forms.Button btnEscuchar;
        private System.Windows.Forms.Timer tmActualizarPrecios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSpot;
        private System.Windows.Forms.Label lbFuturo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTasa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnVenderFuturo;
        private System.Windows.Forms.TextBox txtFuturoTicker;
        private System.Windows.Forms.Button btnComprarFuturo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFuturoCantidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFuturoPrecio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancelarOrdenes;
        private System.Windows.Forms.TextBox txtFuturoGatillo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOCO_Stop;
        private System.Windows.Forms.TextBox txtOCO_Precio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOCO_Cantidad;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtOCO_Simbolo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOCO_Limite;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnOCO_Vender;
        private System.Windows.Forms.Button btnOCO_Comprar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvOrdenes;
        private System.Windows.Forms.Button btnOrdenes_Consultar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtOrdenes_Hasta;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtOrdenes_Desde;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtOrdenes_Ticker;
        private System.Windows.Forms.Button btnPendientes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnActualizarReglasFuturos;
        private System.Windows.Forms.TextBox txtReglasParFuturo;
        private System.Windows.Forms.Button btnReglasFuturos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvOperaciones;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSpotVender;
        private System.Windows.Forms.Button btnSpotComprar;
        private System.Windows.Forms.TextBox txtSpotTicker;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtSpotCantidad;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSpotPrecio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbSpotTakeProfit;
        private System.Windows.Forms.RadioButton rbSpotStopLoss;
        private System.Windows.Forms.RadioButton rbSpotMarket;
        private System.Windows.Forms.RadioButton rbSpotLimit;
        private System.Windows.Forms.TextBox txtSpotPrecioLimit;
        private System.Windows.Forms.Button btnVenderMarket;
        private System.Windows.Forms.Button btnComprarMarket;
        private System.Windows.Forms.Button btnStopLossDeVenta;
        private System.Windows.Forms.Button btnStopLossDeCompra;
        private System.Windows.Forms.Button btnTakeProfitDeCompra;
        private System.Windows.Forms.Button btnTakeProfitDeVenta;
        private System.Windows.Forms.Button btnnTenenciaFuturos;
    }
}

