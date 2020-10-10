# Using delegares code samples in VB.NET

Microsoft TechNet article: [Article location](https://social.technet.microsoft.com/wiki/contents/articles/53470.vb-net-windows-forms-custom-delegates-and-events.aspx)

### Code sneak preview

```
Imports Progress1.Classes

Public Class Form1
    Private Async Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        StartButton.Enabled = False

        Try

            Dim progress = New Progress(Of TaskProgressReport)(AddressOf ReportProgress)
            Await WorkerAsync(100, progress)

        Finally

            StartButton.Enabled = True

        End Try

    End Sub
    Private Async Function WorkerAsync(delay As Integer, progress As IProgress(Of TaskProgressReport)) As Task

        Const totalAmount As Integer = 10000

        Dim currentIterator As Integer = 0

        Do While currentIterator <= totalAmount

            Await Task.Delay(delay)

            progress.Report(New TaskProgressReport With
                               {
                                   .CurrentProgressAmount = currentIterator,
                                   .TotalProgressAmount = totalAmount,
                                   .CurrentProgressMessage = $"Current message: {currentIterator}"
                               })

            currentIterator += delay

        Loop

    End Function
    Private Sub ReportProgress(progress As TaskProgressReport)

        StatusLabel.Text = progress.CurrentProgressMessage
        ProgressTextBox.Text = $"{progress.CurrentProgressAmount} of {progress.TotalProgressAmount}"

    End Sub
End Class
```
```
Imports System.IO
Imports ReadingDelimitedFile2.Modules

Namespace Classes
    Public Class FileOperation

        ''' <summary>
        ''' Event for reporting progress and passing a just read Person
        ''' to the calling form for adding to a DataGridView
        ''' </summary>
        Public Event OnLineRead As FileHandler
        ''' <summary>
        ''' Event for monitoring empty lines
        ''' </summary>
        Public Event OnEmptyLineRead As EmptyLineHandler
        ''' <summary>
        ''' Provides ability to cancel a read operation
        ''' </summary>
        ''' <returns></returns>
        Public Property CancelRead() As Boolean
        ''' <summary>
        ''' File name to read from disk
        ''' </summary>
        Private FileName As String
        ''' <summary>
        ''' Allows creating an instance of this class at form level
        ''' </summary>
        Public Sub New()
        End Sub
        ''' <summary>
        ''' Creates a new instance ready to use with the file to read
        ''' </summary>
        ''' <param name="fileToRead"></param>
        Public Sub New(fileToRead As String)
            FileName = fileToRead
        End Sub
        ''' <summary>
        ''' Read a comma delimited file with a callback
        ''' </summary>
        Public Async Function ReadFileAndPopulateDataGridView() As Task
            Dim currentLineIndex = 1

            Dim currentLine As String

            Using reader As StreamReader = File.OpenText(FileName)

                While Not reader.EndOfStream

                    Await Task.Delay(2)

                    currentLine = Await reader.ReadLineAsync()

                    ' avoid empty lines
                    If Not String.IsNullOrWhiteSpace(currentLine) Then

                        Dim currentLineParts = currentLine.Split(","c)

                        ' only add if there are 8 elements in the array
                        If currentLineParts.Length = 8 Then

                            Dim person = New Person With
                                    {
                                        .FirstName = currentLineParts(0),
                                        .MiddleName = currentLineParts(1),
                                        .LastName = currentLineParts(2),
                                        .Street = currentLineParts(3),
                                        .City = currentLineParts(4),
                                        .State = currentLineParts(5),
                                        .PostalCode = currentLineParts(6),
                                        .EmailAddress = currentLineParts(7)
                                    }

                            RaiseEvent OnLineRead(Me, New LineArgs(currentLineIndex, person))

                        End If
                    Else
                        RaiseEvent OnEmptyLineRead(Me, New EmptyLineArgs(currentLineIndex))
                    End If


                    ' increment line number used in callback
                    currentLineIndex += 1

                    ' watch for user cancellation
                    If CancelRead Then
                        Exit Function
                    End If

                End While
            End Using

        End Function
    End Class
End Namespace
```
# Notes

Besides working with delegates and events there are plenty of other things to learn from such as data annotations.

# See also

GitHub repositories
- [Working with files better](https://github.com/karenpayneoregon/file-read-tips-vb) (uses delegates and events)
[Async basics](https://github.com/karenpayneoregon/async-basics-vb)
- [Visual Basic getting started](https://github.com/karenpayneoregon/visual-basic-getting-started) (a work in progress)


