Imports PassingValuesConventional1.Classes

Public Class Form1
    Private _person As New Person
    Private Sub ChildFormButton1_Click(sender As Object, e As EventArgs) Handles ChildFormButton1.Click

        _person.Id = 100
        _person.FirstName = FirstNameTextBox.Text
        _person.LastName = LastNameTextBox.Text
        _person.BirthDay = #9/23/1980#

        Dim childForm As New ChildForm() With {.Person = _person}

        childForm.ShowDialog()

    End Sub
End Class
