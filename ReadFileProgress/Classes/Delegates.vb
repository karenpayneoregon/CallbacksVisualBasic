Namespace Classes

    Public Class Delegates
        ''' <summary>
        ''' Provides continuous update status of creating person objects
        ''' after reading in a file/
        ''' </summary>
        ''' <param name="args">Current line processing along with total lines in out file</param>
        Public Delegate Sub OnIterate(args As ProgressArgs)
    End Class
End Namespace