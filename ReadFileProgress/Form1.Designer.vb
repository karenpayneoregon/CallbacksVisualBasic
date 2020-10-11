<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ownerContactListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.ReadFileButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ownerContactListView
        '
        Me.ownerContactListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ownerContactListView.FullRowSelect = True
        Me.ownerContactListView.HideSelection = False
        Me.ownerContactListView.Location = New System.Drawing.Point(20, 12)
        Me.ownerContactListView.Name = "ownerContactListView"
        Me.ownerContactListView.Size = New System.Drawing.Size(308, 255)
        Me.ownerContactListView.TabIndex = 7
        Me.ownerContactListView.UseCompatibleStateImageBehavior = False
        Me.ownerContactListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "First name"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Last name"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Gender"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Birthday"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(23, 280)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(96, 13)
        Me.StatusLabel.TabIndex = 8
        Me.StatusLabel.Text = "Current read status"
        Me.StatusLabel.Visible = False
        '
        'CloseButton
        '
        Me.CloseButton.Image = Global.DelegateSimple.My.Resources.Resources.Exit_16x
        Me.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CloseButton.Location = New System.Drawing.Point(186, 313)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(142, 23)
        Me.CloseButton.TabIndex = 9
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'ReadFileButton
        '
        Me.ReadFileButton.Image = Global.DelegateSimple.My.Resources.Resources.Run_16x
        Me.ReadFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ReadFileButton.Location = New System.Drawing.Point(20, 313)
        Me.ReadFileButton.Name = "ReadFileButton"
        Me.ReadFileButton.Size = New System.Drawing.Size(142, 23)
        Me.ReadFileButton.TabIndex = 5
        Me.ReadFileButton.Text = "Load file"
        Me.ReadFileButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 396)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.ownerContactListView)
        Me.Controls.Add(Me.ReadFileButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TaskDialog Load file with progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReadFileButton As Button
    Friend WithEvents ownerContactListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents StatusLabel As Label
    Friend WithEvents CloseButton As Button
End Class
