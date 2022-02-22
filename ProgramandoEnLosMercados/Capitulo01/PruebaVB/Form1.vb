Imports API_InvertirOnLine
Public Class Form1
    Dim API As API_IOL
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIlegalCrossThreadCall = False

        API = New API_IOL(configuracion.Usuario, configuracion.Clave, Application.StartupPath)

        If API.InicializarWebSocket() Then
            AddHandler API.OnCambioPrecio, AddressOf onPrecio
            AddHandler API.OnCambioDeEstado, AddressOf onEstados
            AddHandler API.OnCambioPuntas, AddressOf onPuntas
        End If
    End Sub

    Private Sub onPuntas(simbolo As API_IOL.Puntas)
        txtSalida.Text = simbolo.ToString
        Debug.Print(simbolo.ToString)
    End Sub

    Private Sub onEstados(Estado As String, e As Exception)
        Debug.Print(Estado)
    End Sub

    Private Sub onPrecio(precio As API_IOL.Precio)
        txtSalida.Text &= precio.ToString
        Debug.Print(precio.ToString)
    End Sub

    Private Sub btnCuenta_Click(sender As Object, e As EventArgs) Handles btnCuenta.Click
        Dim respuesta As API_IOL.Cuentas = API.EstadoCuenta()
        If respuesta IsNot Nothing Then
            txtSalida.Text = respuesta.ToString
        End If
    End Sub

    Private Sub btnCotizacion_Click(sender As Object, e As EventArgs) Handles btnCotizacion.Click
        Dim cot As API_IOL.Cotizacion = API.ObtenerCotizacion(txtTicker.Text)
        If cot IsNot Nothing Then
            txtSalida.Text = cot.ToString
        End If
    End Sub

    Private Sub btnOpciones_Click(sender As Object, e As EventArgs) Handles btnOpciones.Click
        Dim opc As API_IOL.DatosOpciones = API.ObtenerDatosOpciones(txtTicker.Text)
        If opc IsNot Nothing Then
            txtSalida.Text = opc.ToString
        End If
    End Sub

    Private Sub btnPanelMerval_Click(sender As Object, e As EventArgs) Handles btnPanelMerval.Click
        Dim merv As API_IOL.CotizacionesDelPanel = API.ObtenerCotizacionesPanelMerval()
        If merv IsNot Nothing Then
            txtSalida.Text = merv.ToString
        End If
    End Sub

    Private Sub btnCedears_Click(sender As Object, e As EventArgs) Handles btnCedears.Click
        Dim cedears As API_IOL.CotizacionesDelPanel = API.ObtenerCotizacionesPanelCEDEARs()
        If cedears IsNot Nothing Then
            txtSalida.Text = cedears.ToString
        End If
    End Sub

    Private Sub btnHistoricos_Click(sender As Object, e As EventArgs) Handles btnHistoricos.Click
        Dim histo As API_IOL.Historico = API.ObtenerDatosHistoricos(txtTicker.Text, txtDesde.Text, txtHasta.Text)
        If histo IsNot Nothing Then
            txtSalida.Text = histo.ToString
        End If
        Debug.Print("")
        histo.ToCSV("GGAL 2021.CSV")
        'API.Comprar("GGAL", 20, 120) 25 mil llamadas a la api al mes
        'API.Vender("GGAL", 20, 120)
        Debug.Print(API.Api_Call) 'Reiniciar cuenta cada mes
    End Sub

    Private Sub btnPrecios_Click(sender As Object, e As EventArgs) Handles btnPrecios.Click
        API.EscucharPrecios("GGAL")
        API.EscucharPrecios("YPFD")
        API.EscucharPrecios("NASDAQ:GGAL")
        API.EscucharPrecios("AL30")
    End Sub

    Private Sub btnPuntas_Click(sender As Object, e As EventArgs) Handles btnPuntas.Click
        API.EscucharCajasDePuntas("AL30")
        API.EscucharCajasDePuntas("GGAL")
    End Sub
End Class
