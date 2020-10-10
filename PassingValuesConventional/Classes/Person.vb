Imports System.ComponentModel.DataAnnotations
Namespace Classes
    Public Class Person
        Public Property Id() As Integer
        <Required(ErrorMessage:="{0} is required"), DataType(DataType.Text)>
        <StringLength(20, MinimumLength:=3)>
        Public Property FirstName() As String
        <Required(ErrorMessage:="{0} is required"), DataType(DataType.Text)>
        <StringLength(20, MinimumLength:=5)>
        Public Property LastName() As String

        Public Overrides Function ToString() As String
            Return $"{FirstName} {LastName}"
        End Function
    End Class
End Namespace