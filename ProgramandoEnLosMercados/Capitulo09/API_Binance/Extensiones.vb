Imports System.Runtime.CompilerServices
Module Extensiones

#Region "Extensiones varias"

    <Extension>
    Public Function FormatoImporte(ElImporte As Decimal) As String
        Return Format(ElImporte, "0.00").Replace(",", ".")
    End Function

    <Extension>
    Public Function FormatoImporte(ElImporte As Decimal?) As String
        If ElImporte Is Nothing Then Return "0.00"
        Return Format(ElImporte, "0.00").Replace(",", ".")
    End Function

    <Extension>
    Public Function FormatoImporte(ElImporte As Decimal, elFormato As String) As String
        Return Format(ElImporte, elFormato).Replace(",", ".")
    End Function
    <Extension>
    Public Function FormatoImporte(ElImporte As Decimal?, elFormato As String) As String
        If ElImporte Is Nothing Then Return Format(0, elFormato).Replace(",", ".")
        Return Format(ElImporte, elFormato).Replace(",", ".")
    End Function


    <Extension>
    Public Function FormatoImporteFijo(ElImporte As Decimal, elFormato As String, longitud As String) As String
        Return Right(Space(longitud) & Format(ElImporte, elFormato).Replace(",", "."), longitud)
    End Function


    <Extension>
    Public Function FormatoImporteFijo(ElImporte As Decimal?, elFormato As String, longitud As String) As String
        If ElImporte Is Nothing Then Return Right(Space(longitud) & Format(0.0, elFormato).Replace(",", "."), longitud)
        Return Right(Space(longitud) & Format(ElImporte, elFormato).Replace(",", "."), longitud)
    End Function


    <Extension>
    Public Function FormatoBinance(ElImporte As Decimal) As String
        Return Format(ElImporte, "0.00000000").Replace(",", ".")
    End Function


    <Extension>
    Public Function FormatoBinance(ElImporte As Decimal?) As String
        If ElImporte Is Nothing Then Return Format(0.0, "0.00000000").Replace(",", ".")
        Return Format(ElImporte, "0.00000000").Replace(",", ".")
    End Function


    <Extension>
    Public Function Fijo(ElString As String, Cantidad As Integer) As String
        Return Mid(ElString + Space(Cantidad), 1, Cantidad)
    End Function



#End Region


End Module
