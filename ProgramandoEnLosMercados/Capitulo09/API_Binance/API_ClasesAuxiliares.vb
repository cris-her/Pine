Imports System.Text
Imports System.Net
Imports System.Security.Cryptography
Imports Newtonsoft
Imports WebSocket4Net
Imports SuperSocket.ClientEngine
Namespace ClasesAuxiliares
    Public Class Solicitud
        Inherits Respuesta

        Public Property EndPoint As String = ""
        Public Property Metodo As String = ""
        Public Property Firmar As Boolean = False

        Public Property ForzarEnviarAPIKEy As Boolean = False

        Public Property TimeStamp As Boolean = False

        Public Property RecvWindows As Integer = 5000

        Public Property Parametros As Dictionary(Of String, String)

        Public Property URL As String = ""

        Public Property FechaYHoraServer As Long =0
        Public Sub New()
            Parametros = New Dictionary(Of String, String)
            URL = Spot.URL
        End Sub


        Public Function Send() As String
            Me.DescripcionError = ""
            Try
                Dim Respuesta As String = ""

                Dim sParametros As String = ""
                If TimeStamp Then
                    'sParametros = "recvWindow=" & RecvWindows & "&timestamp=" & Utilidades.ConvertirAFechaBinance(Now)
                    sParametros = "recvWindow=" & RecvWindows & "&timestamp=" & FechaYHoraServer
                End If
                For Each par As KeyValuePair(Of String, String) In Parametros
                    sParametros &= IIf(sParametros.Length = 0, "", "&") & par.Key & "=" & par.Value
                Next

                If Firmar Then
                    Dim Firma As String = Cifrar(sParametros, Configuracion.API_Secret)
                    sParametros &= "&signature=" & Firma
                End If
                Dim sURL As String = URL + EndPoint
                Dim bParametros() As Byte = Nothing

                If Metodo = "GET" Then
                    sURL &= "?" & sParametros
                Else
                    bParametros = Encoding.UTF8.GetBytes(sParametros)
                End If
                Debug.Print("url: " + sURL)
                Debug.Print("parametro:" + sParametros)
                Dim solicitud As WebRequest = WebRequest.Create(sURL)
                solicitud.PreAuthenticate = True
                solicitud.Method = Metodo
                If Firmar Or ForzarEnviarAPIKEy Then
                    solicitud.Headers.Add("X-MBX-APIKEY", Configuracion.API_Key)
                End If

                If Metodo <> "GET" Then
                    If bParametros.Length > 0 Then

                        solicitud.ContentType = "application/x-www-form-urlencoded"
                        solicitud.ContentLength = bParametros.Length
                        Using flujo = solicitud.GetRequestStream
                            flujo.Write(bParametros, 0, bParametros.Length)
                            flujo.Close()
                        End Using
                    End If
                End If

                Using flujo = solicitud.GetResponse.GetResponseStream
                    Using lector As New IO.StreamReader(flujo)
                        Respuesta = lector.ReadToEnd
                    End Using
                End Using


                Return Respuesta
            Catch ex As Exception
                Me.DescripcionError = ex.Message
                Return ""
            End Try
        End Function

        Private Function Cifrar(dato As String, Clave_Privada As String) As String
            Dim dato_bytes() As Byte = Encoding.UTF8.GetBytes(dato)
            Dim clave_bytes() As Byte = Encoding.UTF8.GetBytes(Clave_Privada)

            Dim hmac As HMACSHA256 = New HMACSHA256(clave_bytes)
            Dim codificado() As Byte = hmac.ComputeHash(dato_bytes)
            Dim respuesta As String = BitConverter.ToString(codificado)
            respuesta = respuesta.Replace("-", "").ToLower
            Return respuesta
        End Function
    End Class
    Public Class SolicitudFapi
        Inherits Solicitud
        Public Sub New()
            Parametros = New Dictionary(Of String, String)
            URL = Futuro.URL
        End Sub
    End Class


    Public Class Respuesta
        Public Property DescripcionError As String = ""
        Public Property JSon As String = ""

        Public Property Code As Integer
        Public Property Msg As String
        Public ReadOnly Property TodoOk As Boolean
            Get
                Return DescripcionError = ""
            End Get
        End Property
        Public ReadOnly Property HuboError As Boolean
            Get
                Return Not TodoOk
            End Get
        End Property
    End Class



    '===================================================== WEB SOCKET ================================================
    Public Class WebSocket

        Public Event OnConectado()
        Public Event OnNuevoPrecio(precio As Precio)
        Public Event OnError(mensaje As String)



        Public Property Escuchando As New List(Of String)

        Private ws As WebSocket4Net.WebSocket = Nothing


        Private huboError As Boolean = False
        Private abierto As Boolean = False




        Public URL As String
        Public Sub New(Optional url As String = "wss://stream.binance.com:9443/ws")
            Me.URL = url
        End Sub
        Public Sub InicializarWS()
            If ws IsNot Nothing Then Exit Sub
            ws = New WebSocket4Net.WebSocket(Me.URL)

            AddHandler ws.Opened, AddressOf OnOpened
            AddHandler ws.Error, AddressOf OnErrorWS
            AddHandler ws.MessageReceived, AddressOf OnMensajeRecibido
            ws.Open()
            Console.WriteLine("Inicializado WebSocket")
        End Sub

        Private Sub OnErrorWS(sender As Object, e As ErrorEventArgs)
            RaiseEvent OnError(e.Exception.Message)
        End Sub

        Private Sub OnOpened(sender As Object, e As EventArgs)
            Debug.Print("Abrio ws")
            abierto = True
        End Sub
        Private Sub OnMensajeRecibido(sender As Object, e As MessageReceivedEventArgs)
            Try
                If e.Message.Contains("result") Then
                    Debug.Print(e.Message)
                    Exit Sub
                End If

                Dim dic As DatosEventos = Json.JsonConvert.DeserializeObject(Of DatosEventos)(e.Message)
                If dic.TipoEvento = "trade" Then
                    Buffer.Actualizar(dic.Simbolo, dic.Precio, dic.Fecha)
                    RaiseEvent OnNuevoPrecio(New Precio(dic.Simbolo, dic.Precio, dic.Cantidad, dic.Fecha))
                End If
            Catch ex As Exception
                Debug.Print("Error:" + e.Message)
            End Try
        End Sub




        Public Sub Close()
            Try
                If ws IsNot Nothing And abierto Then
                    ws.Close()
                End If
            Catch ex As Exception

            End Try

        End Sub


#Region "Suscripcion y des suscripcion WebSocket "


        Public Function Escuchar(Simbolo As String) As Boolean
            huboError = False
            If Escuchando.Contains(Simbolo.ToUpper) Then Return True
            If ws Is Nothing Then Return False

            If huboError Then
                Return False
            End If
            Return Registrar(Simbolo)
        End Function

        Public Function Escuchar(Simbolos As List(Of String)) As Boolean
            huboError = False
            If ws Is Nothing Then Return False
            Return Registrar(Simbolos)
        End Function


        Public Function DejarDeEscuchar(Simbolo As String) As Boolean
            huboError = False
            If Not Escuchando.Contains(Simbolo.ToUpper) Then Return True
            If ws Is Nothing Then Return False

            If huboError Then
                Return False
            End If
            Return DesRegistrar(Simbolo)
        End Function

        Private Function Registrar(simbolo As String) As Boolean
            Try
                Dim sus As New Suscribir With {
                    .method = "SUBSCRIBE",
                    .id = 1
                }
                sus.params.Add(simbolo.ToLower & "@trade")

                Dim s As String = Json.JsonConvert.SerializeObject(sus)
                ws.Send(s)
                Escuchando.Add(simbolo.ToUpper)
                Return True
            Catch ex As Exception
                'Padre.MensajeError = ex.Message
                Return False
            End Try
        End Function
        Private Function Registrar(simbolos As List(Of String)) As Boolean
            Try
                Dim sus As New Suscribir With {
                    .method = "SUBSCRIBE",
                    .id = 1
                }
                For Each st As String In simbolos
                    sus.params.Add(st.ToLower & "@trade")
                Next


                Dim s As String = Json.JsonConvert.SerializeObject(sus)
                ws.Send(s)
                For Each st As String In simbolos
                    Escuchando.Add(st.ToUpper)
                Next

                Return True
            Catch ex As Exception
                'Padre.MensajeError = ex.Message
                Return False
            End Try
        End Function

        Private Function DesRegistrar(simbolo As String) As Boolean
            Try
                Dim sus As New Suscribir With {
                    .method = "UNSUBSCRIBE",
                    .id = 132
                }
                sus.params.Add(simbolo & "@trade")

                Dim s As String = Json.JsonConvert.SerializeObject(sus)
                ws.Send(s)
                Escuchando.Add(simbolo.ToUpper)
                Return True
            Catch ex As Exception
                'Padre.MensajeError = ex.Message
                Return False
            End Try
        End Function

#End Region



#Region "Clases de uso con WebSocket"


#Disable Warning IDE1006 ' Estilos de nombres
        Private Class Suscribir
            Public Property method As String

            Public Property params As New List(Of String)
            Public Property id As Integer
        End Class
#Enable Warning IDE1006 ' Estilos de nombres
        Private Class Precio_Binance
            Public Property S As String
            Public Property P As String
            Public Property Q As String
            Public Property T As Long
        End Class


        Public Class DatosEventos
            Inherits Dictionary(Of String, String)

            Public Shared Widening Operator CType(ByVal texto As String) As DatosEventos
                If texto.Contains("outboundAccountPosition") Then
                    Return New DatosEventos
                End If
                Dim dicccionario As DatosEventos = Json.JsonConvert.DeserializeObject(Of DatosEventos)(texto)
                Return dicccionario
            End Operator


            Public ReadOnly Property TipoEvento As String
                Get
                    Try
                        Return Me("e")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Fecha As DateTime
                Get
                    Try
                        Return Utilidades.ConvertirAFecha(Val(Me("E")))
                    Catch ex As Exception
                        Return Nothing
                    End Try
                End Get
            End Property
            Public ReadOnly Property Simbolo As String
                Get
                    Try
                        Return Me("s")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property

            Public ReadOnly Property Precio As Decimal
                Get
                    Try
                        Return Val(Me("p"))
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Cantidad As Decimal
                Get
                    Try
                        Return Val(Me("q"))
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property

            Public ReadOnly Property Lado As String
                Get
                    Try
                        Return Me("S")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property TipoOrden As String
                Get
                    Try
                        Return Me("o")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Novedad As String
                Get
                    Try
                        Return Me("x")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property

        End Class


#Disable Warning IDE1006 ' Estilos de nombres
        Public Class DatosEventosFuturos
            Public Property e As String

            Public Property T As Long
            Public Property O As Dictionary(Of String, String)


            Public Shared Widening Operator CType(ByVal texto As String) As DatosEventosFuturos
                Dim dicccionario As DatosEventosFuturos = Json.JsonConvert.DeserializeObject(Of DatosEventosFuturos)(texto)
                Return dicccionario
            End Operator

            Public ReadOnly Property TipoEvento As String
                Get
                    Try
                        Return e
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Simbolo As String
                Get
                    Try
                        If O Is Nothing Then
                            Return ""
                        End If
                        Return O("s")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Lado As String
                Get
                    Try
                        Return O("S")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property TipoOperacion As String
                Get
                    Try
                        Return O("o")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Cantidad As Decimal
                Get
                    Try
                        If O Is Nothing Then
                            Return 0
                        End If
                        If O("q") IsNot Nothing Then
                            Return O("q")
                        End If
                        Return 0
                    Catch ex As Exception
                        Return 0
                    End Try
                End Get
            End Property
            Public ReadOnly Property Precio As Decimal
                Get
                    Try
                        Return O("p")
                    Catch ex As Exception
                        Return 0
                    End Try
                End Get
            End Property
            Public ReadOnly Property Novedad As String
                Get
                    Try
                        If O Is Nothing Then
                            Return ""
                        End If

                        Return O("X")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property IdOrden As String
                Get
                    Try
                        Return O("c")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property CantidadCompletada As Decimal
                Get
                    Try
                        Return O("z")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property Comision As Decimal
                Get
                    Try
                        Return O("n")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
            Public ReadOnly Property ComisionMoneda As String
                Get
                    Try
                        Return O("N")
                    Catch ex As Exception
                        Return ""
                    End Try
                End Get
            End Property
        End Class

#Enable Warning IDE1006 ' Estilos de nombres




#End Region

#Region "Buffe de prcios"



        Public ReadOnly Buffer As New Precios

        Public Class Precios
            Inherits Dictionary(Of String, Decimal)

            Public Property UltimaActualizacionServer As DateTime
            Public Property UltimaActualizacionLocal As DateTime

            Public Sub Actualizar(simbolo As String, precio As Decimal, Ahora As DateTime)
                Me.UltimaActualizacionServer = Ahora
                Me.UltimaActualizacionLocal = Now
                If Me.ContainsKey(simbolo) Then
                    Me(simbolo) = precio
                Else
                    Me.Add(simbolo, precio)
                End If
            End Sub

            Public Function Obtener(Simbolo As String) As Decimal
                If Me.ContainsKey(Simbolo) Then
                    Return Me(Simbolo)
                Else
                    Return 0.00
                End If
            End Function

            Public Function Actualizados() As Boolean
                Return Math.Abs(DateDiff(DateInterval.Second, Now, UltimaActualizacionLocal)) < 2        'Si la última actualización fue hace menos de 2 segundos
            End Function


        End Class

        Public Class Precio
            Public Property Simbolo As String
            Public Property Precio As Decimal
            Public Property Cantidad As Decimal
            Public Property Fecha As DateTime
            Public Sub New(simbolo As String, precio As Decimal, cantidad As Decimal, fecha As DateTime)
                Me.Simbolo = simbolo
                Me.Precio = precio
                Me.Cantidad = cantidad
                Me.Fecha = fecha
            End Sub
        End Class


#End Region

    End Class

    '===================================================== WEB SOCKET ================================================




End Namespace
