Imports System.IO

Public Class Form1
    Private FileName As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt")
    Private Sub ReadFileButton_Click(sender As Object, e As EventArgs) Handles ReadFileButton.Click
        ReadFileAndPopulateDataGridView()
    End Sub
    Private Async Sub ReadFileAndPopulateDataGridView()
        Dim index = 1

        Dim Row As String

        Using reader As StreamReader = File.OpenText(FileName)

            While Not reader.EndOfStream


                Await Task.Delay(10)

                Row = Await reader.ReadLineAsync()
                StatusLabel.Text = $"Reading line {index}"
                Dim parts = Row.Split(","c)

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

                index += 1

            End While
        End Using
    End Sub
End Class
