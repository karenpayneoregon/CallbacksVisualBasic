Imports DelegateSimple.Classes

Public Class VerifyForm
    Private verifyList As List(Of Verify)
    Public Sub New(items As List(Of Verify))

        InitializeComponent()

        verifyList = items

    End Sub

    Private Sub VerifyForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For Each contact In verifyList

            ownerContactListView.Items.Add(New ListViewItem(contact.ItemArray))

        Next

        ownerContactListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ownerContactListView.EndUpdate()

        ownerContactListView.FocusedItem = ownerContactListView.Items(0)
        ownerContactListView.Items(0).Selected = True

    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Close()
    End Sub
End Class