Imports System.ComponentModel
Imports PassingValuesConventional1.Classes
Imports WinFormValidationLibrary.Classes
Imports WinFormValidationLibrary.Validators

Public Class ChildForm
    Private _person As New Person
    Public ReadOnly Property Person() As Person
        Get
            Return _person
        End Get
    End Property
    Public Sub New(person As Person)

        InitializeComponent()

        _person = person

    End Sub
    Private Sub ChildForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        IdentifierLabel.Text = $"{Person.Id}"

        FirstNameTextBox.DataBindings.Add("Text", _person, "FirstName")
        LastNameTextBox.DataBindings.Add("Text", _person, "LastName")

        '
        ' Here we use MaxDate for constraining
        '
        'BirthDayDateTimePicker.MaxDate = Now.AddYears(-20)

        BirthDayDateTimePicker.DataBindings.Add("Value", _person, "BirthDay")

    End Sub
    ''' <summary>
    ''' If there are validation issues deny closing the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click

        Dim validationResult As EntityValidationResult = ValidationHelper.ValidateEntity(_person)

        If validationResult.HasError Then
            MessageBox.Show(validationResult.ErrorMessageList())
        Else
            DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub ChildForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        _person.BirthDay = BirthDayDateTimePicker.Value

        Dim validationResult As EntityValidationResult = ValidationHelper.ValidateEntity(_person)

        If validationResult.HasError Then
            DialogResult = DialogResult.Cancel
        Else
            DialogResult = DialogResult.OK
        End If

    End Sub
End Class