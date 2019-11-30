Imports FollowParent.Classes
Namespace Modules
    Public Module DelegatesModule
        Public Delegate Function ValidPerson(Person1 As Person, Person2 As Person) As Boolean
        Public Delegate Sub FormMessageHandler(
            sender As Object, args As FormMessageArgs)
    End Module
End Namespace