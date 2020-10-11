Namespace Classes
    Public Class Person
        Public Property Id() As Integer
        Public Property FirstName() As String
        Public Property LastName() As String
        Public Property Gender() As String
        Public Property GenderId() As Integer
        Public Property Birthday() As Date
        Public ReadOnly Property ItemArray() As String()
            Get
                Return {FirstName, LastName, Gender, $"{Birthday:d}"}
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return $"{FirstName} {LastName}"
        End Function
    End Class
End Namespace