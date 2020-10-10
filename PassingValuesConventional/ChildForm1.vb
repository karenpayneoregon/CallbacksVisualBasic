Imports PassingValuesConventional.Classes
Public Class ChildForm1
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

        'Controls.OfType(Of TextBox).ToList().ForEach(Sub(tb) AddHandler tb.Validating, AddressOf ChildForm_Validating)
        Controls.OfType(Of TextBox).ToList().ForEach(Sub(tb) AddHandler tb.TextChanged, AddressOf FirstNameTextBox_TextChanged)

    End Sub

    Private Sub ChildForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FirstNameTextBox.Text = _person.FirstName
        LastNameTextBox.Text = _person.LastName
    End Sub

    Private Sub OkayButton_Click(sender As Object, e As EventArgs) Handles OkayButton.Click

        'If Not String.IsNullOrWhiteSpace(FirstNameTextBox.Text) AndAlso Not String.IsNullOrWhiteSpace(LastNameTextBox.Text) Then
        '    _person.FirstName = FirstNameTextBox.Text
        '    _person.LastName = LastNameTextBox.Text
        '    DialogResult = DialogResult.OK
        'End If

        'If Not Controls.OfType(Of TextBox).Any(Function(tb) String.IsNullOrWhiteSpace(tb.Text)) Then
        '    _person.FirstName = FirstNameTextBox.Text
        '    _person.LastName = LastNameTextBox.Text
        '    DialogResult = DialogResult.OK
        'End If

        _person.FirstName = FirstNameTextBox.Text
        _person.LastName = LastNameTextBox.Text
        DialogResult = DialogResult.OK

    End Sub

    Private Sub ChildForm_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) 'Handles FirstNameTextBox.Validating
        CheckValidate()
    End Sub

    Private Sub CheckValidate()

        If Controls.OfType(Of TextBox).Any(Function(tb) String.IsNullOrWhiteSpace(tb.Text)) Then
            OkayButton.Enabled = False
        Else
            OkayButton.Enabled = True
        End If

    End Sub
    Private Sub FirstNameTextBox_TextChanged(sender As Object, e As EventArgs) 'Handles FirstNameTextBox.TextChanged
        CheckValidate()
    End Sub
End Class