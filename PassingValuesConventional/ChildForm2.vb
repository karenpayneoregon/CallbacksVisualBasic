Imports PassingValuesConventional.Classes
Imports WinFormValidationLibrary.Classes
Imports WinFormValidationLibrary.Validators

Public Class ChildForm2
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


        Controls.OfType(Of TextBox).ToList().ForEach(Sub(tb) AddHandler tb.TextChanged, AddressOf FirstNameTextBox_TextChanged)

    End Sub
    ''' <summary>
    ''' Assign peron property values to controls
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ChildForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FirstNameTextBox.Text = _person.FirstName
        LastNameTextBox.Text = _person.LastName
    End Sub
    ''' <summary>
    ''' Perform property validation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OkayButton_Click(sender As Object, e As EventArgs) Handles OkayButton.Click

        _person.FirstName = FirstNameTextBox.Text
        _person.LastName = LastNameTextBox.Text

        Dim validationResult As EntityValidationResult = ValidationHelper.ValidateEntity(_person)

        If validationResult.HasError Then
            MessageBox.Show(validationResult.ErrorMessageList())
        Else
            DialogResult = DialogResult.OK
        End If

    End Sub
    ''' <summary>
    ''' Perform control validation
    ''' </summary>
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