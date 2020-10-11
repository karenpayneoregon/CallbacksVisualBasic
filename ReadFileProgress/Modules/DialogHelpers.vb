Imports Microsoft.WindowsAPICodePack.Dialogs

Namespace Modules

    Public Module DialogHelpers
        Public Function ExitApplication(Form As Form) As TaskDialogResult
            Dim taskDialogResult As TaskDialogResult

            Dim stayButton = New TaskDialogButton("StayButton", "I want to stay") With {.Default = True}
            Dim closeButton = New TaskDialogButton("CancelButton", "Leave now!!!")

            Using dialog = New TaskDialog With {
                .Caption = "Question",
                .InstructionText = $"Close me",
                .Icon = TaskDialogStandardIcon.Warning,
                .Cancelable = True, .OwnerWindowHandle = Form.Handle,
                .StartupLocation = TaskDialogStartupLocation.CenterOwner}

                dialog.Controls.Add(stayButton)
                dialog.Controls.Add(closeButton)

                AddHandler dialog.Opened, Sub(sender As Object, ea As EventArgs)
                                              Dim taskDialog As TaskDialog = TryCast(sender, TaskDialog)
                                              taskDialog.Icon = taskDialog.Icon

                                          End Sub

                AddHandler stayButton.Click,
                    Sub(o, ev)
                        dialog.Close(TaskDialogResult.Cancel)
                    End Sub

                AddHandler closeButton.Click,
                    Sub(o, ev)
                        dialog.Close(TaskDialogResult.Ok)
                    End Sub

                taskDialogResult = dialog.Show()

                If taskDialogResult = TaskDialogResult.Ok Then
                    Form.Close()
                End If

            End Using

            Return taskDialogResult

        End Function


    End Module
End Namespace