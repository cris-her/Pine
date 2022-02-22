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
End Class
