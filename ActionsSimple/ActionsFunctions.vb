Module ActionsFunctions
    ''' <summary>
    ''' Write to console in white foreground
    ''' </summary>
    ''' <param name="text">What to display</param>
    ''' <returns>Text asked to display</returns>
    Function WriteLineWhite(text As String) As String

        Dim originalForeGroundColor = Console.ForegroundColor

        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(text)
        Console.ForegroundColor = originalForeGroundColor

        Return text

    End Function
    ''' <summary>
    ''' Write to console in yellow foreground
    ''' </summary>
    ''' <param name="text">What to display</param>
    ''' <returns>Text asked to display</returns>
    Function WriteLineYellow(text As String) As String

        Dim originalForeGroundColor = Console.ForegroundColor

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(text)
        Console.ForegroundColor = originalForeGroundColor

        Return text

    End Function
    ''' <summary>
    ''' Write to console with choice of foreground color
    ''' </summary>
    ''' <param name="text">What to display</param>
    ''' <param name="color">Foreground color</param>
    ''' <returns>Text asked to display</returns>
    Function WriteLineWithColor(text As String, color As ConsoleColor) As String

        Dim originalForeGroundColor = Console.ForegroundColor

        Console.ForegroundColor = color
        Console.WriteLine(text)
        Console.ForegroundColor = originalForeGroundColor

        Return text

    End Function
End Module
