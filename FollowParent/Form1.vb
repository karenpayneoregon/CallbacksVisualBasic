Imports FollowParent.Classes
Imports FollowParent.Modules

Public Class Form1

    Private ReadOnly _bindingSource As New BindingSource

    Private _childForm As ChildForm
    Private _firstTime As Boolean = True

    ' Anonymous method
    Public PersonValid As ValidPerson =
               Function(person1 As Person, person2 As Person)
                   Return Not String.IsNullOrWhiteSpace(person1.FirstName) AndAlso
                          Not String.IsNullOrWhiteSpace(person1.LastName) AndAlso
                          person1.FirstName = person2.FirstName AndAlso
                          person1.LastName = person2.LastName
               End Function

    Private Sub ShowChildFormButton_Click(sender As Object, e As EventArgs) _
        Handles ShowChildFormButton.Click

        DisplayChildForm()

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _childForm IsNot Nothing Then
            _childForm.Dispose()
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

        If people.FirstOrDefault(Function(p) PersonValid(p, args.Person)) Is Nothing Then
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
    Private Sub ExitApplicationButton_Click(sender As Object, e As EventArgs) _
        Handles ExitApplicationButton.Click

        Close()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.AutoGenerateColumns = False
        _bindingSource.DataSource = New List(Of Person)
        DataGridView1.DataSource = _bindingSource

    End Sub
End Class

