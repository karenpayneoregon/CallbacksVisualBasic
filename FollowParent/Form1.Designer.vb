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
        Me.ExitApplicationButton = New System.Windows.Forms.Button()
        Me.ShowChildFormButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExitApplicationButton
        '
        Me.ExitApplicationButton.Location = New System.Drawing.Point(304, 233)
        Me.ExitApplicationButton.Name = "ExitApplicationButton"
        Me.ExitApplicationButton.Size = New System.Drawing.Size(75, 23)
        Me.ExitApplicationButton.TabIndex = 0
        Me.ExitApplicationButton.Text = "E&xit"
        Me.ExitApplicationButton.UseVisualStyleBackColor = True
        '
        'ShowChildFormButton
        '
        Me.ShowChildFormButton.Location = New System.Drawing.Point(12, 233)
        Me.ShowChildFormButton.Name = "ShowChildFormButton"
        Me.ShowChildFormButton.Size = New System.Drawing.Size(141, 23)
        Me.ShowChildFormButton.TabIndex = 0
        Me.ShowChildFormButton.Text = "Show child form"
        Me.ShowChildFormButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstNameColumn, Me.LastNameColumn})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(375, 205)
        Me.DataGridView1.TabIndex = 9
        '
        'FirstNameColumn
        '
        Me.FirstNameColumn.DataPropertyName = "FirstName"
        Me.FirstNameColumn.HeaderText = "First"
        Me.FirstNameColumn.Name = "FirstNameColumn"
        '
        'LastNameColumn
        '
        Me.LastNameColumn.DataPropertyName = "LastName"
        Me.LastNameColumn.HeaderText = "Last"
        Me.LastNameColumn.Name = "LastNameColumn"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 268)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ExitApplicationButton)
        Me.Controls.Add(Me.ShowChildFormButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form to Form delegate"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExitApplicationButton As System.Windows.Forms.Button
    Friend WithEvents ShowChildFormButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastNameColumn As DataGridViewTextBoxColumn
End Class
