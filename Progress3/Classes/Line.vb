Namespace Classes
    Public Class Line
        Public Property Index() As Integer
        Public Property Data() As String

        Public Overrides Function ToString() As String
            Return $"{Index}: {Data}"
        End Function
    End Class
End Namespace