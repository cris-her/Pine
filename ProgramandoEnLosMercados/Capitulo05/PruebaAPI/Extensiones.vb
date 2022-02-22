Imports System.Runtime.CompilerServices
Module Extensiones

    <Extension>
    Public Function FormatoImporte(importe As Decimal, Optional Formato As String = "0.00") As String
        Return importe.ToString(Formato).Replace(",", ".")
    End Function
	
	<Extension>
    Public Function FormatoImporte(importe As Decimal?, Optional Formato As String = "0.00") As String
        If importe Is Nothing Then
            Return FormatoImporte(0, Formato)
        End If
        Return FormatoImporte(importe, Formato)
    End Function

	<Extension>
    Public Function FormatoEntero(Numero As Long) As String
        Return Numero.ToString("0").Replace(",", ".")
    End Function
	
	<Extension>
    Public Function FormatoEntero(Numero As Long?) As String
        If Numero Is Nothing Then
            Return FormatoEntero(0)
        End If
        Return FormatoEntero(Numero)
    End Function





End Module
