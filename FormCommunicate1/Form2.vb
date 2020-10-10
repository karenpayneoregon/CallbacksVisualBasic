Public Class Form2
    Public Sub MessageReceived(enabled As Boolean, e As EventArgs)
        Timer1.Enabled = enabled
    End Sub

    Private _countDownTime As TimeSpan
    Private _countDownWatch As Stopwatch

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Timer1.Enabled = True
        _countDownTime = TimeSpan.FromMinutes(30)
        _countDownWatch = Stopwatch.StartNew()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim timeRemaining = _countDownTime - _countDownWatch.Elapsed

        If timeRemaining < TimeSpan.Zero Then
            timeRemaining = TimeSpan.Zero
        End If

        Label1.Text = timeRemaining.ToString("hh\:mm\:ss")

        If timeRemaining = TimeSpan.Zero Then
            Timer1.Stop()
        End If
    End Sub
End Class