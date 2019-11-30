Imports FollowParent.Classes
Imports FollowParent.Modules

Public Class ChildForm

    Public Event OnMessageInformationChanged As FormMessageHandler

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
    ''' <summary>
    ''' Event triggered in ProcessCmdKey event when ENTER is pressed
    ''' in the LastNameTextBox and both TextBox controls have values
    ''' </summary>
    Private Sub ConditionallyAddPerson()
        Dim hasFirstName = Not String.IsNullOrWhiteSpace(FirstNameTextBox.Text)
        Dim hasLastName = Not String.IsNullOrWhiteSpace(LastNameTextBox.Text)

        If hasFirstName AndAlso hasLastName Then
            '
            ' Both TextBox controls have data, push to the main form
            ' which has subscribed to this event.
            '
            RaiseEvent OnMessageInformationChanged(Me, New FormMessageArgs(
                New Person() With
                  {
                      .FirstName = FirstNameTextBox.Text,
                      .LastName = LastNameTextBox.Text
                  }))

        End If
    End Sub

    ''' <summary>
    ''' Ensures no beep on enter key pressed
    ''' Not practical for a typical data entry form.
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If msg.WParam.ToInt32() = Keys.Enter AndAlso ActiveControl.Name = "LastNameTextBox" Then
            ConditionallyAddPerson()
            SendKeys.Send("{Tab}")
            Return True
        ElseIf msg.WParam.ToInt32() = Keys.Enter AndAlso ActiveControl.Name = "FirstNameTextBox" Then
            SendKeys.Send("{Tab}")
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function
End Class