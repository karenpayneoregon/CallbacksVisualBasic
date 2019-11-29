Namespace Classes
    Public Class EmptyLineArgs
        Inherits EventArgs

        Protected _index As Integer
        Public Sub New(RowIndex As Integer)
            _index = RowIndex
        End Sub
        ''' <summary>
        ''' Current read line index
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property RowIndex() As Integer
            Get
                Return _index
            End Get
        End Property
    End Class
End NameSpace