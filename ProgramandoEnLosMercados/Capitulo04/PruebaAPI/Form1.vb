Imports API_IOL.API_IOL

Public Class Form1
    Dim API As API_IOL.API_IOL

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        API = New API_IOL.API_IOL(Application.StartupPath)
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

        If Estado IsNot Nothing Then
            Dim Salida As String = ""


            Salida &= Estado.Cuentas(0).Moneda & ": " & Estado.Cuentas(0).Saldo & vbNewLine
            Salida &= "Disponible: " & Estado.Cuentas(0).Disponible & vbNewLine

            txtSalida.Text = Salida

        End If

    End Sub

    Private Sub OnbtnPortafolio_Click(sender As Object, e As EventArgs) Handles btnPortafolio.Click
        Dim portafolio As API_IOL.API_IOL.Portafolio = API.ObtenerPortafolio()

        lvActivos.Items.Clear()

        For Each a As API_IOL.API_IOL.Activo In portafolio.Activos

            Dim i As ListViewItem = lvActivos.Items.Add(a.Titulo.Simbolo)
            i.SubItems.Add(a.Titulo.Descripcion)
            i.SubItems.Add(a.Cantidad.ToString("0"))
            i.SubItems.Add(Format(a.UltimoPrecio, "0.00"))
            i.SubItems.Add(Format(a.PPC, "0.00"))
            i.SubItems.Add(Format(a.Valorizado, "0.00"))
            i.SubItems.Add(Format(a.GananciaPorcentaje, "0.00"))
            i.SubItems.Add(Format(a.GananciaDinero, "0.00"))


        Next

    End Sub

    Private Sub OnbtnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click

        Dim desc As API_IOL.API_IOL.Descripcion_Simbolo = API.ObtenerDescripcion(txtSimbolo.Text)
        If desc IsNot Nothing Then

            txtSalida.Text = desc.Simbolo & ": " & desc.Descripcion & vbNewLine
            txtSalida.Text &= desc.Tipo
        End If

    End Sub

    Private Sub OnbtnPanel_Click(sender As Object, e As EventArgs) Handles btnPanel.Click

        Dim p As API_IOL.API_IOL.Panel = API.ObtenerCotizacionesPanel(txtPanel.Text, txtInstrumento.Text)
        If p IsNot Nothing Then
            lvPanel.Items.Clear()
            For Each t As Titulo In p.Titulos
                Dim i As ListViewItem = lvPanel.Items.Add(t.Simbolo)
                i.SubItems.Add(t.UltimoPrecio.ToString("0.00"))
                i.SubItems.Add(t.VariacionPorcentual.ToString("0.00"))
                If t.Puntas Is Nothing Then
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                    i.SubItems.Add("")
                    i.SubItems.Add("")

                Else
                    i.SubItems.Add(t.Puntas.CantidadCompra.ToString("0"))
                    i.SubItems.Add(t.Puntas.PrecioCompra.ToString("0.00"))
                    i.SubItems.Add(t.Puntas.PrecioVenta.ToString("0.00"))
                    i.SubItems.Add(t.Puntas.CantidadVenta.ToString("0"))

                End If
                i.SubItems.Add(t.Volumen.ToString("0"))
            Next
        End If

    End Sub

    Private Sub OnlvActivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvActivos.SelectedIndexChanged
        If lvActivos.SelectedItems.Count = 0 Then Exit Sub
        txtSimboloVenta.Text = lvActivos.SelectedItems(0).SubItems(0).Text
        txtCantidad.Text = Val(lvActivos.SelectedItems(0).SubItems(2).Text)
        txtPrecioVenta.Text = Val(lvActivos.SelectedItems(0).SubItems(3).Text)

    End Sub

    Private Sub OnbtnVender_Click(sender As Object, e As EventArgs) Handles btnVender.Click
        txtSalida.Text = API.Vender(txtSimboloVenta.Text, Val(txtCantidad.Text), Val(txtPrecioVenta.Text))
    End Sub
End Class
