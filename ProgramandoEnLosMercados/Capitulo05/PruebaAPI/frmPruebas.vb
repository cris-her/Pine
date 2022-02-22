Imports API_IOL.API_IOL

Public Class FrmPruebas
    Dim API As API_IOL.API_IOL

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        API = New API_IOL.API_IOL(Application.StartupPath)

        CargarCombos()
        tmUpdateTokens.Start()
    End Sub
    Private Sub CargarCombos()
        cbxPais.Items.Add("argentina")
        cbxPais.Items.Add("estados_Unidos")
    End Sub


    Private Sub OnbtnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click

        If API.Login(txtUsuario.Text, txtClave.Text) Then
            lbAccess_Token.Text = API.Token.Access_Token
            lbRefresh_Token.Text = API.Token.Refresh_Token
        Else
            lbAccess_Token.Text = ""
            lbRefresh_Token.Text = ""
            MsgBox(API.MensajeError)
        End If
    End Sub

    Private Sub OnbtnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        Clipboard.SetText(lbAccess_Token.Text)
    End Sub

    Private Sub OnbtnPruebaEstadoDeCuenta_Click(sender As Object, e As EventArgs) Handles btnPruebaEstadoDeCuenta.Click

        Dim Estado As API_IOL.API_IOL.EstadoDeCuentas = API.ObtenerEstadoDeCuentas()

        If Not Estado.HuboError Then
            Dim Salida As String = ""

            Salida &= Estado.Cuentas(0).Moneda & ": " & Estado.Cuentas(0).Saldo & vbNewLine
            Salida &= "Disponible: " & Estado.Cuentas(0).Saldo & vbNewLine
            Salida &= "--------------------------------------   " & vbNewLine

            For Each s As Saldo In Estado.Cuentas(0).Saldos
                Salida &= "Liquidación: " & s.Liquidacion & vbNewLine & "       Disponible:" & s.Disponible & "  Disponible para operar:" & s.DisponibleOperar & vbNewLine
            Next

            txtRespuesta.Text = Salida
        Else
            txtSalida.Text = "Hubo un error:" & vbNewLine & Estado.DescripcionError & " json:" & Estado.Json

        End If

    End Sub

    Private Sub OnbtnPortafolio_Click(sender As Object, e As EventArgs) Handles btnPortafolio.Click
        lvActivos.Items.Clear()

        Dim portafolio As API_IOL.API_IOL.Portafolio = API.ObtenerPortafolio()
        If portafolio.TodoOk Then
            For Each a As API_IOL.API_IOL.Activo In portafolio.Activos
                Dim i As ListViewItem = lvActivos.Items.Add(a.Titulo.Simbolo)
                i.SubItems.Add(a.Titulo.Descripcion)
                i.SubItems.Add(a.Cantidad.ToString("0"))
                i.SubItems.Add(Format(a.UltimoPrecio, "0.00").Replace(",", "."))
                i.SubItems.Add(Format(a.PPC, "0.00").Replace(",", "."))
                i.SubItems.Add(Format(a.Valorizado, "0.00").Replace(",", "."))
                i.SubItems.Add(Format(a.GananciaPorcentaje, "0.00").Replace(",", "."))
                i.SubItems.Add(Format(a.GananciaDinero, "0.00").Replace(",", "."))
            Next
        End If


    End Sub

    Private Sub OnbtnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click

        Dim desc As API_IOL.API_IOL.Descripcion_Simbolo = API.ObtenerDescripcion(txtSimbolo.Text)
        If desc.TodoOk Then
            txtRespuesta.Text = desc.Simbolo & ": " & desc.Descripcion & vbNewLine
            txtRespuesta.Text &= desc.Mercado & " : " & desc.Tipo & vbNewLine
            txtRespuesta.Text &= "Plazo: " & desc.Plazo
        Else
            txtSalida.Text = "Error: " & desc.DescripcionError & vbNewLine & "Json:" & desc.Json
        End If

    End Sub

    Private Sub OnbtnPanel_Click(sender As Object, e As EventArgs) Handles btnPanel.Click

        Dim sPais As String = cbxPais.Text
        Dim sInstrumento As String = cbxInstrumento.Text
        Dim sPanel As String = cbxPanel.Text

        Dim p As API_IOL.API_IOL.Panel = API.ObtenerCotizacionesPanel(cbxPanel.Text, cbxInstrumento.Text, cbxPais.Text)
        If p.TodoOk Then
            lvPanel.Items.Clear()
            For Each t As Titulo In p.Titulos
                Dim i As ListViewItem = lvPanel.Items.Add(t.Simbolo)
                i.SubItems.Add(t.UltimoPrecio.FormatoImporte())
                i.SubItems.Add(t.VariacionPorcentual.FormatoImporte())
                If t.Puntas Is Nothing Then
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                Else
                    i.SubItems.Add(t.Puntas.CantidadCompra.ToString("0"))
                    i.SubItems.Add(t.Puntas.PrecioCompra.FormatoImporte())
                    i.SubItems.Add(t.Puntas.PrecioVenta.FormatoImporte())
                    i.SubItems.Add(t.Puntas.CantidadVenta.ToString("0").Replace(",", "."))
                End If
                i.SubItems.Add(t.Volumen.ToString("0"))
            Next
        Else
            txtSalida.Text = p.DescripcionError
            txtSalida.Text &= vbNewLine & p.Json
        End If

    End Sub

    Private Sub OnlvActivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvActivos.SelectedIndexChanged
        If lvActivos.SelectedItems.Count = 0 Then Exit Sub
        txtSimboloVenta.Text = lvActivos.SelectedItems(0).SubItems(0).Text
        txtCantidadVenta.Text = Val(lvActivos.SelectedItems(0).SubItems(2).Text)
        txtPrecioVenta.Text = Val(lvActivos.SelectedItems(0).SubItems(3).Text)

    End Sub

    Private Sub OnbtnVender_Click(sender As Object, e As EventArgs) Handles btnVender.Click
        Dim Respuesta As RespuestaOrden = API.Vender(txtSimboloVenta.Text, Val(txtCantidadVenta.Text), Val(txtPrecioVenta.Text))
        If Respuesta.TodoOK Then
            txtSalida.Text = "La orden de venta se envió, Nro orden:" & Respuesta.NumeroOperacion
        Else
            txtSalida.Text = Respuesta.DescripcionError
        End If

    End Sub

    Private Sub OnvPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvPanel.SelectedIndexChanged
        If lvPanel.SelectedItems.Count = 0 Then Exit Sub
        txtSimboloCompra.Text = lvPanel.SelectedItems(0).SubItems(0).Text
        txtPrecioCompra.Text = Val(lvPanel.SelectedItems(0).SubItems(1).Text)
        txtCantidadCompra.Text = ""
    End Sub

    Private Sub OnbtnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click
        Dim Respuesta As RespuestaOrden = API.Comprar(txtSimboloCompra.Text, Val(txtCantidadCompra.Text), Val(txtPrecioCompra.Text))
        If Respuesta.TodoOK Then
            txtSalida.Text = "La orden de compra se envió correctamente, nro orden: " & Respuesta.NumeroOperacion
        Else
            txtSalida.Text = Respuesta.DescripcionError
        End If
    End Sub

    Private Sub OnbtnRefreshOrdenes_Click(sender As Object, e As EventArgs) Handles btnRefreshOrdenes.Click

        lvOrdenes.Items.Clear()
        Dim sEstado As String = IIf(chkSoloPendientes.Checked, "pendientes", "todas")
        Dim OrdenesPendientes As Ordenes = API.ObtenerOrdenes(Estado:=sEstado)
        If OrdenesPendientes.TodoOk Then
            For Each o As Orden In OrdenesPendientes.Operaciones
                Dim item As ListViewItem = lvOrdenes.Items.Add(o.Numero)
                item.SubItems.Add(o.Simbolo)
                item.SubItems.Add(o.Estado)
                item.SubItems.Add(o.FechaOrden)
                item.SubItems.Add(o.Modalidad)
                item.SubItems.Add(o.Tipo)
                item.SubItems.Add(NZ(o.Cantidad))
                item.SubItems.Add(NZ(o.CantidadOperada))
                item.SubItems.Add(NZ(o.Precio))
                item.SubItems.Add(NZ(o.PrecioOperado))
            Next

        Else
            txtSalida.Text = "Hubo un error" & OrdenesPendientes.DescripcionError
        End If
    End Sub


    Private Sub OnbtnOpciones_Click(sender As Object, e As EventArgs) Handles btnOpciones.Click

        Dim LasOpciones As Opciones = API.ObtenerOpciones(txtSimboloOpciones.Text)
        If LasOpciones.HuboError Then
            txtSalida.Text = "Error al obtener las opciones de activo " & txtSimboloOpciones.Text & vbNewLine
            txtSalida.Text &= LasOpciones.DescripcionError
        Else
            Dim s As String = "Opciones de : " & LasOpciones.SimboloSubyacente & vbNewLine
            s &= "--------------------------------------------------" & vbNewLine
            For Each o As DatosOpcion In LasOpciones.ListaDeOpciones
                s &= o.Simbolo & "   " & o.Descripcion & "  ---> " & o.Cotizacion.UltimoPrecio & "(" & o.Cotizacion.Variacion & " %)" & vbNewLine
            Next
            txtRespuesta.Text = s
        End If




    End Sub

    Private Sub OnbtnConsutarPuntas_Click(sender As Object, e As EventArgs) Handles btnConsutarPuntas.Click
        Dim Coti As Cotizacion = API.ObtenerCotizacion(txtSimboloPuntas.Text, txtPlazo.Text)
        If Coti.TodoOk Then
            Dim s As String = txtSimboloPuntas.Text & ":" & vbNewLine
            s &= "Ultimo:" & Coti.UltimoPrecio.FormatoImporte() & vbNewLine
            s &= "Variación:" & Coti.Variacion.FormatoImporte() & vbNewLine
            s &= "Máximo:" & Coti.Maximo.FormatoImporte() & vbNewLine
            s &= "Mínimo:" & Coti.Minimo.FormatoImporte() & vbNewLine
            s &= "Cantidad Operaciones:" & Coti.CantidadOperaciones.ToString("0").Replace(",", ".") & vbNewLine
            s &= "Monto Operado:" & Coti.MontoOperado.FormatoImporte() & vbNewLine
            txtRespuesta.Text = s

            lvPuntas.Items.Clear()
            For Each p In Coti.Puntas
                Dim i As ListViewItem = lvPuntas.Items.Add(NZ(p.CantidadVenta).ToString("0"))
                i.SubItems.Add(NZ(p.PrecioCompra).FormatoImporte())
                i.SubItems.Add(NZ(p.PrecioVenta).FormatoImporte())
                i.SubItems.Add(NZ(p.CantidadCompra).ToString("0"))

            Next

        Else
            txtSalida.Text = Coti.DescripcionError
        End If

    End Sub





    Private Function NZ(n As ValueType) As Decimal
        If n Is Nothing Then
            Return 0
        End If
        Return n
    End Function

    Private Sub OncbxPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPais.SelectedIndexChanged
        If cbxPais.SelectedIndex <> -1 Then
            cbxInstrumento.Items.Clear()
            cbxPanel.Items.Clear()
            Dim pais As Pais = API.ObtenerInstrumentos(cbxPais.Text)
            If pais.TodoOk Then
                For Each i As Instrumento In pais.ListaInstrumentos
                    cbxInstrumento.Items.Add(i.Instrumento)
                Next
            End If
        End If

    End Sub

    Private Sub OncbxInstrumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxInstrumento.SelectedIndexChanged
        If cbxInstrumento.SelectedIndex <> -1 Then
            cbxPanel.Items.Clear()
            Dim paneles As Paneles = API.ObtenerNombrePaneles(cbxInstrumento.Text, cbxPais.Text)
            If paneles.TodoOk Then
                For Each p As UnPanel In paneles.ListaDePaneles
                    cbxPanel.Items.Add(p.Panel)
                Next
            End If
        End If

    End Sub

    Private Sub OntmUpdateTokens_Tick(sender As Object, e As EventArgs) Handles tmUpdateTokens.Tick
        If API.Token Is Nothing Then Exit Sub
        lbAccess_Token.Text = API.Token.Access_Token
        lbRefresh_Token.Text = API.Token.Refresh_Token
        Dim seg As Long = DateDiff(DateInterval.Second, Now, API.Token.Time_Token)
        If seg < 0 Then
            lbVence.Text = "vencido"
        Else
            lbVence.Text = seg
        End If

    End Sub

    Private Sub OnlvOrdenes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvOrdenes.SelectedIndexChanged
        If lvOrdenes.SelectedItems.Count > 0 Then
            Dim Nro_Orden As Long = Val(lvOrdenes.SelectedItems(0).Text)

            Dim orden As Orden = API.ObtenerOrden(Nro_Orden)
            If orden.TodoOk Then
                Dim s As String = ""
                s &= "Nro transaccion:" & orden.Numero & vbNewLine
                s &= "Simbolo: " & orden.Simbolo & vbNewLine
                s &= "Tipo orperacion: " & orden.Tipo & vbNewLine
                s &= "Cantidad :" & orden.Cantidad & "  Precio:" & orden.Precio & vbNewLine

                txtSalida.Text = s
            End If


        End If
    End Sub

    Private Sub OnbtnADRs_Click(sender As Object, e As EventArgs) Handles btnADRs.Click
        Dim p As API_IOL.API_IOL.Panel = API.ObtenerCotizacionesADRs()
        If p.TodoOk Then
            lvPanel.Items.Clear()
            For Each t As Titulo In p.Titulos
                Dim i As ListViewItem = lvPanel.Items.Add(t.Simbolo)
                i.SubItems.Add(t.UltimoPrecio.FormatoImporte())
                i.SubItems.Add(t.VariacionPorcentual.FormatoImporte())
                If t.Puntas Is Nothing Then
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                Else
                    i.SubItems.Add(t.Puntas.CantidadCompra.FormatoImporte("0"))
                    i.SubItems.Add(t.Puntas.PrecioCompra.FormatoImporte())
                    i.SubItems.Add(t.Puntas.PrecioVenta.FormatoImporte())
                    i.SubItems.Add(t.Puntas.CantidadVenta.FormatoImporte("0"))
                End If
                i.SubItems.Add(t.Volumen.FormatoImporte("0"))
            Next
        Else
            txtSalida.Text = p.DescripcionError
            txtSalida.Text &= vbNewLine & p.Json
        End If

    End Sub

    Private Sub OnbtnConsultaHistorica_Click(sender As Object, e As EventArgs) Handles btnConsultaHistorica.Click

        Dim historico As DatosHistoricos = API.ObtenerDatosHistoricos(txtSimboloHistorico.Text, CDate(txtDesde.Text), CDate(txtHasta.Text))
        If historico.TodoOk Then

            lvHistorico.Items.Clear()
            For Each c As Cotizacion In historico.Series
                Dim item As ListViewItem = lvHistorico.Items.Add(c.FechaHora.ToString("dd-MM-yyyy"))
                item.SubItems.Add(c.UltimoPrecio.FormatoImporte)
                item.SubItems.Add(c.Apertura.FormatoImporte)
                item.SubItems.Add(c.Maximo.FormatoImporte)
                item.SubItems.Add(c.Minimo.FormatoImporte)
                item.SubItems.Add(c.VolumenNominal.FormatoImporte("0"))
                item.SubItems.Add(c.MontoOperado.FormatoImporte)
            Next

            If chkExportartCSV.Checked Then

                Dim dialogo As New SaveFileDialog With {
                    .Filter = "Excel *.CSV|*.csv",
                    .Title = "Exportar a Excel",
                    .InitialDirectory = Application.StartupPath
                }

                If dialogo.ShowDialog = DialogResult.OK Then
                    If historico.ExportarCSV(dialogo.FileName) Then
                        MsgBox("Exportación a Excel correcta")
                    Else
                        MsgBox("No se pudo exportar")
                    End If
                End If
            End If

        Else
            txtSalida.Text = historico.DescripcionError
        End If


    End Sub

    Private Sub OnbtnEliminarOrdene_Click(sender As Object, e As EventArgs) Handles btnEliminarOrdene.Click
        If lvOrdenes.SelectedItems.Count = 0 Then
            MsgBox("Debe selecionar una orden pendiente para poder cancelar")
        End If
        Dim nro_orden As Integer = Val(lvOrdenes.SelectedItems(0).Text)
        Dim operacion As RespuestaOrden = API.CancelarOrden(nro_orden)
        If operacion.TodoOK Then
            MsgBox("La orden se cancelo correctame")
            Call OnbtnRefreshOrdenes_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub OnbtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Not API.RefrescarToken() Then
            MsgBox("no se pudo refrescar token")
        End If
    End Sub
End Class

