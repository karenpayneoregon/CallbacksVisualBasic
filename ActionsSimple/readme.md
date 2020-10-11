# About

Simple examples for [Action Delegates](https://docs.microsoft.com/en-us/dotnet/api/system.action?view=netcore-3.1).

```
Module Module1

    Sub Main()

        Dim whiteAction As Action(Of String)
        Dim yellowAction As Action(Of String)
        Dim anyColorAction As Action(Of String, ConsoleColor)

        whiteAction = Function(text) WriteLineWhite(text)
        yellowAction = Function(text) WriteLineYellow(text)
        anyColorAction = Function(text, color) WriteLineWithColor(text, color)


        whiteAction("Hello")
        yellowAction("Bye")
        anyColorAction("Press a key", ConsoleColor.Cyan)

        Console.ReadLine()

    End Sub


End Module
```