Imports System.IO
Imports System.Text
Imports Microsoft.WindowsAPICodePack.Dialogs

Namespace Classes

    Public Class FileOperations
        ''' <summary>
        ''' Provide a way to show progress on the calling form while reading a file
        ''' </summary>
        Public Shared Event OnIterate As Delegates.OnIterate
        Private Shared people As List(Of Person)
        Public Shared ReadOnly Property PersonList() As List(Of Person)
            Get
                Return people
            End Get
        End Property

        Private Shared fileLineCount As Integer
        ''' <summary>
        ''' Total lines in person file
        ''' </summary>
        ''' <returns>Line count</returns>
        Public Shared ReadOnly Property LineCount() As Integer
            Get
                Return fileLineCount
            End Get
        End Property
        ''' <summary>
        ''' Get total lines in file
        ''' </summary>
        ''' <param name="fileName"></param>
        ''' <returns>Line count</returns>
        Public Shared ReadOnly Property GetLineCount(fileName As String) As Integer
            Get
                ' see if we already counted the lines, if so exit
                If fileLineCount > 0 Then
                    Return fileLineCount
                End If

                Using sr = New StreamReader(fileName)
                    Do While Not String.IsNullOrWhiteSpace(sr.ReadLine())
                        fileLineCount += 1
                    Loop
                End Using

                Return fileLineCount

            End Get
        End Property
        ''' <summary>
        ''' Read file into a list of Person 
        ''' </summary>
        ''' <param name="fileName">Valid existing file</param>
        ''' <param name="progress">ProgressBar for TaskDialog</param>
        ''' <param name="token">Cancellation token attached to the calling form</param>
        ''' <returns>Return value is ignored</returns>
        ''' <remarks>
        ''' There is zero validation on data in the text file. The idea is that in this
        ''' case there is always good data where the data came from a fictitious mainframe
        ''' which has validated the data then pushed out via a service or in some cases
        ''' done from a Power shell script
        ''' </remarks>
        Public Shared Async Function OpenAsync(fileName As String, progress As TaskDialogProgressBar, token As Threading.CancellationToken) As Task(Of Boolean)

            people = New List(Of Person)

            Dim dialog = CType(progress.HostingDialog, TaskDialog)
            Dim lines As String()


            ' read file into string array asynchronously
            Using reader = File.OpenText(fileName)

                Dim fileText As String = Await reader.ReadToEndAsync()

                lines = fileText.Split({Environment.NewLine}, StringSplitOptions.None).
                    Where(Function(item) Not String.IsNullOrWhiteSpace(item)).
                    ToArray()


                'lines = fileText.Split({Environment.NewLine}, StringSplitOptions.None).ToArray()

            End Using


            Dim test = Await ReadAllLinesAsync(fileName)

            ' process lines until all are read in to list
            If Not progress.State = TaskDialogProgressBarState.None Then

                For lineIndex As Integer = 1 To lines.Count - 1

                    ' if a cancel request was given, exit
                    If token.IsCancellationRequested Then
                        token.ThrowIfCancellationRequested()
                    End If

                    Dim parts = lines(lineIndex).Split(","c)

                    Dim id = CInt(parts(0))
                    Dim firstName = parts(1)
                    Dim lastName = parts(2)
                    Dim birthDay = CDate(parts(4))
                    Dim gender = If(parts(3) = "1", "Female", "Male")
                    Dim genderId = CInt(parts(3))

                    people.Add(New Person() With {
                                  .Id = id,
                                  .FirstName = firstName,
                                  .LastName = lastName,
                                  .Birthday = birthDay,
                                  .Gender = gender, .GenderId = genderId})

                    progress.Value = lineIndex

                    ' report back to subscriber (the calling form event)
                    OnIterateEvent?.Invoke(New ProgressArgs(progress.Value + 1, progress.Maximum))

                    ' without this for a small file we go fast which is not a bad thing
                    Await Task.Delay(1)

                    ' if done reading file change progress state/style
                    If progress.Value = progress.Maximum Then
                        progress.State = TaskDialogProgressBarState.None
                    End If

                Next
            End If

            ' auto close dialog
            If Not dialog.ProgressBar Is Nothing Then
                dialog.Close(TaskDialogResult.Ok)
            End If

            Return True

        End Function
        Private Shared Async Function ReadAllLinesAsync(ByVal filePath As String) As Task(Of String())
            Using sourceStream As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize:=4096, useAsync:=True)
                Dim sb As New StringBuilder()

                Dim buffer(4095) As Byte
                Dim numRead As Integer
                numRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)

                Do While numRead <> 0
                    Dim text As String = Encoding.Unicode.GetString(buffer, 0, numRead)
                    sb.Append(text)
                    numRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)
                Loop

                Return sb.ToString().Split({Environment.NewLine}, StringSplitOptions.None)
            End Using
        End Function


    End Class
End Namespace