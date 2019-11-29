<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReadFileButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExitApplicationButton = New System.Windows.Forms.Button()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiddleIntialColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StreetColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmptyLinesLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReadFileButton
        '
        Me.ReadFileButton.Location = New System.Drawing.Point(19, 15)
        Me.ReadFileButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ReadFileButton.Name = "ReadFileButton"
        Me.ReadFileButton.Size = New System.Drawing.Size(75, 23)
        Me.ReadFileButton.TabIndex = 0
        Me.ReadFileButton.Text = "Read"
        Me.ReadFileButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.EmptyLinesLabel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ExitApplicationButton)
        Me.Panel1.Controls.Add(Me.StatusLabel)
        Me.Panel1.Controls.Add(Me.ReadFileButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 262)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(967, 54)
        Me.Panel1.TabIndex = 1
        '
        'ExitApplicationButton
        '
        Me.ExitApplicationButton.Location = New System.Drawing.Point(880, 10)
        Me.ExitApplicationButton.Name = "ExitApplicationButton"
        Me.ExitApplicationButton.Size = New System.Drawing.Size(75, 23)
        Me.ExitApplicationButton.TabIndex = 2
        Me.ExitApplicationButton.Text = "Exit"
        Me.ExitApplicationButton.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(99, 20)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(39, 13)
        Me.StatusLabel.TabIndex = 1
        Me.StatusLabel.Text = "Label1"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstNameColumn, Me.MiddleIntialColumn, Me.LastNameColumn, Me.StreetColumn, Me.CityColumn, Me.StateColumn, Me.PostalColumn, Me.EmailColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(967, 262)
        Me.DataGridView1.TabIndex = 2
        '
        'FirstNameColumn
        '
        Me.FirstNameColumn.HeaderText = "First"
        Me.FirstNameColumn.Name = "FirstNameColumn"
        '
        'MiddleIntialColumn
        '
        Me.MiddleIntialColumn.HeaderText = "Middle"
        Me.MiddleIntialColumn.Name = "MiddleIntialColumn"
        '
        'LastNameColumn
        '
        Me.LastNameColumn.HeaderText = "Last"
        Me.LastNameColumn.Name = "LastNameColumn"
        '
        'StreetColumn
        '
        Me.StreetColumn.HeaderText = "Street"
        Me.StreetColumn.Name = "StreetColumn"
        '
        'CityColumn
        '
        Me.CityColumn.HeaderText = "City"
        Me.CityColumn.Name = "CityColumn"
        '
        'StateColumn
        '
        Me.StateColumn.HeaderText = "State"
        Me.StateColumn.Name = "StateColumn"
        '
        'PostalColumn
        '
        Me.PostalColumn.HeaderText = "Postal"
        Me.PostalColumn.Name = "PostalColumn"
        '
        'EmailColumn
        '
        Me.EmailColumn.HeaderText = "Email"
        Me.EmailColumn.Name = "EmailColumn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Empty line count"
        '
        'EmptyLinesLabel
        '
        Me.EmptyLinesLabel.AutoSize = True
        Me.EmptyLinesLabel.Location = New System.Drawing.Point(317, 20)
        Me.EmptyLinesLabel.Name = "EmptyLinesLabel"
        Me.EmptyLinesLabel.Size = New System.Drawing.Size(39, 13)
        Me.EmptyLinesLabel.TabIndex = 4
        Me.EmptyLinesLabel.Text = "Label2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 316)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Read file in class"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReadFileButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusLabel As Label
    Friend WithEvents ExitApplicationButton As Button
    Friend WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents MiddleIntialColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents StreetColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityColumn As DataGridViewTextBoxColumn
    Friend WithEvents StateColumn As DataGridViewTextBoxColumn
    Friend WithEvents PostalColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmailColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents EmptyLinesLabel As Label
End Class
