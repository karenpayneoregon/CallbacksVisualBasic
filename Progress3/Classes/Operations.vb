Imports System.IO
Imports System.Threading

Namespace Classes
    Public Class Operations
        Private ReadOnly _fileName As String = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data.txt")
        Public Async Function AsyncMethod(progress As IProgress(Of Line), ct As CancellationToken) As Task
            Dim currentLine As New Line

            Dim lines = File.ReadAllLines(_fileName)

            For index As Integer = 0 To lines.Length - 1

                Await Task.Delay(300)
                currentLine = New Line() With {.Index = index, .Data = lines(index)}

                If ct.IsCancellationRequested Then
                    ct.ThrowIfCancellationRequested()
                End If

                'Report progress
                If progress IsNot Nothing Then
                    progress.Report(currentLine)
                End If

            Next

        End Function

    End Class
End Namespace