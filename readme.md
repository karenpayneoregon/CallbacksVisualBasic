# Using delegates code samples in VB.NET

Developers tend to visualize a project as a series of procedures and functions that execute in a given sequence, in reality these programs are event driven meaning the flow of execution is determined by occurrences called events.

An [event](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/events/) is triggered by something that was expected to occur such as a user clicking a button which raises a Click event which has code to perform one or more actions or calls a method to perform one or more actions. Think of events similar to the radio or TV broadcaster, an event would be a signal to tell you that a show is starting or a signal to tell your DVR that it is time to start recording. Your DVR would listen for a “show is about to begin” event and choose whether or not to do anything in response to it. Put this together with a [delegate](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/delegates/) and an event notifies subscribers that something happened by calling on the delegate to tell them about it.

Microsoft TechNet article: [Article location](https://social.technet.microsoft.com/wiki/contents/articles/53470.vb-net-windows-forms-custom-delegates-and-events.aspx)

### Delegates Overview

#### Delegates have the following properties:

- Delegates are similar to C++ function pointers, but are type safe.
- Delegates allow methods to be passed as parameters.
- Delegates can be used to define callback methods.
- Delegates can be chained together; for example, multiple methods can be called on a single event.
- Methods don't need to match the delegate signature exactly. For more information, see Covariance and Contra variance.
- C# version 2.0 introduces the concept of Anonymous Methods, which permit code blocks to be passed as parameters in place of a separately defined method.
 
### Code sneak preview

```csharp
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
```csharp
Imports System.IO
Imports ReadingDelimitedFile2.Modules

Namespace Classes
    Public Class FileOperation

        Public Event OnLineRead As FileHandler
        Public Event OnEmptyLineRead As EmptyLineHandler
        Public Property CancelRead() As Boolean
        Private FileName As String
        Public Sub New()
        End Sub
        Public Sub New(fileToRead As String)
            FileName = fileToRead
        End Sub
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

#### GitHub repositories
- [Working with files better](https://github.com/karenpayneoregon/file-read-tips-vb) (uses delegates and events)
[Async basics](https://github.com/karenpayneoregon/async-basics-vb)
- [Visual Basic getting started](https://github.com/karenpayneoregon/visual-basic-getting-started) (a work in progress)
- [VB.NET: Invoke Method to update UI from secondary threads](https://social.technet.microsoft.com/wiki/contents/articles/33280.vb-net-invoke-method-to-update-ui-from-secondary-threads.aspx) (not mine) *source code not available*.

#### Other references

- [Delegates](https://social.technet.microsoft.com/wiki/contents/articles/12785.delegates.aspx) bullet points


