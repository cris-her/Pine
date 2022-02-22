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
                Token.Time_Token = DateAdd(DateInterval.Minute, 15, Now)
                Return True
            Else
                MensajeError = "No se pudo obtener el token"
                Return False
            End If
        Catch ex As Exception
            MensajeError = ex.Message
            Return False
        End Try
    End Function
    Public Function RefrescarToken() As Boolean
        Me.Usuario = Usuario
        Me.Clave = Clave
        MensajeError = ""
        Try
            Dim sData As String = "grant_type=refresh_token&refresh_token=" + Me.Token.Refresh_Token
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

            Me.Token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(respuesta)

            If Token.Access_Token.Length > 0 And Token.Refresh_Token.Length > 0 Then
                Token.Time_Token = DateAdd(DateInterval.Minute, 15, Now)
                Return True
            Else
                MensajeError = "No se pudo obtener el token"
                Return False
            End If
        Catch ex As Exception
            MensajeError = ex.Message
            Return False
        End Try
    End Function

    Private Function EstamosEnRangoTiempo() As Boolean
        Return DateDiff(DateInterval.Second, Now, Me.Token.Time_Token) <= 0
    End Function


    Private Function VerificarToken() As Boolean
        If EstamosEnRangoTiempo() Then
            If Not RefrescarToken() Then
                If Not Login(Me.Usuario, Me.Clave) Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Public Function ObtenerEstadoDeCuentas() As EstadoDeCuentas
        MensajeError = ""
        Try
            If Not VerificarToken() Then
                MensajeError = "No se pudo obtener token"
                Return Nothing
            End If
            Dim respuesta As String = ""
            Dim solicitud As WebRequest = WebRequest.Create(URL + "api/v2/estadocuenta")
            solicitud.Method = "GET"
            solicitud.Headers.Add("Authorization", "Bearer " + Me.Token.Access_Token)
            solicitud.PreAuthenticate = True

            Using respuestaStream = solicitud.GetResponse.GetResponseStream
                Using lector As New IO.StreamReader(respuestaStream)
                    respuesta = lector.ReadToEnd()
                End Using
            End Using

            Dim Estado As EstadoDeCuentas = Newtonsoft.Json.JsonConvert.DeserializeObject(Of EstadoDeCuentas)(respuesta)

            If Estado IsNot Nothing Then
                Return Estado
            Else
                MensajeError = "Error: No se pudo obtener el estado de cuentas"
                Return Nothing
            End If


        Catch ex As Exception
            MensajeError = ex.Message
            Return Nothing
        End Try

    End Function

    Public Function ObtenerPortafolio(Optional Pais As String = "argentina") As Portafolio
        MensajeError = ""
        Try
            If Not VerificarToken() Then
                MensajeError = "No se pudo obtener token"
                Return Nothing
            End If
            Dim respuesta As String = ""
            Dim solicitud As WebRequest = WebRequest.Create(URL + "api/v2/portafolio/" + Pais)
            solicitud.Method = "GET"
            solicitud.Headers.Add("Authorization", "Bearer " + Me.Token.Access_Token)
            solicitud.PreAuthenticate = True

            Using respuestaStream = solicitud.GetResponse.GetResponseStream
                Using lector As New IO.StreamReader(respuestaStream)
                    respuesta = lector.ReadToEnd()
                End Using
            End Using

            Dim portafolio As Portafolio = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Portafolio)(respuesta)

            If portafolio IsNot Nothing Then
                Return portafolio
            Else
                MensajeError = "Error: No se pudo obtener el portafolio"
                Return Nothing
            End If


        Catch ex As Exception
            MensajeError = ex.Message
            Return Nothing
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
