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