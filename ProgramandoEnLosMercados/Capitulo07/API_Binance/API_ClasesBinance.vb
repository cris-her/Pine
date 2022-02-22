Imports Newtonsoft

Public Class ClasesBinance

    Public Class Reglas
        Inherits List(Of Simbolo)


        Public Function ObtenerSimbolo(Par As String) As Simbolo
            Return Me.Find(Function(x) x.Par = Par)
        End Function


        Public Function Guardar(Archivo As String) As Boolean
            Try
                IO.File.WriteAllText(Archivo, Json.JsonConvert.SerializeObject(Me))
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function Cargar(Archivo As String) As Reglas
            Try
                Dim sBuffer As String = IO.File.ReadAllText(Archivo)
                Dim r As Reglas = Json.JsonConvert.DeserializeObject(Of Reglas)(sBuffer)
                Return r
            Catch ex As Exception
                Return New Reglas
            End Try
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

        Public Property Monedas As List(Of Balance)
    End Class

    Public Class Balance
        Public Property NombreMoneda As String
        Public Property Disponible As Decimal
        Public Property Trabado As Decimal
    End Class


End Class
