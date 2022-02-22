
Class ClasesInternas

    Protected Friend Class ExchangeInfo
        Public Property TimeZone As String
        Public Property SerrverTime As Long
        Public Property Symbols As List(Of Symbol_Binance)


        Public Function ConvertirA_Regla() As ClasesBinance.Reglas
            Dim Reglas As New ClasesBinance.Reglas

            For Each sym As Symbol_Binance In Symbols
                Dim simbolo As New ClasesBinance.Simbolo With {
                    .Par = sym.Symbol,
                    .MonedaBase = sym.BaseAsset,
                    .Contrapartida = sym.QuoteAsset,
                    .CantidadDecimalesPrecioMinimo = ObtenerCantidadDecimalesPrecioMinimo(sym),
                    .CantidadDecimalesCantidadMinima = ObtenerCantidadDecimalesLoteMinimo(sym),
                    .Habilitado = IIf(sym.Status = "TRADING", True, False),
                    .PermiteSpot = sym.Permissions.Contains("SPOT"),
                    .PermiteFuturos = sym.Permissions.Contains("MARGIN")
                }

                Reglas.Add(simbolo)
            Next

            Return Reglas
        End Function
        Private Function ObtenerCantidadDecimalesPrecioMinimo(sym As Symbol_Binance) As Integer
            For Each f As ClasesInternas.Filters_Binance In sym.Filters
                If f.FilterType = "PRICE_FILTER" Then
                    Return GetCantidDecimales(f.MinPrice)
                End If
            Next
            Return 0
        End Function

        Private Function ObtenerCantidadDecimalesLoteMinimo(sym As Symbol_Binance) As Integer
            For Each f As ClasesInternas.Filters_Binance In sym.Filters
                If f.FilterType = "LOT_SIZE" Then
                    Return GetCantidDecimales(f.MinQty)
                End If
            Next
            Return 0
        End Function

        Private Function GetCantidDecimales(Texto As String) As Integer
            Dim s() As String = Split(Texto, ".")
            If s.Length <> 2 Then
                Return 0
            End If
            Dim c() As String = Split(s(1), "1")
            Return Len(c(0)) + 1
        End Function

    End Class

    Protected Friend Class Symbol_Binance
        Public Property Symbol As String
        Public Property Status As String
        Public Property BaseAsset As String
        Public Property BaseAssetsPrecision As Integer
        Public Property QuoteAsset As String
        Public Property QuoteAssetPrecision As Integer
        Public Property BaseComissionPrecision As Integer
        Public Property QuoteComissionPrecision As Integer
        Public Property OrderTypes As List(Of String)
        Public Property IcebergAllowed As Boolean
        Public Property OcoAllowed As Boolean
        Public Property QuoteORderQtyMarketAllowed As Boolean
        Public Property IsSpotTradingAllowed As Boolean
        Public Property IsMarginTradingAllowed As Boolean
        Public Property Filters As List(Of Filters_Binance)
        Public Property Permissions As List(Of String)
    End Class


    Protected Friend Class Filters_Binance
        Public Property FilterType As String
        Public Property MinPrice As String

        Public Property MaxPrice As String
        Public Property TickSize As String
        Public Property MultiplierUp As String
        Public Property MultiplierDown As String
        Public Property AvgPriceMins As Integer

        Public Property MinQty As String
        Public Property MaxQty As String
        Public Property MtepSize As String


        Public Property MinNotional As String
        Public Property MpplyToMarket As Boolean

        Public Property Mimit As Integer
        Public Property MaxNumOrders As Long
        Public Property MaxNumAlgoOrders As Long

    End Class




    Protected Friend Class Account_Binance
        Public Property MakerCommission As Decimal
        Public Property TakerCommission As Decimal
        Public Property BuyerCommission As Decimal

        Public Property SellerCommission As Decimal

        Public Property CanTrade As Boolean
        Public Property CanWithdraw As Boolean
        Public Property CanDeposit As Boolean

        Public Property UpdateTime As Long

        Public Property AccountType As String

        Public Property Balances As List(Of Balance_Binance)


        Public Property Permissions As List(Of String)

        Public Function ConvertirA_Tenencia() As List(Of ClasesBinance.Balance)

            Dim T As New List(Of ClasesBinance.Balance)

            For Each bb As Balance_Binance In Me.Balances
                Dim balance As New ClasesBinance.Balance With {
                    .NombreMoneda = bb.Asset,
                    .Disponible = Val(bb.Free),
                    .Trabado = Val(bb.Locked)
                }
                T.Add(balance)
            Next
            Return T
        End Function

    End Class

    Protected Friend Class Balance_Binance
        Public Property Asset As String
        Public Property Free As String
        Public Property Locked As String
    End Class



End Class
