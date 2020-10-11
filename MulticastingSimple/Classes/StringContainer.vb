Namespace Classes
    Class StringContainer
        ' Define a delegate to handle string display. 
        Delegate Sub CheckAndPrintDelegate(ByVal str As String)

        ' A generic list object that holds the strings.
        Private container As New List(Of String)()

        ' A method that adds strings to the collection. 
        Public Sub AddString(item As String)
            container.Add(item)
        End Sub

        ' Iterate through the strings and invoke the method(s) that the delegate points to.
        Public Sub DisplayAllQualified(displayDelegate As CheckAndPrintDelegate)
            For Each item In container
                displayDelegate(item)
            Next
        End Sub
    End Class
End Namespace