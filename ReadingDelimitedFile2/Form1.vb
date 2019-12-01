Imports System.IO
Imports ReadingDelimitedFile2.Classes

Public Class Form1
    ''' <summary>
    ''' Exiting file to read
    ''' </summary>
    Private ReadOnly _fileName As String = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "Data.txt")

    Private _operations As New FileOperation

    ''' <summary>
    ''' Used to display count of empty rows while reading a file
    ''' </summary>
    Private _emptyLineCount As Integer = 0
    ''' <summary>
    ''' Used to store line indices for empty lines when reading a file
    ''' </summary>
    Private _emptyLineList As New List(Of Integer)
    ''' <summary>
    ''' Provides functionality to read a file asynchronously with
    ''' callbacks for populating a DataGridView, report progress
    ''' by line number and also using a callback to report empty lines
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub ReadFileButton_Click(sender As Object, e As EventArgs) _
        Handles ReadFileButton.Click

        _emptyLineCount = 0
        _emptyLineList = New List(Of Integer)()

        _operations = New FileOperation(_fileName)

        AddHandler _operations.OnLineRead, AddressOf LineRead
        AddHandler _operations.OnEmptyLineRead, AddressOf EmptyLineRead

        Await _operations.ReadFileAndPopulateDataGridView()

        EmailColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        If _emptyLineList.Count > 0 Then
            Dim lineIndices = String.Join(",", _emptyLineList.ToArray())
            MessageBox.Show($"The following lines where empty {lineIndices}")
        End If

    End Sub
    ''' <summary>
    ''' Report back an empty line with it's index.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub EmptyLineRead(sender As Object, args As EmptyLineArgs)
        _emptyLineCount += 1

        EmptyLinesLabel.Text = _emptyLineCount.ToString()
        _emptyLineList.Add(args.RowIndex)

    End Sub

    ''' <summary>
    ''' Update status label
    ''' Add new row to DataGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub LineRead(sender As Object, args As LineArgs)

        StatusLabel.Text = $"Read line {args.RowIndex}"

        If Not _operations.CancelRead Then
            DataGridView1.Rows.Add(args.Person.FieldArray())
        End If

    End Sub
    Private Sub ExitApplicationButton_Click(sender As Object, e As EventArgs) _
        Handles ExitApplicationButton.Click

        Close()

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing

        _operations.CancelRead = True

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        StatusLabel.Text = ""
        EmptyLinesLabel.Text = ""

    End Sub
End Class
