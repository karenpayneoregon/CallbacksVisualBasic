Imports ReadingDelimitedFile2.Classes
Namespace Modules
    Public Module DelegatesModule
        Public Delegate Sub FileHandler(sender As Object, args As LineArgs)
        Public Delegate Sub EmptyLineHandler(sender As Object, args As EmptyLineArgs)
    End Module
End Namespace