Namespace Classes
    Public Class Person
        Public Property Id() As Integer
        Public Property FirstName() As String
        Public Property LastName() As String
        Public Property BirthDay() As Date

        Public Overrides Function ToString() As String
            Return $"{FirstName} {LastName}"
        End Function
    End Class
End Namespace