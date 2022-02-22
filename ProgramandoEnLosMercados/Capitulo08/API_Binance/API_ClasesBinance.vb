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

End Class
