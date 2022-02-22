Imports System.Text
Imports System.Net
Imports Newtonsoft

Public Class API_IOL

    Private Usuario As String
    Private Clave As String
    Private ReadOnly CarpetaInterna As String

    Public Token As New Token

    Public MensajeError As String = ""
    Public Property URL = "https://api.invertironline.com/"

    Public Sub New(CarpetaInterna As String)
        Me.CarpetaInterna = CarpetaInterna
        Me.Token = Token.CargarDesdeArchivo(CarpetaInterna & "\token.dat")
    End Sub


#Region "Login y manejo de Token"

    Public Function LoginOLD(usuario As String, clave As String) As Boolean
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


    Public Function Login(usuario As String, clave As String) As Boolean
        Me.Usuario = usuario
        Me.Clave = clave
        MensajeError = ""

        Dim solicitud As New Solicitudes(Me) With {
            .EndPoint = "token",
            .Metodo = "POST"
        }
        With solicitud
            .Parametros.Add("grant_type", "password")
            .Parametros.Add("username", usuario)
            .Parametros.Add("password", clave)
        End With

        Dim Respuesta As String = solicitud.Send(False)
        Token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(Respuesta)
        If Token Is Nothing Then
            MensajeError = "No se pudo obtener el token"
            Return False
        End If
        If Token.Access_Token.Length = 0 Then
            Return False
        End If
        Token.Time_Token = DateAdd(DateInterval.Minute, 15, Now)
        Token.GuardarEnAchivo(CarpetaInterna & "\token.dat")
        Return True
    End Function

    Public Function RefrescarTokenOLD() As Boolean
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

    Public Function RefrescarToken() As Boolean


        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "token",
            .Metodo = "POST"
        }
        With Solicitud
            .Parametros.Add("grant_type", "refresh_token")
            .Parametros.Add("refresh_token", Me.Token.Refresh_Token)
        End With

        Dim Respuesta As String = Solicitud.Send(False)
        Token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(Respuesta)
        If Token Is Nothing Then
            MensajeError = "No se pudo obtener el token"
            Return False
        End If
        If Token.Access_Token.Length = 0 Then
            Return False
        End If
        Token.Time_Token = DateAdd(DateInterval.Minute, 15, Now)
        Token.GuardarEnAchivo(CarpetaInterna & "\token.dat")

        Return True

    End Function


    Private Function EstamosEnRangoTiempo() As Boolean
        Return DateDiff(DateInterval.Second, Now, Me.Token.Time_Token) <= 0
    End Function


    Protected Friend Function VerificarToken() As Boolean
        If EstamosEnRangoTiempo() Then
            If Not RefrescarToken() Then
                If Not Login(Me.Usuario, Me.Clave) Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function


#End Region


#Region "Datos de cuentas y saldos"


    Public Function ObtenerEstadoDeCuentasOLD() As EstadoDeCuentas
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
    Public Function ObtenerEstadoDeCuentas() As EstadoDeCuentas
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/estadocuenta",
            .Metodo = "GET"
        }

        Dim Respuesta As String = Solicitud.Send

        Dim Resp As EstadoDeCuentas = JSonToObject(Of EstadoDeCuentas)(Respuesta)
        If Resp Is Nothing Then
            Return New EstadoDeCuentas() With {
                .Json = Respuesta,
                .DescripcionError = "Error: No se pudo obtener estdo de cuenta" & vbNewLine & MensajeError
            }
        Else
            Return Resp
        End If

    End Function



    Public Function ObtenerPortafolio(Optional Pais As String = "argentina") As Portafolio
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/portafolio/{pais}",
            .Metodo = "GET"
        }
        Solicitud.Paths.Add("{pais}", Pais)

        Dim Respuesta As String = Solicitud.Send
        Dim Resp As Portafolio = JSonToObject(Of Portafolio)(Respuesta)
        If Resp Is Nothing Then
            Return New Portafolio() With {
                .Json = Respuesta,
                .DescripcionError = MensajeError
            }
        Else
            Return Resp
        End If


    End Function

#End Region


#Region "Consultas en general"


    Public Function ObtenerDescripcionOLD(Simbolo As String, Optional Mercado As String = "bcba") As Descripcion_Simbolo
        MensajeError = ""
        Try
            If Not VerificarToken() Then
                MensajeError = "No se pudo obtener token"
                Return Nothing
            End If
            Dim respuesta As String = ""
            Dim solicitud As WebRequest = WebRequest.Create(URL + "api/v2/" & Mercado & "/Titulos/" & Simbolo)
            solicitud.Method = "GET"
            solicitud.Headers.Add("Authorization", "Bearer " + Me.Token.Access_Token)
            solicitud.PreAuthenticate = True

            Using respuestaStream = solicitud.GetResponse.GetResponseStream
                Using lector As New IO.StreamReader(respuestaStream)
                    respuesta = lector.ReadToEnd()
                End Using
            End Using

            Dim descripcion As Descripcion_Simbolo = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Descripcion_Simbolo)(respuesta)

            If descripcion IsNot Nothing Then
                Return descripcion
            Else
                MensajeError = "Error: No se pudieron obtener los datos del simbolo solicitado"
                Return Nothing
            End If


        Catch ex As Exception
            MensajeError = ex.Message
            Return Nothing
        End Try

    End Function


    Public Function ObtenerDescripcion(Simbolo As String, Optional Mercado As String = "bcba") As Descripcion_Simbolo
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/{mercado}/Titulos/{simbolo}",
            .Metodo = "GET"
        }

        Solicitud.Paths.Add("{mercado}", Mercado)
        Solicitud.Paths.Add("{simbolo}", Simbolo)


        Dim Respuesta As String = Solicitud.Send
        Dim Resp As Descripcion_Simbolo = JSonToObject(Of Descripcion_Simbolo)(Respuesta)
        If Resp Is Nothing Then
            Return New Descripcion_Simbolo() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta
            }
        Else
            Return Resp
        End If
    End Function


    Public Function ObtenerCotizacionesPanelOld(Panel As String, Instrumento As String, Optional Pais As String = "argentina") As Panel
        MensajeError = ""
        Try
            If Not VerificarToken() Then
                MensajeError = "No se pudo obtener token"
                Return Nothing
            End If
            Dim Parametros As String = "panelCotizacion.instrumento=" & Instrumento & "&panelCotizacion.panel=" & Panel
            Parametros &= "&panelCotizacion.pais=" & Pais
            Dim respuesta As String = ""
            Dim solicitud As WebRequest = WebRequest.Create(URL + "api/v2/Cotizaciones/" & Instrumento & "/" & Panel & "/" & Pais & "?" & Parametros)



            solicitud.Method = "GET"
            solicitud.Headers.Add("Authorization", "Bearer " + Me.Token.Access_Token)
            solicitud.PreAuthenticate = True

            Using respuestaStream = solicitud.GetResponse.GetResponseStream
                Using lector As New IO.StreamReader(respuestaStream)
                    respuesta = lector.ReadToEnd()
                End Using
            End Using

            Dim p As Panel = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Panel)(respuesta)

            If p IsNot Nothing Then
                Return p
            Else
                MensajeError = "Error: No se pudoieron obtener los datos del panel solicitado"
                Return Nothing
            End If


        Catch ex As Exception
            MensajeError = ex.Message
            Return Nothing
        End Try

    End Function


    Public Function ObtenerCotizacionesPanel(Panel As String, Instrumento As String, Optional Pais As String = "argentina") As Panel

        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/Cotizaciones/{Instrumento}/{Panel}/{Pais}",
            .Metodo = "GET"
        }
        With Solicitud
            .Paths.Add("{Instrumento}", Instrumento)
            .Paths.Add("{Panel}", Panel.Replace(" ", "%20"))
            .Paths.Add("{Pais}", Pais.Replace(" ", "%20"))

            .Parametros.Add("panelCotizacion.instrumento", Instrumento)
            .Parametros.Add("panelCotizacion.panel", Panel.Replace(" ", "%20"))
            .Parametros.Add("panelCotizacion.pais", Pais.Replace(" ", "_"))
        End With

        Dim Respuesta As String = Solicitud.Send
        Dim resp As Panel = JSonToObject(Of Panel)(Respuesta)
        If resp Is Nothing Then
            Return New Panel With {
                .DescripcionError = MensajeError,
                .Json = Respuesta
            }
        Else
            Return resp
        End If

    End Function

    Public Function ObtenerCotizacionesADRs() As Panel

        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/Cotizaciones/{Instrumento}/{Panel}/{Pais}",
            .Metodo = "GET"
        }
        With Solicitud
            .Paths.Add("{Instrumento}", "adrs")
            .Paths.Add("{Panel}", "argentina")
            .Paths.Add("{Pais}", "estados unidos".Replace(" ", "%20"))


            .Parametros.Add("panelCotizacion.instrumento", "aDRs")
            .Parametros.Add("panelCotizacion.panel", "argentina")
            .Parametros.Add("panelCotizacion.pais", "estados_Unidos")
        End With

        Dim Respuesta As String = Solicitud.Send
        Dim resp As Panel = JSonToObject(Of Panel)(Respuesta)
        If resp Is Nothing Then
            Return New Panel With {
                .DescripcionError = MensajeError,
                .Json = Respuesta
            }
        Else
            Return resp
        End If

    End Function


    Public Function ObtenerOpciones(Simbolo As String, Optional Mercado As String = "bcba") As Opciones

        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "/api/v2/{mercado}/Titulos/{simbolo}/Opciones",
            .Metodo = "GET"
        }
        Solicitud.Paths.Add("{simbolo}", Simbolo)
        Solicitud.Paths.Add("{mercado}", Mercado)

        Dim Respuesta As String = Solicitud.Send
        Dim Resp As DatosOpciones = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DatosOpciones)(Respuesta)
        If Resp Is Nothing Then
            Return New Opciones() With {
            .DescripcionError = MensajeError,
            .Json = Respuesta,
            .ListaDeOpciones = New List(Of DatosOpcion)
            }
        Else
            Return New Opciones With {
            .SimboloSubyacente = Simbolo,
            .ListaDeOpciones = Resp
            }
        End If


    End Function

    Public Function ObtenerCotizacion(Simbolo As String, Optional plazo As String = "T2", Optional Mercado As String = "BCBA") As Cotizacion
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/{Mercado}/Titulos/{Simbolo}/Cotizacion",
            .Metodo = "GET"}
        Solicitud.Paths.Add("{Mercado}", Mercado)
        Solicitud.Paths.Add("{Simbolo}", Simbolo)

        Solicitud.Parametros.Add("model.simbolo", Simbolo)
        Solicitud.Parametros.Add("model.mercado", Mercado)
        Solicitud.Parametros.Add("model.plazo", plazo)

        Dim Respuesta As String = Solicitud.Send
        Dim Resp As Cotizacion = JSonToObject(Of Cotizacion)(Respuesta)
        If Resp Is Nothing Then
            Return New Cotizacion() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta
            }
        Else
            Return Resp
        End If


    End Function

    Public Function ObtenerInstrumentos(Optional pais As String = "argentina") As Pais
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/{pais}/Titulos/Cotizacion/Instrumentos",
            .Metodo = "GET"
        }
        Solicitud.Paths.Add("{pais}", pais)

        Dim Respuesta As String = Solicitud.Send

        Dim Resp As RespuestaPais = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaPais)(Respuesta)
        If Resp Is Nothing Then
            Return New Pais() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta,
                .ListaInstrumentos = New RespuestaPais}
        Else
            Return New Pais() With {
                .DescripcionError = "",
                .Json = Respuesta,
                .ListaInstrumentos = Resp}
        End If
    End Function
    Public Function ObtenerNombrePaneles(Instrumento As String, Optional Pais As String = "argentina") As Paneles
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/{pais}/Titulos/Cotizacion/Paneles/{instrumento}",
            .Metodo = "GET"
        }
        Solicitud.Paths.Add("{pais}", Pais)
        Solicitud.Paths.Add("{instrumento}", Instrumento)

        Dim Respuesta As String = Solicitud.Send

        Dim Resp As VariosPaneles = Newtonsoft.Json.JsonConvert.DeserializeObject(Of VariosPaneles)(Respuesta)
        If Resp Is Nothing Then
            Return New Paneles() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta,
                .ListaDePaneles = New VariosPaneles}
        Else
            Return New Paneles() With {
                .DescripcionError = "",
                .Json = Respuesta,
                .ListaDePaneles = Resp}
        End If
    End Function



#End Region



#Region "Consulta de Ordenes / operaciones"

    Public Function ObtenerOrdenes(Optional Numero As Long = 0, Optional Estado As String = "todas", Optional Desde As DateTime = Nothing, Optional Hasta As DateTime = Nothing, Optional Pais As String = "argentina") As Ordenes
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "/api/v2/operaciones",
            .Metodo = "GET"
        }
        If Numero > 0 Then
            Solicitud.Parametros.Add("filtro.numero", Numero)
        End If
        Solicitud.Parametros.Add("filtro.estado", Estado)
        If Desde.Year > 2 Then
            Solicitud.Parametros.Add("filtro.fechaDesde", Format(Desde, "yyyy-MM-dd"))
        End If
        If Hasta.Year > 2 Then
            Solicitud.Parametros.Add("filtro.fechaHasta", Format(Hasta, "yyyy-MM-dd"))
        End If
        Solicitud.Parametros.Add("filtro.pais", Pais)

        Dim Respuesta As String = Solicitud.Send
        Dim ListaDeOperaciones As RespuestaOperaciones = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaOperaciones)(Respuesta)
        If ListaDeOperaciones Is Nothing Then
            Return New Ordenes With {
                .Json = Respuesta,
                .DescripcionError = MensajeError,
                .Operaciones = New RespuestaOperaciones()
            }
        Else
            Return New Ordenes With {
                .Json = Respuesta,
                .DescripcionError = "",
                .Operaciones = ListaDeOperaciones
            }
        End If
    End Function

    Public Function ObtenerOrden(Numero As Long) As Orden
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/operaciones/{numero}",
            .Metodo = "GET"
        }
        Solicitud.Paths.Add("{numero}", Numero)

        Dim Respuesta As String = Solicitud.Send
        Dim Resp As Orden = JSonToObject(Of Orden)(Respuesta)
        If Resp Is Nothing Then
            Return New Orden() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta
            }
        Else
            Return Resp
        End If

    End Function

    Public Function CancelarOrden(Numero As Long) As RespuestaOrden
        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "/api/v2/operaciones/{numero}",
            .Metodo = "DELETE"
        }
        Solicitud.Paths.Add("{numero}", Numero)

        Dim Respuesta As String = Solicitud.Send

        Dim Resp As RespuestaOrden = JSonToObject(Of RespuestaOrden)(Respuesta)
        If Resp Is Nothing Then
            Return New RespuestaOrden() With {
                .Json = Respuesta,
                .DescripcionError = MensajeError}
        Else
            Return Resp
        End If
    End Function



    Public Function ObtenerDatosHistoricos(Simbolo As String, FechaDesde As DateTime, FechaHasta As DateTime, Optional Mercado As String = "BCBA") As DatosHistoricos

        Dim sFechaDesde As String = Format(FechaDesde, "yyyy-MM-dd")
        Dim sFechaHasta As String = Format(FechaHasta, "yyyy-MM-dd")

        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/{mercado}/Titulos/{simbolo}/Cotizacion/seriehistorica/{fechaDesde}/{fechaHasta}/{ajustada}",
            .Metodo = "GET"
        }
        Solicitud.Paths.Add("{mercado}", Mercado)
        Solicitud.Paths.Add("{simbolo}", Simbolo)
        Solicitud.Paths.Add("{fechaDesde}", sFechaDesde)
        Solicitud.Paths.Add("{fechaHasta}", sFechaHasta)
        Solicitud.Paths.Add("{ajustada}", "ajustada")


        Dim Respuesta As String = Solicitud.Send
        Try
            Dim temp As List(Of Cotizacion) = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Cotizacion))(Respuesta)
            If temp Is Nothing Then
                Return New DatosHistoricos() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta,
                .Series = New List(Of Cotizacion)
            }
            Else
                Return New DatosHistoricos() With {
                .DescripcionError = "",
                .Json = Respuesta,
                .Series = temp}
            End If

        Catch ex As Exception
            Return New DatosHistoricos() With {
                .DescripcionError = MensajeError,
                .Json = Respuesta,
                .Series = New List(Of Cotizacion)
            }
        End Try
    End Function


#End Region



#Region "Operar"


    Public Function Vender(Simbolo As String, Cantidad As Integer, Precio As Decimal, Optional plazo As String = "t2", Optional DiasValidez As Integer = 0, Optional Mercado As String = "BCBA") As RespuestaOrden
        Return Operar("Vender", Simbolo, Cantidad, Precio, plazo, DiasValidez, Mercado)
    End Function

    Public Function Comprar(Simbolo As String, Cantidad As Integer, Precio As Decimal, Optional plazo As String = "t2", Optional DiasValidez As Integer = 0, Optional Mercado As String = "BCBA") As RespuestaOrden
        Return Operar("Comprar", Simbolo, Cantidad, Precio, plazo, DiasValidez, Mercado)
    End Function


    Private Function Operar(Sentido As String, Simbolo As String, Cantidad As Integer, Precio As Decimal, Optional plazo As String = "t2", Optional DiasValidez As Integer = 0, Optional Mercado As String = "BCBA") As RespuestaOrden

        Dim Solicitud As New Solicitudes(Me) With {
            .EndPoint = "api/v2/operar/" & Sentido,
            .Metodo = "POST"
        }

        Dim FechaVto As DateTime = DateAdd(DateInterval.Day, DiasValidez, Now)
        Dim sFechaVto As String = FechaVto.Year & "-" & FechaVto.Month & "-" & FechaVto.Day & "T17:59:59"

        With Solicitud
            .Parametros.Add("Mercado", Mercado)
            .Parametros.Add("Validez", sFechaVto)
            .Parametros.Add("simbolo", Simbolo)
            .Parametros.Add("cantidad", Cantidad)
            .Parametros.Add("precio", Precio.ToString("0.00").Replace(",", "."))
            .Parametros.Add("plazo", plazo)

        End With

        Dim Respuesta As String = Solicitud.Send

        Dim Resp As RespuestaOrden = JSonToObject(Of RespuestaOrden)(Respuesta)
        If Resp Is Nothing Then
            Return New RespuestaOrden With {
                .Json = Respuesta,
                .DescripcionError = MensajeError}
        Else
            Return Resp
        End If


    End Function

#End Region



#Region "Funciones Auxiliares"
    Public Function JSonToObject(Of T)(JSon As String) As T
        Try
            If JSon = "" Then
                Return Nothing
            End If
            Dim r As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)(JSon)
            CType(r, Respuesta).DescripcionError = ""
            CType(r, Respuesta).Json = JSon
            Return r
        Catch ex As Exception
            MensajeError = ex.Message
            Return Nothing
        End Try
    End Function
#End Region


End Class

Public Class Token
    Public Property Access_Token As String
    Public Property Refresh_Token As String
    Public Property Time_Token As DateTime


    Public Sub GuardarEnAchivo(archivo As String)
        Try

            IO.File.WriteAllText(archivo, Json.JsonConvert.SerializeObject(Me, Json.Formatting.Indented))
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function CargarDesdeArchivo(archivo As String) As Token
        Try
            Dim sjson As String = IO.File.ReadAllText(archivo)
            Dim token As Token = Json.JsonConvert.DeserializeObject(Of Token)(sjson)
            Return token
        Catch ex As Exception
            Return New Token
        End Try
    End Function
End Class
