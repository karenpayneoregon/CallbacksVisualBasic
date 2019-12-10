Namespace Classes
    Public Class LineArgs
        Inherits EventArgs

        Protected _index As Integer
        Protected _person As Person

        ''' <summary>
        ''' Sets current row index and read in Person
        ''' </summary>
        ''' <param name="rowIndex">Current line index</param>
        ''' <param name="person">Person object</param>
        Public Sub New(rowIndex As Integer, person As Person)
            _index = rowIndex
            _person = person
        End Sub
        ''' <summary>
        ''' Current read line index
        ''' </summary>
        ''' <returns>Integer representing the line index</returns>
        Public ReadOnly Property RowIndex() As Integer
            Get
                Return _index
            End Get
        End Property
        ''' <summary>
        ''' Contains a valid Person object
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Person() As Person
            Get
                Return _person
            End Get
        End Property

    End Class
End Namespace