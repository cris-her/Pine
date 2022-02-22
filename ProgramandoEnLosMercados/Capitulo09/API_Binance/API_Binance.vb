
Imports System.Text
Imports API_Binance.ClasesAuxiliares

Public Class Spot
    Inherits ClasesAuxiliares.Respuesta

    Public Shared Property Carpeta As String = ""

    Public Shared URL As String = "https://api.binance.com"

    Public Property WS_Precios As WebSocket


    Public Precios As API_Spot_Precios

    Public Ordenes As API_Spot_Ordenes

    Public Consultas As API_Spot_Consultas

    Public Reglas As ClasesBinance.Reglas = Nothing

    Public Sub New(Carpeta As String, Optional ApiKey As String = "", Optional SecretKey As String = "")
        If ApiKey <> "" Or SecretKey <> "" Then
            Configuracion.API_Key = ApiKey
            Configuracion.API_Secret = SecretKey
        End If


        Spot.Carpeta = Carpeta
        Precios = New API_Spot_Precios
        Ordenes = New API_Spot_Ordenes(Me)
        Consultas = New API_Spot_Consultas(Me)
        Reglas = ClasesBinance.Reglas.Cargar(Carpeta & "\Reglas.json")

        WS_Precios = New WebSocket()
        WS_Precios.InicializarWS()

        AddHandler WS_Precios.OnConectado, Sub()
                                               Console.WriteLine("CONECTADO A WS PRECIOS")
                                           End Sub
        AddHandler WS_Precios.OnNuevoPrecio, AddressOf Evento_nuevoPrecio


        Ordenes.InicializarWS_Operaciones()

    End Sub

    Private Sub Evento_nuevoPrecio(precio As WebSocket.Precio)

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        WS_Precios.Close()
        WS_Precios = Nothing
    End Sub



End Class


Public Class Margen

End Class


Public Class Futuro
    Inherits Respuesta

    Public Shared Property UltimoError As String = ""

    Public Shared Carpeta As String = ""

    Public Shared URL As String = "https://fapi.binance.com"

    Public Property WS_Futuros As WebSocket

    Public Property Ordenes As API_Futuros_Ordenes

    Public Property Precios As API_Futuros_Precios
    Public Property Consultas As API_Futuros_Consultas

    Public Property Reglas As ClasesBinance.Futuros.Reglas

    Public Sub New(Carpeta As String, Optional ApiKey As String = "", Optional SecretKey As String = "")
        If ApiKey <> "" Or SecretKey <> "" Then
            Configuracion.API_Key = ApiKey
            Configuracion.API_Secret = SecretKey
        End If


        'Inicializar las variables necesarias para gestionar los futuros
        Futuro.Carpeta = Carpeta
        Consultas = New API_Futuros_Consultas(Me)
        Reglas = ClasesBinance.Futuros.Reglas.Cargar(Carpeta & "\ReglasFuturos.json")
        Precios = New API_Futuros_Precios
        Ordenes = New API_Futuros_Ordenes(Me)

        'Prepara el WebSocket para escuchar los precios de futuros
        WS_Futuros = New WebSocket("wss://fstream.binance.com/ws")
        WS_Futuros.InicializarWS()
        AddHandler WS_Futuros.OnConectado, Sub()
                                               Console.WriteLine("CONECTADO A WS PRECIOS")
                                           End Sub
        AddHandler WS_Futuros.OnNuevoPrecio, AddressOf Evento_nuevoPrecioFuturo

        'Inicializa el WebSocket para escuchar las operaciones realizadas en futuros
        Ordenes.InicializarWS_Operaciones()

        If Reglas Is Nothing Then
            Reglas = Consultas.ObtenerRelgas()
        End If

    End Sub


    Private Sub Evento_nuevoPrecioFuturo(precio As WebSocket.Precio)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        WS_Futuros.Close()
        WS_Futuros = Nothing
    End Sub
End Class


Public Class Cauciones

End Class

Public Class Utilidades
    Public Shared Function ConvertirAFechaBinance(fecha As DateTime) As Long
        Return CLng(fecha.ToUniversalTime.Subtract(New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds)
    End Function
    Public Shared Function ConvertirAFecha(BinanceTime As Long) As DateTime
        Dim epoch = New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(BinanceTime)
        Return TimeZoneInfo.ConvertTime(epoch, TimeZoneInfo.Local)
    End Function

    Public Shared Function ConvertirAListaDeVelas(ListKlines As String) As List(Of ClasesBinance.Vela)
        Dim Velas As New List(Of ClasesBinance.Vela)
        Dim reg As New RegularExpressions.Regex("[0-9.]+")
        Dim encontradas As RegularExpressions.Match = reg.Match(ListKlines)

        Dim Posicion As Integer = -1
        Dim Vela As New ClasesBinance.Vela
        For Each match As RegularExpressions.Match In reg.Matches(ListKlines)
            Dim s = match
            Posicion += 1
            If Posicion >= 12 Then
                'Agregar a la lista
                Velas.Add(Vela)
                'inicializar posicion
                Posicion = 0
                Vela = New ClasesBinance.Vela
            End If
            Select Case Posicion
                Case 0
                    Vela.FechaApertura = Utilidades.ConvertirAFecha(Val(s.Value))
                Case 1
                    Vela.Apertura = Val(s.Value)
                Case 2
                    Vela.Maximo = Val(s.Value)
                Case 3
                    Vela.Minimo = Val(s.Value)
                Case 4
                    Vela.Cierre = Val(s.Value)
                Case 5
                    Vela.Volumen = Val(s.Value)
                Case 6
                    Vela.FechaCierre = Utilidades.ConvertirAFecha(Val(s.Value))
                Case 7
                    Vela.VolumenEnMoneda = Val(s.Value)
                Case 8
                    Vela.Operaciones = Val(s.Value)
                Case 9
                    Vela.VolumenEnMonedaBase = Val(s.Value)
                Case 10
                    Vela.VolumenEnMonedaContraPartida = Val(s.Value)
                Case 11
                    'ignorar este campo
            End Select
            encontradas.NextMatch()
        Next
        'Verificar que hay una vela más para agregar
        If Vela.Apertura <> 0 Then
            Velas.Add(Vela)
        End If

        Return Velas
    End Function

    Public Enum Intervalos
        m1 = 1
        m3 = 3
        m5 = 5
        m15 = 15
        m30 = 30
        h1 = 60
        h2 = 120
        h4 = 240
        h6 = 380
        h8 = 500
        h12 = 720
        d1 = 1440
        d3 = 4320
        w1 = 1080
        mes = 43200
    End Enum

    Public Shared Function GetIntervalo(Intervalo As Intervalos) As String
        Select Case Intervalo
            Case Intervalos.m1
                Return "1m"
            Case Intervalos.m3
                Return "3m"
            Case Intervalos.m5
                Return "5m"
            Case Intervalos.m15
                Return "15m"
            Case Intervalos.m30
                Return "30m"
            Case Intervalos.h1
                Return "1h"
            Case Intervalos.h2
                Return "2h"
            Case Intervalos.h4
                Return "4h"
            Case Intervalos.h6
                Return "6h"
            Case Intervalos.h8
                Return "8h"
            Case Intervalos.h12
                Return "12h"
            Case Intervalos.d1
                Return "1d"
            Case Intervalos.d3
                Return "3d"
            Case Intervalos.w1
                Return "1w"
            Case Intervalos.mes
                Return "1M"
        End Select
        Return ""
    End Function


    Public Shared Function Truncar(Importe As Decimal, decimales As Integer) As Decimal
        Dim s As String = Format(Importe, "0.0000000000").Replace(",", ".")
        Dim d() As String = Split(s, ".")
        If d.Length < 2 Then
            Return Importe
        Else
            Return Val(d(0) & "." & Left(d(1), decimales))
        End If
    End Function

End Class