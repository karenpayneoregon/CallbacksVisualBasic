Imports PassingValuesConventional1.Classes

Public Class ChildForm

    Public Property Person() As Person
    ''' <summary>
    ''' Person property is populated via the following line from Form1 
    ''' where the With clause sets the person
    ''' 
    '''    Dim childForm As New ChildForm() With {.Person = _person}
    '''    
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ChildForm_Shown(sender As Object, e As EventArgs) _
        Handles Me.Shown

        IdentifierLabel.Text = $"{Person.Id}"
        FirstNameTextBox.Text = Person.FirstName
        LastNameTextBox.Text = Person.LastName
        BirthDayDateTimePicker.Value = Person.BirthDay

    End Sub
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) _
        Handles CloseButton.Click

        ' no action needed as DialogResult has 
        ' been set in the button's property window

    End Sub
End Class