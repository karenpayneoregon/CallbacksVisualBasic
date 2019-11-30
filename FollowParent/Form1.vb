Imports FollowParent.Classes

Public Class Form1

    Private ReadOnly _bindingSource As New BindingSource

    Private _childForm As ChildForm
    Private _firstTime As Boolean = True

    ''' <summary>
    ''' This delegate is used to shorten a line of code
    ''' in GetNewPerson, otherwise the predicate would be in
    ''' GetNewPerson.
    ''' </summary>
    ''' <param name="Person">Person from child form</param>
    ''' <returns></returns>
    Delegate Function ValidPerson(Person As Person) As Boolean

    ' Anonymous method
    Public PersonValid As ValidPerson =
               Function(person As Person)
                   Return Not String.IsNullOrWhiteSpace(person.FirstName) AndAlso
                          Not String.IsNullOrWhiteSpace(person.LastName)
               End Function

    Private Sub ShowChildFormButton_Click(sender As Object, e As EventArgs) Handles ShowChildFormButton.Click
        DisplayChildForm()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _ChildForm IsNot Nothing Then
            _ChildForm.Dispose()
        End If
    End Sub
    Private Sub DisplayChildForm()

        If Not My.Application.IsFormOpen("ChildForm") Then
            _childForm = New ChildForm With {
                .Owner = Me
            }

            AddHandler _childForm.OnMessageInformationChanged, AddressOf GetNewPerson
            AddHandler _childForm.FormClosing, AddressOf ChildFormClosed

            _firstTime = True

        End If

        _childForm.Show()
        ShowChildFormButton.Enabled = False

        If _firstTime Then
            _childForm.Location = New Point(Left + (Width + 10), Top + 5)
            _firstTime = False
        End If

    End Sub

    Private Sub ChildFormClosed(sender As Object, e As FormClosingEventArgs)
        ShowChildFormButton.Enabled = True
    End Sub
    ''' <summary>
    ''' Person passed in from child form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Private Sub GetNewPerson(sender As Object, args As FormMessageArgs)
        Dim people = CType(_bindingSource.DataSource, List(Of Person))

        If people.FirstOrDefault(Function(p) PersonValid(p)) Is Nothing Then
            _bindingSource.Add(args.Person)
        Else
            MessageBox.Show($"{args.Person} exists.")
        End If

    End Sub

    Private Sub Form1_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        If Not _FirstTime Then
            _ChildForm.Location = New Point(Left + (Width + 10), Top + 5)
        End If
    End Sub
    Private Sub ExitApplicationButton_Click(sender As Object, e As EventArgs) Handles ExitApplicationButton.Click
        Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.AutoGenerateColumns = False
        _bindingSource.DataSource = New List(Of Person)
        DataGridView1.DataSource = _bindingSource

    End Sub
End Class

