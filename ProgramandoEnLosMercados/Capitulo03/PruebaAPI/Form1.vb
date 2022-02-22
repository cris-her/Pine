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
            i.SubItems.Add(a.Cantidad)
            i.SubItems.Add(Format(a.UltimoPrecio, "0.00"))
            i.SubItems.Add(Format(a.PPC, "0.00"))
            i.SubItems.Add(Format(a.Valorizado, "0.00"))
            i.SubItems.Add(Format(a.GananciaPorcentaje, "0.00"))
            i.SubItems.Add(Format(a.GananciaDinero, "0.00"))


        Next

    End Sub
End Class
