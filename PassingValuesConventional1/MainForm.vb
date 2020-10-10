Imports PassingValuesConventional1.Classes

Public Class MainForm
    Private _person As New Person
    Private People As New List(Of Person)
    Private PeopleClones As New List(Of Person)
    Private PeopleBindingSource As New BindingSource

    Private Sub ChildFormButton1_Click(sender As Object, e As EventArgs) Handles ChildFormButton1.Click

        Dim childForm As New ChildForm(CType(PeopleBindingSource.Current, Person))

        If childForm.ShowDialog() = DialogResult.Cancel Then
            Dim cloned = PeopleClones.Item(PeopleBindingSource.Position)
            CType(PeopleBindingSource.Current, Person).FirstName = cloned.FirstName
            CType(PeopleBindingSource.Current, Person).LastName = cloned.LastName
            CType(PeopleBindingSource.Current, Person).BirthDay = cloned.BirthDay
        End If


    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        People.Add(New Person() With {.Id = 1, .FirstName = "Jim", .LastName = "Jones", .BirthDay = #9/23/1980#})
        People.Add(New Person() With {.Id = 2, .FirstName = "Mary", .LastName = "Adams", .BirthDay = #1/22/1985#})

        PeopleBindingSource.DataSource = People
        PeopleBindingNavigator.BindingSource = PeopleBindingSource

        FirstNameTextBox.DataBindings.Add("Text", PeopleBindingSource, "FirstName")
        LastNameTextBox.DataBindings.Add("Text", PeopleBindingSource, "LastName")
        BirthDayDateTimePicker.DataBindings.Add("Value", PeopleBindingSource, "BirthDay")

        PeopleClones = People.Select(Function(person) person.Clone()).ToList()

    End Sub
End Class
