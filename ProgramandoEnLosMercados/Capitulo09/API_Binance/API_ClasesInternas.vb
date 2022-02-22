
Public Class ClasesInternas

    Public Class ExchangeInfo
        Public Property TimeZone As String
        Public Property SerrverTime As Long
        Public Property Symbols As List(Of Symbol_Binance)

    End Class

    Public Class Symbol_Binance
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


    Public Class Filters_Binance
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

        Public Property Limit As Integer
        Public Property MaxNumOrders As Long
        Public Property MaxNumAlgoOrders As Long

    End Class




    Public Class Account_Binance
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

        Public Property Assets As List(Of Asset)
        Public Property TotalWalletBalance As String


        Public Property Positions As List(Of Balance_Position)

    End Class

    Public Class Asset
        Public Property Asset As String
        Public Property WalletBalance As String

        Public Property PositionAmt As String

    End Class

    Public Class Balance_Binance
        Public Property Asset As String
        Public Property Free As String
        Public Property Locked As String
    End Class


    Public Class Balance_Position
        Public Property Symbol As String
        Public Property UnrealizedProfit As String
        Public Property PositionAmt As String
        Public Property Leverage As String

    End Class



    Public Class Depth
        Public Property LastUpdateId As Long
        Public Property Bids As List(Of List(Of String))
        Public Property Asks As List(Of List(Of String))

    End Class


    Public Class Price
        Public Property Symbol As String
        Public Property Price As Decimal
    End Class



    Public Class Trade
        Public Property Id As Long
        Public Property Price As Decimal
        Public Property Qty As Decimal
        Public Property QuoteQty As Decimal
        Public Property Time As Long
        Public Property IsBuyerMaker As Boolean
        Public Property IsBestMatch As Boolean
    End Class


    Public Class Orders_Binance
        Inherits List(Of Order_Binance)
    End Class

    Public Class Order_Binance
        Public Property Symbol As String
        Public Property OrigClientOrderId As String
        Public Property OrderId As Long
        Public Property OrderListId As Long
        Public Property ClientOrderId As String
        Public Property Price As String
        Public Property OrigQty As String
        Public Property ExecutedQty As String
        Public Property CummulativeQuoteQty As String
        Public Property Status As String
        Public Property TimeInForce As String
        Public Property Type As String
        Public Property Side As String

        Public Property StopPrice As String
        Public Property IcebergQty As String
        Public Property Time As Long
        Public Property UpdateTime As Long

        Public Property IsWorking As Boolean

        Public Property OrigQuoteOrderQty As String

        Public Property ContingencyType As String

        Public Property ListStatusType As String

        Public Property ListOrderStatus As String

        Public Property ListClientOrderId As String

        Public Property TransactionTime As Long



        Public Property Orders As List(Of Orders_Binance_Order)

        Public Property OrderReports As List(Of Order_Binance)

        Public Property Fills As List(Of Order_Binance_Fill)

    End Class

    Public Class Orders_Binance_Order
        Public Property Symbol As String
        Public Property OrderId As Long
        Public Property ClientOrderId As String
    End Class

    Public Class Order_Binance_Fill
        Public Property Price As String
        Public Property Qty As String
        Public Property Commission As String
        Public Property CommissionAsset As String
        Public Property TradeId As Long
    End Class



    Public Class Futuros

        '=========================== ExchangeInfo =========================================================
        Public Class RateLimit
            Public Property RateLimitType As String
            Public Property Interval As String
            Public Property IntervalNum As Integer
            Public Property Limit As Integer
        End Class

        Public Class Asset
            Public Property Asset As String
            Public Property MarginAvailable As Boolean
            Public Property AutoAssetExchange As String
        End Class

        Public Class Filter
            Public Property MinPrice As String
            Public Property MaxPrice As String
            Public Property FilterType As String
            Public Property TickSize As String
            Public Property StepSize As String
            Public Property MaxQty As String
            Public Property MinQty As String
            Public Property Limit As Integer?
            Public Property Notional As String
            Public Property MultiplierDown As String
            Public Property MultiplierUp As String
            Public Property MultiplierDecimal As String
        End Class

        Public Class Symbol
            Public Property Symbol As String
            Public Property Pair As String
            Public Property ContractType As String
            Public Property DeliveryDate As Object
            Public Property OnboardDate As Object
            Public Property Status As String
            Public Property MaintMarginPercent As String
            Public Property RequiredMarginPercent As String
            Public Property BaseAsset As String
            Public Property QuoteAsset As String
            Public Property MarginAsset As String
            Public Property PricePrecision As Integer
            Public Property QuantityPrecision As Integer
            Public Property BaseAssetPrecision As Integer
            Public Property QuotePrecision As Integer
            Public Property UnderlyingType As String
            Public Property UnderlyingSubType As String()
            Public Property SettlePlan As Integer
            Public Property TriggerProtect As String
            Public Property Filters As Filter()
            Public Property OrderTypes As String()
            Public Property TimeInForce As String()
        End Class

        Public Class ExcangeInfoFuture
            Public Property Timezone As String
            Public Property ServerTime As Long
            Public Property FuturesType As String
            Public Property RateLimits As RateLimit()
            Public Property ExchangeFilters As Object()
            Public Property Assets As Asset()
            Public Property Symbols As Symbol()
        End Class

        '==================================================================================================
        Public Class ServerTime
            Public Property ServerTime As Long
        End Class



    End Class

End Class
