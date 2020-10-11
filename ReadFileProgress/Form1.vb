
Imports System.IO
Imports System.Threading
Imports DelegateSimple.Classes
Imports DelegateSimple.Modules
Imports Microsoft.WindowsAPICodePack.Dialogs


Public Class Form1

    Private _cancellationTokenSource As New CancellationTokenSource()

    Private Sub ReadFileButton_Click(sender As Object, e As EventArgs) Handles ReadFileButton.Click

        StatusLabel.Visible = True

        If _cancellationTokenSource.IsCancellationRequested Then
            _cancellationTokenSource.Dispose()
            _cancellationTokenSource = New CancellationTokenSource()
        End If

        ownerContactListView.Items.Clear()

        Dim detailsText = "Well we are reading a file and parsing that file for you " &
                          "to read, in this example it won't take very long. Will close when finished"

        Dim closeButton = New TaskDialogButton("Enabled", "I can't wait") With {.Default = True}

        Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextFile1.txt")

        Using dialog = New TaskDialog With {
            .Caption = "Read file",
            .DetailsCollapsedLabel = "More details >>",
            .DetailsExpanded = False,
            .DetailsExpandedLabel = "<< Less details",
            .DetailsExpandedText = detailsText,
            .ExpansionMode = TaskDialogExpandedDetailsLocation.Hide,
            .InstructionText = $"Reading the file '{Path.GetFileName(fileName)}'",
            .Icon = TaskDialogStandardIcon.Information,
            .Cancelable = True,
            .StartupLocation = TaskDialogStartupLocation.CenterOwner}

            dialog.Controls.Add(closeButton)

            dialog.OwnerWindowHandle = Handle

            dialog.ProgressBar = New TaskDialogProgressBar("ReadPeopleJob") With {
                .Maximum = FileOperations.GetLineCount(fileName),
                .Minimum = 0,
                .Value = 0,
                .State = TaskDialogProgressBarState.Normal}


            AddHandler FileOperations.OnIterate,
                Sub(args)
                    StatusLabel.Text = $"{args.Current} of {args.Total}"
                End Sub


            AddHandler dialog.Opened, Async Sub(senderObject As Object, ea As EventArgs)
                                          Dim taskDialog As TaskDialog = TryCast(senderObject, TaskDialog)
                                          taskDialog.Icon = taskDialog.Icon

                                          Try

                                              Await FileOperations.OpenAsync(
                                                  fileName,
                                                  dialog.ProgressBar,
                                                  _cancellationTokenSource.Token)

                                          Catch oce As OperationCanceledException
                                              ' Cancellation performed on token
                                          Catch ex As Exception
                                              ' unexpected runtime exception
                                              MessageBox.Show(ex.Message)
                                          End Try
                                      End Sub


            AddHandler dialog.Closing, Sub(taskDialogItem As Object, ea As TaskDialogClosingEventArgs)
                                           Dim taskDialog = CType(taskDialogItem, TaskDialog)

                                           If ea.TaskDialogResult = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogResult.Cancel Then
                                               Console.WriteLine($"Read {taskDialog.ProgressBar.Value} of {FileOperations.LineCount}")
                                           Else
                                               Console.WriteLine($"Read {FileOperations.LineCount}")
                                           End If
                                       End Sub


            Dim countRead = 0
            Dim totalLines = 0


            AddHandler closeButton.Click,
                Sub(o, ev)
                    _cancellationTokenSource.Cancel()
                    countRead = dialog.ProgressBar.Value + 1
                    totalLines = FileOperations.LineCount
                    dialog.Close(Microsoft.WindowsAPICodePack.Dialogs.TaskDialogResult.Cancel)
                End Sub


            Dim taskDialogResult = dialog.Show()

            If taskDialogResult = TaskDialogResult.Cancel Then
                _cancellationTokenSource.Cancel()
            End If

            For Each contact In FileOperations.PersonList

                ownerContactListView.Items.Add(New ListViewItem(contact.ItemArray) With {.Tag = contact.Id})

            Next

            ownerContactListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            ownerContactListView.EndUpdate()

            ownerContactListView.FocusedItem = ownerContactListView.Items(0)
            ownerContactListView.Items(0).Selected = True

            If taskDialogResult = TaskDialogResult.Ok Then
                MessageBox.Show("Done")
            Else
                MessageBox.Show($"Cancel after reading {countRead} of {totalLines}")
            End If

            ActiveControl = ownerContactListView

        End Using

    End Sub
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        If ExitApplication(Me) = TaskDialogResult.Ok Then
            Close()
        End If
    End Sub
End Class


