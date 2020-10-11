Namespace Classes
    ''' <summary>
    ''' Parameter for <see cref="Delegates.OnIterate"/>
    ''' </summary>
    Public Class ProgressArgs
        Inherits EventArgs

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="amount">Current array item index being processed</param>
        ''' <param name="totalLineCount">Total person count from lines read from file</param>
        Public Sub New(amount As Integer, totalLineCount As Integer)

            Current = amount
            Total = totalLineCount
        End Sub
        ''' <summary>
        ''' Current line index
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Current() As Integer
        ''' <summary>
        ''' Total line count
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Total() As Integer

    End Class
End Namespace