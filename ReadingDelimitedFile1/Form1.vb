Imports System.IO
Public Class Form1
    Private FileName As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt")
    Private Sub ReadFileButton_Click(sender As Object, e As EventArgs) Handles ReadFileButton.Click
        ReadFileAndPopulateDataGridView()
    End Sub
    Private Async Sub ReadFileAndPopulateDataGridView()
        Dim lineIndex = 1

        Dim currentLine As String

        Using reader As StreamReader = File.OpenText(FileName)

            While Not reader.EndOfStream

                Await Task.Delay(10)

                currentLine = Await reader.ReadLineAsync()
                StatusLabel.Text = $"Reading line {lineIndex}"

                Dim parts = currentLine.Split(","c)

                Dim person = New Person With
                        {
                            .FirstName = parts(0),
                            .MiddleName = parts(1),
                            .LastName = parts(2),
                            .Street = parts(3),
                            .City = parts(4),
                            .State = parts(5),
                            .PostalCode = parts(6),
                            .EmailAddress = parts(7)
                        }

                DataGridView1.Rows.Add(person.FieldArray())

                lineIndex += 1

            End While
        End Using

    End Sub
End Class
Public Class Person
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property LastName As String
    Public Property Street() As String
    Public Property City As String
    Public Property State As String
    Public Property PostalCode As String
    Public Property EmailAddress As String
    Public Function FieldArray() As String()
        Return New String() {FirstName, MiddleName, LastName, Street, City, State, PostalCode, EmailAddress}
    End Function
End Class
