Imports System.ComponentModel.DataAnnotations

Namespace Classes

    Public Class BirthDateAttribute
        Inherits ValidationAttribute

        Public Overrides Function IsValid(ByVal value As Object) As Boolean
            Dim dt = DirectCast(value, DateTime)
            If dt >= DateTime.Now Then
                Return False
            End If
            Return True
        End Function

    End Class
End Namespace