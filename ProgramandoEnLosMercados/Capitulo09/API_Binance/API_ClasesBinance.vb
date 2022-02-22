Imports Newtonsoft

Public Class ClasesBinance

    Public Class Reglas
        Inherits ClasesAuxiliares.Respuesta

        Public Property Simbolos As New List(Of Simbolo)


        Public Function ObtenerSimbolo(Par As String) As Simbolo
            Return Me.Simbolos.Find(Function(x) x.Par = Par)
        End Function


        Public Function Guardar(Archivo As String) As Boolean
            Try
                IO.File.WriteAllText(Archivo, Newtonsoft.Json.JsonConvert.SerializeObject(Me))
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function Cargar(Archivo As String) As Reglas
            Try
                Dim sBuffer As String = IO.File.ReadAllText(Archivo)
                Dim r As Reglas = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Reglas)(sBuffer)
                Return r
            Catch ex As Exception
                Return New Reglas
            End Try
        End Function


        Public Shared Widening Operator CType(ByVal EI As ClasesInternas.ExchangeInfo) As Reglas
            Dim reglas As New Reglas
            For Each sym As ClasesInternas.Symbol_Binance In EI.Symbols
                Dim regla As New Simbolo With {
                    .Par = sym.Symbol,
                    .MonedaBase = sym.BaseAsset,
                    .Contrapartida = sym.QuoteAsset,
                    .CantidadDecimalesPrecioMinimo = ObtenerCantidadDecimalesPrecioMinimo(sym),
                    .CantidadDecimalesCantidadMinima = ObtenerCantidadDecimalesLoteMinimo(sym),
                    .Habilitado = IIf(sym.Status = "TRADING", True, False),
                    .PermiteSpot = sym.Permissions.Contains("SPOT"),
                    .PermiteFuturos = sym.Permissions.Contains("MARGIN")
                }
                reglas.Simbolos.Add(regla)
            Next

            Return reglas
        End Operator

        Private Shared Function ObtenerCantidadDecimalesPrecioMinimo(sym As ClasesInternas.Symbol_Binance) As Integer
            For Each f As ClasesInternas.Filters_Binance In sym.Filters
                If f.FilterType = "PRICE_FILTER" Then
                    Return GetCantidDecimales(f.MinPrice)
                End If
            Next
            Return 0
        End Function

        Private Shared Function ObtenerCantidadDecimalesLoteMinimo(sym As ClasesInternas.Symbol_Binance) As Integer
            For Each f As ClasesInternas.Filters_Binance In sym.Filters
                If f.FilterType = "LOT_SIZE" Then
                    Return GetCantidDecimales(f.MinQty)
                End If
            Next
            Return 0
        End Function

        Private Shared Function GetCantidDecimales(Texto As String) As Integer
            Dim s() As String = Split(Texto, ".")
            If s.Length <> 2 Then
                Return 0
            End If
            Dim c() As String = Split(s(1), "1")
            Return Len(c(0)) + 1
        End Function

    End Class

    Public Class Simbolo
        Public Property Par As String
        Public Property MonedaBase As String
        Public Property Contrapartida As String
        Public Property Habilitado As Boolean
        Public Property PermiteSpot As Boolean
        Public Property PermiteFuturos As Boolean
        Public Property CantidadDecimalesPrecioMinimo As Integer
        Public Property CantidadDecimalesCantidadMinima As Integer

    End Class


    Public Class Tenencias
        Inherits ClasesAuxiliares.Respuesta

        Public Property TotalBilletera As Decimal
        Public Property Monedas As New List(Of Balance)
        Public Shared Widening Operator CType(ByVal AB As ClasesInternas.Account_Binance) As Tenencias
            Dim tenencia As New Tenencias

            If AB.Balances IsNot Nothing Then
                For Each bb As ClasesInternas.Balance_Binance In AB.Balances
                    Dim B As New Balance With {
                    .NombreMoneda = bb.Asset,
                    .Disponible = Val(bb.Free),
                    .Trabado = Val(bb.Locked)
                }
                    tenencia.Monedas.Add(B)
                Next
            End If
            If AB.Assets IsNot Nothing Then
                tenencia.TotalBilletera = Val(AB.TotalWalletBalance)
                For Each bb As ClasesInternas.Asset In AB.Assets
                    Dim B As New Balance With {
                    .NombreMoneda = bb.Asset,
                    .Disponible = Val(bb.WalletBalance),
                    .Posicion = Val(bb.PositionAmt),
                    .PNL = Val(bb.PositionAmt),
                    .Trabado = 0
                    }
                    tenencia.Monedas.Add(B)
                Next

            End If
            If AB.Positions IsNot Nothing Then
                tenencia.TotalBilletera = Val(AB.TotalWalletBalance)
                For Each bb As ClasesInternas.Balance_Position In AB.Positions
                    Dim B As New Balance With {
                    .NombreMoneda = bb.Symbol,
                    .Posicion = Val(bb.PositionAmt),
                    .PNL = Val(bb.PositionAmt),
                    .Apalancamiento = Val(bb.Leverage)
                    }
                    tenencia.Monedas.Add(B)
                Next
            End If

            Return tenencia
        End Operator

        Public Function ObtenerBalance(ticker As String) As Balance
            For Each b As Balance In Monedas
                If b.NombreMoneda = ticker Then
                    Return b
                End If
            Next
            Return New Balance
        End Function

    End Class

    Public Class Balance
        Public Property NombreMoneda As String
        Public Property Disponible As Decimal
        Public Property Trabado As Decimal

        Public Property Posicion As Decimal
        Public Property PNL As Decimal

        Public Property Apalancamiento As Decimal

    End Class


    Public Class Puntas
        Inherits ClasesAuxiliares.Respuesta

        Public Property Compradores As New List(Of Punta)
        Public Property Vendedores As New List(Of Punta)

        Public Shared Widening Operator CType(ByVal dep As ClasesInternas.Depth) As Puntas
            Dim puntas As New Puntas

            If dep Is Nothing Then
                Return puntas
            End If

            For r As Integer = 0 To dep.Bids.Count - 1
                puntas.Compradores.Add(New Punta(Val(dep.Bids(r)(0)), Val(dep.Bids(r)(1))))
            Next
            For r As Integer = 0 To dep.Asks.Count - 1
                puntas.Vendedores.Add(New Punta(Val(dep.Asks(r)(0)), Val(dep.Asks(r)(1))))
            Next

            Return puntas
        End Operator

    End Class

    Public Class Punta
        Public Property Precio As Decimal
        Public Property Cantidad As Decimal
        Public Sub New(Precio As Decimal, Cantidad As Decimal)
            Me.Precio = Precio
            Me.Cantidad = Cantidad
        End Sub
    End Class

    '---------------------------------------------------------
    Public Class Velas
        Inherits ClasesAuxiliares.Respuesta
        Public Property ListaDeVelas As New List(Of Vela)
    End Class

    Public Class Vela
        Public Property FechaApertura As DateTime
        Public Property Apertura As Decimal
        Public Property Maximo As Decimal
        Public Property Minimo As Decimal
        Public Property Cierre As Decimal
        Public Property Volumen As Double
        Public Property FechaCierre As DateTime

        Public Property VolumenEnMoneda As Double
        Public Property Operaciones As Long
        Public Property VolumenEnMonedaBase As Decimal
        Public Property VolumenEnMonedaContraPartida As Decimal
    End Class

    '---------------------------------------------------------
    Public Class Precios
        Inherits ClasesAuxiliares.Respuesta
        Public Property Simbolos As New List(Of Precio)

        Public Shared Widening Operator CType(ByVal ListaPrice As List(Of ClasesInternas.Price)) As Precios
            Dim precios As New Precios

            For Each p As ClasesInternas.Price In ListaPrice
                precios.Simbolos.Add(New Precio(p.Symbol, Val(p.Price)))
            Next

            Return precios
        End Operator

    End Class

    Public Structure Precio
        Public Property Simbolo As String
        Public Property Precio As Decimal

        Public Sub New(simbolo As String, precio As Decimal)
            Me.Simbolo = simbolo
            Me.Precio = precio
        End Sub

        Public Shared Widening Operator CType(ByVal bp As ClasesInternas.Price) As Precio
            Return New Precio(bp.Symbol, Val(bp.Price))
        End Operator
    End Structure


    '--------------------------------------------------------

    Public Class Operaciones
        Inherits ClasesAuxiliares.Respuesta

        Public Property ListaDeOperaciones As New List(Of Operacion)

        Public Shared Widening Operator CType(ByVal ListaTrade As List(Of ClasesInternas.Trade)) As Operaciones
            Dim operaciones As New Operaciones

            For Each t As ClasesInternas.Trade In ListaTrade
                Dim operacion As New Operacion With {
                    .Fecha = Utilidades.ConvertirAFecha(Val(t.Time)),
                    .Precio = Val(t.Price),
                    .Cantidad = Val(t.Qty),
                    .CantidadMonedaBase = Val(t.QuoteQty)
                }
                operaciones.ListaDeOperaciones.Add(operacion)
            Next

            Return operaciones
        End Operator

    End Class

    Public Class Operacion
        Public Property Precio As Decimal
        Public Property Cantidad As Decimal
        Public Property CantidadMonedaBase As Decimal
        Public Property Fecha As DateTime
    End Class


    '-------------------------------------------------

    Public Class Ordenes
        Inherits ClasesAuxiliares.Respuesta

        Public Property ListaDeOrdenes As New List(Of Orden)

        Public Shared Widening Operator CType(ByVal OB As ClasesInternas.Orders_Binance) As Ordenes
            Dim ORDENES As New Ordenes

            For Each o As ClasesInternas.Order_Binance In OB
                Dim ORDEN As Orden = o
                ORDENES.ListaDeOrdenes.Add(ORDEN)
            Next
            Return ORDENES
        End Operator

    End Class

    Public Class Orden
        Inherits ClasesAuxiliares.Respuesta

        Public Property Simbolo As String
        Public Property ClienteIdOrigen As String
        Public Property OrdenId As Long
        Public Property OrdenListaId As Integer
        Public Property ClienteId As String

        Public Property Precio As Decimal
        Public Property Cantidad As Decimal
        Public Property CantidadOperada As Decimal
        Public Property CantidadMonedaContraPartida As Decimal
        Public Property Estado As String
        Public Property TimeInForce As String
        Public Property Tipo As String
        Public Property Lado As String

        Public Property PrecioDisparador As Decimal



        Public Property ContingenciaTipo As String
        Public Property ListaEstadoTipo As String
        Public Property ListaOrdenEstado As String

        Public Property ListaClienteOrdenId As String
        Public Property FechaTransaccion As DateTime

        Public Property Ordenes As New List(Of Orden_item)
        Public Property ReporteDeOrdenes As List(Of Orden)

        Public Property Rellenado As List(Of Orden_Relleno)


        Public Shared Widening Operator CType(ByVal order As ClasesInternas.Order_Binance) As Orden
            Dim ORDEN As New Orden
            If order Is Nothing Then Return Nothing

            ORDEN.Simbolo = order.Symbol
            ORDEN.OrdenId = order.OrderId
            ORDEN.OrdenListaId = Val(order.OrderListId)
            ORDEN.ClienteId = order.OrderListId
            ORDEN.Precio = Val(order.Price)
            ORDEN.Cantidad = Val(order.OrigQty)
            ORDEN.Estado = order.Status
            ORDEN.Tipo = order.Type
            ORDEN.Lado = order.Side
            ORDEN.PrecioDisparador = Val(order.StopPrice)



            ORDEN.Ordenes = New List(Of Orden_item)
            If order.Orders IsNot Nothing Then
                For Each r As ClasesInternas.Orders_Binance_Order In order.Orders
                    Dim nuevaOrden As New Orden_item With {
                        .Simbolo = r.Symbol,
                        .OrdenId = r.OrderId,
                        .ClienteId = r.ClientOrderId
                    }
                    ORDEN.Ordenes.Add(nuevaOrden)
                Next

            End If
            ORDEN.Rellenado = New List(Of Orden_Relleno)

            If order.Fills IsNot Nothing Then
                For Each r As ClasesInternas.Order_Binance_Fill In order.Fills
                    Dim no As New Orden_Relleno With {
                        .Precio = Val(r.Price),
                        .Cantidad = Val(r.Qty),
                        .Comision = Val(r.Commission),
                        .ComisionMoneda = r.CommissionAsset
                        }
                    ORDEN.Rellenado.Add(no)
                Next

            End If

            If order.OrderReports IsNot Nothing Then
                For Each r As ClasesInternas.Order_Binance In order.OrderReports
                    Dim no As New Orden With {
                        .Simbolo = order.Symbol,
                        .ClienteIdOrigen = order.OrigClientOrderId,
                        .OrdenId = order.OrderId,
                        .OrdenListaId = order.OrderListId,
                        .ClienteId = order.ClientOrderId,
                        .Precio = Val(order.Price),
                        .Cantidad = Val(order.OrigQty),
                        .CantidadOperada = Val(order.ExecutedQty),
                        .CantidadMonedaContraPartida = Val(order.CummulativeQuoteQty),
                        .Estado = order.Status,
                        .TimeInForce = order.TimeInForce,
                        .Tipo = order.Type,
                        .Lado = order.Side,
                        .ContingenciaTipo = order.ContingencyType,
                        .ListaEstadoTipo = order.ListStatusType,
                        .ListaOrdenEstado = order.ListOrderStatus,
                        .ListaClienteOrdenId = order.ListClientOrderId,
                        .FechaTransaccion = Utilidades.ConvertirAFecha(order.TransactionTime)
                    }
                    ORDEN.ReporteDeOrdenes.Add(no)
                Next
            End If

            Return ORDEN
        End Operator

    End Class

    Public Class Orden_item
        Public Property Simbolo As String
        Public Property OrdenId As Integer
        Public Property ClienteId As String

    End Class

    Public Class Orden_Relleno
        Public Property Precio As Decimal
        Public Property Cantidad As Decimal
        Public Property Comision As Decimal
        Public Property ComisionMoneda As String
        Public Property Id_Operacion As Long

    End Class



    Public Class Futuros
        Public Class Reglas
            Inherits ClasesAuxiliares.Respuesta

            Public Property Simbolos As New List(Of SimboloFuturo)


            Public Function ObtenerSimbolo(Simbolo As String) As SimboloFuturo
                Return Me.Simbolos.Find(Function(x) x.Simbolo = Simbolo)
            End Function


            Public Function Guardar(Archivo As String) As Boolean
                Try
                    IO.File.WriteAllText(Archivo, Newtonsoft.Json.JsonConvert.SerializeObject(Me))
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Shared Function Cargar(Archivo As String) As Reglas
                Try
                    Dim sBuffer As String = IO.File.ReadAllText(Archivo)
                    Dim r As Reglas = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Reglas)(sBuffer)
                    Return r
                Catch ex As Exception
                    Return New Reglas
                End Try
            End Function


            Public Shared Widening Operator CType(ByVal EI As ClasesInternas.Futuros.ExcangeInfoFuture) As Futuros.Reglas
                Dim reglas As New Futuros.Reglas
                For Each sym As ClasesInternas.Futuros.Symbol In EI.Symbols
                    Dim regla As New SimboloFuturo With {
                        .Simbolo = sym.Symbol,
                        .Par = sym.Pair,
                        .TipoContrato = sym.ContractType,
                        .FechaVencimiento = Utilidades.ConvertirAFecha(sym.DeliveryDate),
                        .FechaLanzamiento = Utilidades.ConvertirAFecha(sym.OnboardDate),
                        .MonedaBase = sym.BaseAsset,
                        .MonedaContraPartida = sym.QuoteAsset,
                        .MonedaMargen = sym.MarginAsset,
                        .CantidadDecimalesPrecioMinimo = sym.PricePrecision,
                        .CantidadDecimalesCantidadMinima = sym.QuantityPrecision,
                        .Habilitado = IIf(sym.Status = "TRADING", True, False)
                    }
                    reglas.Simbolos.Add(regla)
                Next

                Return reglas
            End Operator

        End Class

        Public Class SimboloFuturo
            Public Property Simbolo As String
            Public Property Par As String
            Public Property TipoContrato As String
            Public Property FechaVencimiento As Date
            Public Property FechaLanzamiento As Date
            Public Property Habilitado As Boolean
            Public Property MonedaBase As String
            Public Property MonedaContraPartida As String
            Public Property MonedaMargen As String
            Public Property CantidadDecimalesPrecioMinimo As Integer
            Public Property CantidadDecimalesCantidadMinima As Integer

        End Class

        Public Class FechaYHoraServer
            Inherits ClasesAuxiliares.Respuesta
            Public Property FechaYHora As Long

            Public Shared Widening Operator CType(ByVal server As ClasesInternas.Futuros.ServerTime) As FechaYHoraServer
                Dim f As New FechaYHoraServer With {
                    .FechaYHora = server.ServerTime
                }
                Return f
            End Operator
        End Class
    End Class

End Class
