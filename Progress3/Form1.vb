Imports System.Threading
Imports Progress3.Classes

Public Class Form1
    Private _cts As New CancellationTokenSource()
    Private operations As New Operations
    Private Async Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        '
        ' Reset if needed, if was ran and cancelled before
        '
        If _cts.IsCancellationRequested = True Then
            _cts.Dispose()
            _cts = New CancellationTokenSource()
        End If

        'Instantiate progress indicator, unlike the last two examples
        'In this example this reports a class as progress, but
        Dim progressIndicator = New Progress(Of Line)(AddressOf ReportProgress)

        Try
            Await operations.AsyncMethod(progressIndicator, _cts.Token)
        Catch ex As OperationCanceledException
            lblStatus.Text = "Cancelled"
        End Try

    End Sub
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        _cts.Cancel()
    End Sub
    Private Sub ReportProgress(value As Line)
        lblStatus.Text = value.ToString()
    End Sub

End Class
