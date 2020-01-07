Imports PassingValuesConventional.Classes

Public Class Form1
    Private _person As New Person
    Private Sub ChildFormButton1_Click(sender As Object, e As EventArgs) Handles ChildFormButton1.Click
        If Not String.IsNullOrWhiteSpace(FirstNameTextBox.Text) AndAlso Not String.IsNullOrWhiteSpace(LastNameTextBox.Text) Then
            _person.FirstName = FirstNameTextBox.Text
            _person.LastName = LastNameTextBox.Text
            Dim childForm As New ChildForm(_person)
            If childForm.ShowDialog() = DialogResult.OK Then
                FirstNameTextBox.Text = childForm.Person.FirstName
                LastNameTextBox.Text = childForm.Person.LastName
            End If
        End If
    End Sub
End Class
