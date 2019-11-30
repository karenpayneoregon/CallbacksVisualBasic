Namespace Classes
    Public Class FormMessageArgs
        Inherits EventArgs

        Protected _person As Person
        ''' <summary>
        ''' Expects a valid Person object with
        ''' First and Last name populated
        ''' </summary>
        ''' <param name="person"></param>
        Public Sub New(person As Person)
            _person = person
        End Sub
        ''' <summary>
        ''' Returns a Person object
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Person() As Person
            Get
                Return _person
            End Get
        End Property
        ''' <summary>
        ''' Determines if the person object is populated
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsValidPerson() As Boolean
            Get
                Return _
                    Not String.IsNullOrWhiteSpace(_person.FirstName) AndAlso
                    Not String.IsNullOrWhiteSpace(_person.LastName)
            End Get
        End Property
    End Class
End NameSpace