Imports System.Text
Imports System.Net

Public Class API_IOL

    Private Usuario As String
    Private Clave As String
    Private ReadOnly CarpetaInterna As String

    Public Token As New Token

    Public MensajeError As String = ""
    Public Property URL = "https://api.invertironline.com/"

    Public Sub New(CarpetaInterna As String)
        Me.CarpetaInterna = CarpetaInterna

    End Sub
    Public Function Login(usuario As String, clave As String) As Boolean
        Me.Usuario = usuario
        Me.Clave = clave
        MensajeError = ""
        Try
            Dim sData As String = "grant_type=password&username=" & Me.Usuario & "&password=" & Me.Clave
            Dim data = Encoding.UTF8.GetBytes(sData)

            Dim respuesta As String = ""
            Dim solicitud As WebRequest = WebRequest.Create(URL + "token")
            solicitud.Method = "POST"
            solicitud.ContentType = "application/x-www-form-urlencoded"
            solicitud.ContentLength = data.Length

            Using solicitudStream = solicitud.GetRequestStream
                solicitudStream.Write(data, 0, data.Length)
                solicitudStream.Close()
            End Using

            Using respuestaStream = solicitud.GetResponse.GetResponseStream
                Using lector As New IO.StreamReader(respuestaStream)
                    respuesta = lector.ReadToEnd()
                End Using
            End Using

            Token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(respuesta)

            If Token.Access_Token.Length > 0 And Token.Refresh_Token.Length > 0 Then
                Return True
            Else
                MensajeError = "No se pudo obtener el token"
                Return False
            End If

            Return True
        Catch ex As Exception
            MensajeError = ex.Message
            Return False
        End Try
    End Function



    Public Function RefreshToken() As Boolean
        MensajeError = ""

        Return False
    End Function



End Class

Public Class Token
    Public Property Access_Token As String
    Public Property Refresh_Token As String
    Public Property Time_Token As DateTime

End Class
