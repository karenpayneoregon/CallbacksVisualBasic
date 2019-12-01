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