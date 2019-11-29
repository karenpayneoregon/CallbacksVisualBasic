Namespace Classes
    Public Class LineArgs
        Inherits EventArgs

        Protected _index As Integer
        Protected _person As Person

        ''' <summary>
        ''' Sets current row index and read in Person
        ''' </summary>
        ''' <param name="RowIndex">Current line index</param>
        ''' <param name="Person">Person object</param>
        Public Sub New(RowIndex As Integer, Person As Person)
            _index = RowIndex
            _person = Person
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