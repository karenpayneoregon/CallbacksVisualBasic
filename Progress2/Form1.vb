Imports System.Threading

Public Class Form1
    Private _cts As New CancellationTokenSource()

    Private Async Function AsyncMethod(progress As IProgress(Of Integer), ct As CancellationToken) As Task

        For index As Integer = 0 To 20
            'Simulate an async call that takes some time to complete
            Await Task.Delay(500)

            If ct.IsCancellationRequested Then
                ct.ThrowIfCancellationRequested()
            End If

            'Report progress
            If progress IsNot Nothing Then
                progress.Report(index)
            End If

        Next

    End Function

    Private Async Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        '
        ' Reset if needed, if was ran and cancelled before
        '
        If _cts.IsCancellationRequested = True Then
            _cts.Dispose()
            _cts = New CancellationTokenSource()
        End If

        'Instantiate progress indicator.
        'In this example this reports an Integer as progress, but
        'we could actually report a complex object providing more
        'information such as current operation
        Dim progressIndicator = New Progress(Of Integer)(AddressOf ReportProgress)
        Try
            'Call async method, pass progress indicator and cancellation token as parameters
            Await AsyncMethod(progressIndicator, _cts.Token)
        Catch ex As OperationCanceledException
            lblStatus.Text = "Cancelled"
        End Try

    End Sub
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        _cts.Cancel()
    End Sub
    Private Sub ReportProgress(ByVal value As Integer)
        lblStatus.Text = value.ToString()
    End Sub

End Class
