Imports Newtonsoft
Imports WebSocket4Net
Imports SuperSocket.ClientEngine
Namespace ClasesAuxiliares


    Public Class API_Spot_Ordenes
        ReadOnly Padre As Spot
        Public Sub New(padre As Spot)
            Me.Padre = padre
        End Sub


#Region "Metodos para Operar"


        Public Function ComprarMarket(simbolo As String, cantidad As Decimal, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Return OperarMarket(simbolo, cantidad, True, ClienteOrdenID)
        End Function
        Public Function VenderMarket(simbolo As String, cantidad As Decimal, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Return OperarMarket(simbolo, cantidad, False, ClienteOrdenID)
        End Function

        Public Function ComprarLimit(simbolo As String, cantidad As Decimal, precio As Decimal, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Return OperarLimit(simbolo, cantidad, precio, True, ClienteOrdenID)
        End Function
        Public Function VenderLimit(simbolo As String, cantidad As Decimal, precio As Decimal, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Return OperarLimit(simbolo, cantidad, precio, False, ClienteOrdenID)
        End Function


        Private Function OperarLimit(simbolo As String, cantidad As Decimal, precio As Decimal, comprar As Boolean, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/order",
                .Metodo = "POST",
                .Firmar = True,
                .TimeStamp = True
            }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                .Add("side", IIf(comprar, "BUY", "SELL"))
                .Add("type", "LIMIT")
                .Add("quantity", cantidad.FormatoBinance)
                .Add("price", precio.FormatoBinance)
                .Add("timeInForce", "GTC")
                If ClienteOrdenID <> "" Then
                    .Add("newClientOrderId", ClienteOrdenID)
                End If
            End With
            Dim respuesta As String = ""
            Try
                respuesta = Solicitud.Send()
                If respuesta = "" Then Return New ClasesBinance.Orden With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = respuesta
                }
                Dim orden As ClasesBinance.Orden = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Order_Binance)(respuesta)
                With orden
                    orden.DescripcionError = Solicitud.DescripcionError
                    orden.JSon = respuesta
                End With
                Return orden
            Catch ex As Exception
                Return New ClasesBinance.Orden With {
                    .DescripcionError = ex.Message,
                    .JSon = respuesta
                }
            End Try
        End Function

        Public Function OperarMarket(simbolo As String, cantidad As Decimal, comprar As Boolean, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/order",
                .Metodo = "POST",
                .Firmar = True,
                .TimeStamp = True
            }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                .Add("side", IIf(comprar, "BUY", "SELL"))
                .Add("type", "MARKET")
                .Add("quantity", cantidad.FormatoBinance)
                If ClienteOrdenID <> "" Then
                    .Add("newClientOrderId", ClienteOrdenID)
                End If
            End With
            Dim respuesta As String = ""
            Try
                respuesta = Solicitud.Send()
                If respuesta = "" Then Return New ClasesBinance.Orden With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = respuesta
                }
                Dim orden As ClasesBinance.Orden = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Order_Binance)(respuesta)
                With orden
                    .DescripcionError = Solicitud.DescripcionError
                    .JSon = respuesta
                End With
                Return orden
            Catch ex As Exception
                Return New ClasesBinance.Orden With {
                    .DescripcionError = ex.Message,
                    .JSon = respuesta
                }
            End Try
        End Function

        Public Function OperarStopLoss(simbolo As String, cantidad As Decimal, precio As Decimal, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/order",
                .Metodo = "POST",
                .Firmar = True,
                .TimeStamp = True
            }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                .Add("side", "SELL")
                .Add("type", "STOP_LOSS")
                .Add("quantity", cantidad.FormatoBinance)
                .Add("stopPrice", precio.FormatoBinance)
                If ClienteOrdenID <> "" Then
                    .Add("newClientOrderId", ClienteOrdenID)
                End If
            End With
            Dim respuesta As String = ""
            Try
                respuesta = Solicitud.Send()
                If respuesta = "" Then Return New ClasesBinance.Orden With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = respuesta
                }
                Dim orden As ClasesBinance.Orden = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Order_Binance)(respuesta)
                With orden
                    .DescripcionError = ""
                    .JSon = respuesta
                End With
                Return orden
            Catch ex As Exception
                Return New ClasesBinance.Orden With {
                    .DescripcionError = ex.Message,
                    .JSon = respuesta
                }
            End Try
        End Function


        Public Function OrdenStopLossLimit(simbolo As String, cantidad As Decimal, precio As Decimal, precioLimit As Decimal, Optional ClienteOrdenID As String = "") As ClasesBinance.Orden
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/order",
                .Metodo = "POST",
                .Firmar = True,
                .TimeStamp = True
            }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                .Add("side", "SELL")
                .Add("type", "STOP_LOSS_LIMIT")
                .Add("quantity", cantidad.FormatoBinance)
                .Add("stopPrice", precio.FormatoBinance)
                .Add("price", precioLimit.FormatoBinance)
                If ClienteOrdenID <> "" Then
                    .Add("newClientOrderId", ClienteOrdenID)
                End If
                .Add("timeInForce", "GTC")
            End With
            Dim respuesta As String = ""
            Try
                respuesta = Solicitud.Send()
                If respuesta = "" Then Return New ClasesBinance.Orden With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = respuesta
                }
                Dim orden As ClasesBinance.Orden = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Order_Binance)(respuesta)
                With orden
                    .DescripcionError = ""
                    .JSon = respuesta
                End With
                Return orden
            Catch ex As Exception
                Return New ClasesBinance.Orden With {
                    .DescripcionError = ex.Message,
                    .JSon = respuesta
                }
            End Try
        End Function

        Public Function CancelarTodasLasOrdenesPendientesDeUnSimbolo(simbolo As String, Optional ClienteOrdenID As String = "") As ClasesBinance.Ordenes
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/openOrders",
                .Metodo = "DELETE",
                .Firmar = True,
                .TimeStamp = True
            }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                If ClienteOrdenID <> "" Then
                    .Add("newClientOrderId", ClienteOrdenID)
                End If
            End With
            Dim respuesta As String = ""
            Try
                respuesta = Solicitud.Send()
                If respuesta = "" Then Return New ClasesBinance.Ordenes With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = respuesta
                }
                Dim orden As ClasesBinance.Ordenes = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Orders_Binance)(respuesta)
                With orden
                    .DescripcionError = ""
                    .JSon = respuesta
                End With
                Return orden
            Catch ex As Exception
                Return New ClasesBinance.Ordenes With {
                    .DescripcionError = ex.Message,
                    .JSon = respuesta,
                    .ListaDeOrdenes = New List(Of ClasesBinance.Orden)
                }
            End Try
        End Function



        Public Function OrdenVentaOCO(simbolo As String, Id_Orden As String, cantidad As Decimal, precioTP As Decimal, precioStopTrigger As Decimal, precioSL As Decimal) As ClasesBinance.Orden
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/order/oco",
                .Metodo = "POST",
                .Firmar = True,
                .TimeStamp = True
                }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                .Add("side", "SELL")
                .Add("quantity", cantidad.FormatoBinance)
                .Add("price", precioTP.FormatoBinance)
                .Add("stopPrice", precioStopTrigger.FormatoBinance)
                .Add("stopLimitPrice", precioSL.FormatoBinance)
                .Add("stopLimitTimeInForce", "GTC")
            End With
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Orden With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Dim orden As ClasesBinance.Orden = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Order_Binance)(Respuesta)
                orden.DescripcionError = ""
                orden.JSon = Respuesta
                Return orden

            Catch ex As Exception
                Return New ClasesBinance.Orden() With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta}

            End Try

            Return Nothing
        End Function

        Public Function OrdenCompraOCO(simbolo As String, Id_Orden As String, cantidad As Decimal, precioTP As Decimal, precioStopTrigger As Decimal, precioSL As Decimal) As ClasesBinance.Orden
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/order/oco",
                .Metodo = "POST",
                .Firmar = True,
                .TimeStamp = True
                }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)
                .Add("side", "BUY")
                .Add("quantity", cantidad.FormatoBinance)
                .Add("price", precioTP.FormatoBinance)
                .Add("stopPrice", precioStopTrigger.FormatoBinance)
                .Add("stopLimitPrice", precioSL.FormatoBinance)
                .Add("stopLimitTimeInForce", "GTC")
            End With
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Orden With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Dim orden As ClasesBinance.Orden = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Order_Binance)(Respuesta)
                orden.DescripcionError = ""
                orden.JSon = Respuesta
                Return orden

            Catch ex As Exception
                Return New ClasesBinance.Orden() With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta}

            End Try

            Return Nothing
        End Function


        Private Function ObtenerCantidadAOPerar(simbolo As String, Porcentaje As Decimal, compra As Boolean) As Decimal
            'Obtener la regla de este par de monedas
            Dim regla = Padre.Reglas.ObtenerSimbolo(simbolo)

            'Obtener la tenencia
            Dim tenencia = Padre.Consultas.ObtenerTenencia
            Dim Cantidad As Decimal = 0
            For Each t In tenencia.Monedas
                If Not compra And t.NombreMoneda = regla.MonedaBase Then
                    Cantidad = t.Disponible
                    Exit For
                End If
                If compra And t.NombreMoneda = regla.Contrapartida Then
                    Cantidad = t.Disponible / Padre.Precios.ObtenerPrecio(simbolo).Precio
                    Exit For
                End If
            Next
            Cantidad = (Porcentaje * Cantidad / 100) * 0.998 'descuenta la comision para calcular la maxíma cantidad para operar
            'Calcular la cantidad en base al porcentaje y la tenencia / redondea a los decimales correctos
            Return Utilidades.Truncar(Cantidad, regla.CantidadDecimalesCantidadMinima)
        End Function
#End Region

#Region "Consulta de ordenes"

        Public Function ObtenerEstadoOrdenesPendientes(simbolo As String, Optional ClienteOrdenId As String = "") As ClasesBinance.Ordenes
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/openOrders",
                .Metodo = "GET",
                .Firmar = True,
                .TimeStamp = True
            }
            Solicitud.Parametros.Add("symbol", simbolo.ToUpper)
            If ClienteOrdenId <> "" Then Solicitud.Parametros.Add("newClientOrderId", ClienteOrdenId)
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send()
                If Respuesta = "" Then Return New ClasesBinance.Ordenes() With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta,
                    .ListaDeOrdenes = New List(Of ClasesBinance.Orden)
                }
                Dim ob As ClasesInternas.Orders_Binance = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Orders_Binance)(Respuesta)
                Dim ordenes As ClasesBinance.Ordenes = ob
                ordenes.DescripcionError = ""
                ordenes.JSon = Respuesta
                Return ordenes
            Catch ex As Exception
                Return New ClasesBinance.Ordenes With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta,
                    .ListaDeOrdenes = New List(Of ClasesBinance.Orden)
                }
            End Try

        End Function


        Public Function ObtenerEstadoOrdenes(simbolo As String, Optional Desde As String = "", Optional Hasta As String = "", Optional limite As Integer = 500, Optional ClienteOrdenId As String = "") As ClasesBinance.Ordenes
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/allOrders",
                .Metodo = "GET",
                .Firmar = True,
                .TimeStamp = True
            }
            With Solicitud.Parametros
                .Add("symbol", simbolo.ToUpper)

                If IsDate(Desde) Then .Add("startTime", Utilidades.ConvertirAFechaBinance(CDate(Desde)))
                If IsDate(Hasta) Then .Add("endTime", Utilidades.ConvertirAFechaBinance(CDate(Hasta)))
                If limite <> 500 Then .Add("limit", limite)
                If ClienteOrdenId <> "" Then .Add("newClientOrderId", ClienteOrdenId)
            End With



            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send()
                If Respuesta = "" Then Return New ClasesBinance.Ordenes() With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta,
                    .ListaDeOrdenes = New List(Of ClasesBinance.Orden)
                }
                Dim ordenes As ClasesBinance.Ordenes = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Orders_Binance)(Respuesta)
                ordenes.DescripcionError = ""
                ordenes.JSon = Respuesta
                Return ordenes
            Catch ex As Exception
                Return New ClasesBinance.Ordenes With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta,
                    .ListaDeOrdenes = New List(Of ClasesBinance.Orden)
                }
            End Try

        End Function

#End Region

#Region "Eventos que generan los Trades"

        Public Event OnNuevaOperacion(operacion As WebSocket.DatosEventos)
        Private wsM As WebSocket4Net.WebSocket = Nothing

        Public Property ClaveDeEscucha As Binance_ListenKey
        Public Sub InicializarWS_Operaciones()
            If wsM IsNot Nothing Then Exit Sub

            ClaveDeEscucha = Binance_ListenKey.CargarDesdeArchivo(Spot.Carpeta & "\listen.dat")
            ActualizarClaveParaEscucharSiEsNecesario()

            If ClaveDeEscucha IsNot Nothing Then
                wsM = New WebSocket4Net.WebSocket("wss://stream.binance.com:9443/ws/" & ClaveDeEscucha.ListenKey)
                AddHandler wsM.Opened, AddressOf onOpenedM
                AddHandler wsM.Error, AddressOf onErrorWSM
                AddHandler wsM.MessageReceived, AddressOf onMensajeRecibidoM
                wsM.Open()
                Console.WriteLine("Inicializado WebSocket Operaciones Futuros")
            End If
        End Sub

        Private Sub OnMensajeRecibidoM(sender As Object, e As MessageReceivedEventArgs)
            Console.WriteLine("WSM:" & e.Message)
            Try
                Dim Dic As WebSocket.DatosEventos = e.Message
                If Dic.TipoEvento = "executionReport" Then
                    RaiseEvent OnNuevaOperacion(Dic)
                End If
            Catch ex As Exception
                Debug.Print("Error en WSM:" + ex.Message)
            End Try
        End Sub

        Private Sub OnErrorWSM(sender As Object, e As ErrorEventArgs)
            Console.WriteLine("WSM ERROR:" & e.Exception.Message)
        End Sub

        Private Sub OnOpenedM(sender As Object, e As EventArgs)
            Console.WriteLine("Abierto WSM:")
        End Sub

        Public Function ObtenerClaveParaEscuchar() As String
            Dim Solicitud As New Solicitud With {
                .EndPoint = "/api/v3/userDataStream",
                .Metodo = "POST",
                .Firmar = False,
                .ForzarEnviarAPIKEy = True,
                .TimeStamp = False
                }
            Try
                Dim Respuesta As String = Solicitud.Send
                ClaveDeEscucha = Json.JsonConvert.DeserializeObject(Of Binance_ListenKey)(Respuesta)
                If ClaveDeEscucha IsNot Nothing Then
                    If ClaveDeEscucha.ListenKey.Length > 0 Then
                        ClaveDeEscucha.FechaYHora = Now
                        ClaveDeEscucha.GuardarEnArchivo(Spot.Carpeta & "\listen.dat")
                        Return ClaveDeEscucha.ListenKey
                    End If
                    ClaveDeEscucha = New Binance_ListenKey
                End If
            Catch ex As Exception

            End Try
            Return ""
        End Function

        Public Sub ActualizarClaveParaEscuchar()
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/userDataStream",
                .Metodo = "PUT",
                .Firmar = True,
                .TimeStamp = True
                }
            Solicitud.Parametros.Add("listenKey", ClaveDeEscucha.ListenKey)
            Dim Respuesta As String = Solicitud.Send
            ClaveDeEscucha.FechaYHora = Now
            ClaveDeEscucha.GuardarEnArchivo(Spot.Carpeta & "\listen.dat")
        End Sub
        Public Sub EliminarClaveParaEscuchar()
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/userDataStream",
                .Metodo = "DELETE",
                .Firmar = True,
                .TimeStamp = True
                }
            Solicitud.Parametros.Add("listenKey", ClaveDeEscucha.ListenKey)
            Dim Respuesta As String = Solicitud.Send
            ClaveDeEscucha = New Binance_ListenKey
            IO.File.Delete(Spot.Carpeta & "\listen.dat")
        End Sub

        Public Function NecesitaActualizarClaveParaEscuchar() As Boolean
            If DateDiff(DateInterval.Minute, ClaveDeEscucha.FechaYHora, Now) > 55 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub ActualizarClaveParaEscucharSiEsNecesario()

            If Padre.Ordenes.ClaveDeEscucha Is Nothing Then
                ObtenerClaveParaEscuchar()
                Exit Sub
            End If
            If Padre.Ordenes.ClaveDeEscucha.ListenKey = "" Or NecesitaActualizarClaveParaEscuchar() Then
                ObtenerClaveParaEscuchar()
            End If
        End Sub


        Public Class Binance_ListenKey
            Public Property ListenKey As String

            Public Property FechaYHora As DateTime

            Public Function GuardarEnArchivo(Archivo As String) As Boolean
                Try
                    Dim sBuffer As String = Json.JsonConvert.SerializeObject(Me)
                    IO.File.WriteAllText(Archivo, sBuffer)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function
            Public Shared Function CargarDesdeArchivo(archivo As String) As Binance_ListenKey
                Try
                    Dim sBuffer As String = IO.File.ReadAllText(archivo)
                    Dim bl As Binance_ListenKey = Json.JsonConvert.DeserializeObject(Of Binance_ListenKey)(sBuffer)
                    Return bl
                Catch ex As Exception
                    Return New Binance_ListenKey
                End Try
            End Function
        End Class




#End Region


    End Class


    Public Class API_Spot_Consultas
        Public Padre As Spot
        Public Sub New(padre As Spot)
            Me.Padre = padre
        End Sub
        Public Function ObtenerEndPoint(EndPoint As String, Metodo As String, Firmar As Boolean, EnviarKey As Boolean, TimeStamp As Boolean, parametros As Dictionary(Of String, String)) As String
            Dim Solicitud As New Solicitud() With {
            .EndPoint = EndPoint,
            .Metodo = Metodo,
            .Firmar = Firmar,
            .ForzarEnviarAPIKEy = EnviarKey,
            .TimeStamp = TimeStamp
        }
            For Each p As KeyValuePair(Of String, String) In parametros
                Solicitud.Parametros.Add(p.Key, p.Value)
            Next
            Try
                Return Solicitud.Send
            Catch ex As Exception
                Return "Error: " & ex.Message
            End Try
        End Function


        Public Function ObtenerTenencia() As ClasesBinance.Tenencias
            Dim Solicitud As New Solicitud With {
                .EndPoint = "/api/v3/account",
                .Metodo = "GET",
                .Firmar = True,
                .TimeStamp = True
            }
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Tenencias With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Dim tenencia As ClasesBinance.Tenencias = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Account_Binance)(Respuesta)
                With tenencia
                    .DescripcionError = ""
                    .JSon = Respuesta
                End With
                Return tenencia
            Catch ex As Exception
                Return New ClasesBinance.Tenencias With {
                    .JSon = Respuesta,
                    .DescripcionError = "No se pudo obtener el balance," + ex.Message,
                    .Monedas = New List(Of ClasesBinance.Balance)
                }
            End Try
        End Function



        Public Function ObtenerRelgas() As ClasesBinance.Reglas
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/exchangeInfo",
                .Metodo = "GET"
            }
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Reglas With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Padre.Reglas = Json.JsonConvert.DeserializeObject(Of ClasesInternas.ExchangeInfo)(Respuesta)
                Padre.Reglas.DescripcionError = ""
                Padre.Reglas.JSon = Respuesta
                Padre.Reglas.Guardar(Spot.Carpeta & "\Reglas.json")
                Return Padre.Reglas
            Catch ex As Exception
                Return New ClasesBinance.Reglas With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta,
                    .Simbolos = New List(Of ClasesBinance.Simbolo)}
            End Try
        End Function


    End Class


    Public Class API_Spot_Precios


        Public Function ObtenerPuntas(Simbolo As String, limite As Integer) As ClasesBinance.Puntas
            Dim Solicitud As New Solicitud() With {
            .EndPoint = "/api/v3/depth",
            .Metodo = "GET",
            .Firmar = False,
            .ForzarEnviarAPIKEy = False,
            .TimeStamp = False
            }
            Solicitud.Parametros.Add("symbol", Simbolo)
            Solicitud.Parametros.Add("limit", limite)

            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Puntas With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Dim puntas As ClasesBinance.Puntas = Json.JsonConvert.DeserializeObject(Of ClasesInternas.Depth)(Respuesta)
                puntas.DescripcionError = ""
                puntas.JSon = Respuesta
                Return puntas
            Catch ex As Exception
                Return New ClasesBinance.Puntas() With {
                .DescripcionError = ex.Message,
                .JSon = Respuesta,
                .Compradores = New List(Of ClasesBinance.Punta),
                .Vendedores = New List(Of ClasesBinance.Punta)
            }
            End Try


        End Function

        Public Function ObtenerVelas(Simbolo As String, Intervalo As Utilidades.Intervalos, Optional desde As String = "", Optional hasta As String = "", Optional Limite As Integer = 500) As ClasesBinance.Velas
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/klines",
                .Metodo = "GET",
                .Firmar = False,
                .ForzarEnviarAPIKEy = False,
                .TimeStamp = False
            }
            With Solicitud.Parametros
                .Add("symbol", Simbolo)
                .Add("interval", Utilidades.GetIntervalo(Intervalo))
                If IsDate(desde) Then .Add("startTime", Utilidades.ConvertirAFechaBinance(CDate(desde)))
                If IsDate(hasta) Then .Add("endTime", Utilidades.ConvertirAFechaBinance(CDate(hasta)))
                If Limite <> 500 Then .Add("limit", Limite)
            End With
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Velas With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Return New ClasesBinance.Velas With {
                    .DescripcionError = "",
                    .JSon = Respuesta,
                    .ListaDeVelas = Utilidades.ConvertirAListaDeVelas(Respuesta)
                }
            Catch ex As Exception
                Return New ClasesBinance.Velas() With {
                .DescripcionError = ex.Message,
                .JSon = Respuesta,
                .ListaDeVelas = New List(Of ClasesBinance.Vela)
            }
            End Try


        End Function

        Public Function ObtenerPrecio(Simbolo As String) As ClasesBinance.Precio
            Dim Solicitud As New Solicitud With {
                .EndPoint = "/api/v3/ticker/price",
                .Metodo = "GET"
            }
            Solicitud.Parametros.Add("symbol", Simbolo.ToUpper)
            Try
                Dim Respuesta As String = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Precio(0, 0)
                Return Json.JsonConvert.DeserializeObject(Of ClasesInternas.Price)(Respuesta)
            Catch ex As Exception
                Return New ClasesBinance.Precio(0, 0)
            End Try
        End Function
        Public Function ObtenerPrecios() As ClasesBinance.Precios
            Dim Solicitud As New Solicitud With {
                .EndPoint = "/api/v3/ticker/price",
                .Metodo = "GET"
            }
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Precios With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Dim ListaPrecios As List(Of ClasesInternas.Price) = Json.JsonConvert.DeserializeObject(Of List(Of ClasesInternas.Price))(Respuesta)
                Dim precios As ClasesBinance.Precios = ListaPrecios
                precios.DescripcionError = ""
                precios.JSon = Respuesta
                Return precios
            Catch ex As Exception
                Return New ClasesBinance.Precios With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta,
                    .Simbolos = New List(Of ClasesBinance.Precio)
                }
            End Try
        End Function

        Public Function ObtenerOperaciones(Simbolo As String, Optional Limit As Integer = 500) As ClasesBinance.Operaciones
            Dim Solicitud As New Solicitud() With {
                .EndPoint = "/api/v3/trades",
                .Metodo = "GET"}
            Solicitud.Parametros.Add("symbol", Simbolo.ToUpper)
            If Limit <> 500 And Limit <= 1000 And Limit > 0 Then
                Solicitud.Parametros.Add("limit", Limit)
            End If
            Dim Respuesta As String = ""
            Try
                Respuesta = Solicitud.Send
                If Respuesta = "" Then Return New ClasesBinance.Operaciones With {
                    .DescripcionError = Solicitud.DescripcionError,
                    .JSon = Respuesta
                }
                Dim operaciones As ClasesBinance.Operaciones = Json.JsonConvert.DeserializeObject(Of List(Of ClasesInternas.Trade))(Respuesta)
                operaciones.JSon = Respuesta
                operaciones.DescripcionError = ""
                Return operaciones
            Catch ex As Exception
                Return New ClasesBinance.Operaciones With {
                    .DescripcionError = ex.Message,
                    .JSon = Respuesta,
                    .ListaDeOperaciones = New List(Of ClasesBinance.Operacion)}
            End Try
        End Function

    End Class


End Namespace
