Imports PassingValuesConventional.Classes
Public Class ChildForm
    Private _person As New Person
    Public ReadOnly Property Person() As Person
        Get
            Return _person
        End Get
    End Property
    Public Sub New(person As Person)

        InitializeComponent()

        _person.FirstName = person.FirstName
        _person.LastName = person.LastName

    End Sub

    Private Sub ChildForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FirstNameTextBox.Text = _person.FirstName
        LastNameTextBox.Text = _person.LastName
    End Sub

    Private Sub OkayButton_Click(sender As Object, e As EventArgs) Handles OkayButton.Click
        If Not String.IsNullOrWhiteSpace(FirstNameTextBox.Text) AndAlso Not String.IsNullOrWhiteSpace(LastNameTextBox.Text) Then
            _person.FirstName = FirstNameTextBox.Text
            _person.LastName = LastNameTextBox.Text
            DialogResult = DialogResult.OK
        End If
    End Sub
End Class