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
        Me.ShowChildFormButton = New System.Windows.Forms.Button()
        Me.StartStopTimerButton = New System.Windows.Forms.Button()
        Me.EnabledCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ShowChildFormButton
        '
        Me.ShowChildFormButton.Location = New System.Drawing.Point(35, 23)
        Me.ShowChildFormButton.Name = "ShowChildFormButton"
        Me.ShowChildFormButton.Size = New System.Drawing.Size(110, 23)
        Me.ShowChildFormButton.TabIndex = 0
        Me.ShowChildFormButton.Text = "Show child form"
        Me.ShowChildFormButton.UseVisualStyleBackColor = True
        '
        'StartStopTimerButton
        '
        Me.StartStopTimerButton.Location = New System.Drawing.Point(35, 63)
        Me.StartStopTimerButton.Name = "StartStopTimerButton"
        Me.StartStopTimerButton.Size = New System.Drawing.Size(110, 23)
        Me.StartStopTimerButton.TabIndex = 1
        Me.StartStopTimerButton.Text = "Start/stop Timer"
        Me.StartStopTimerButton.UseVisualStyleBackColor = True
        '
        'EnabledCheckBox
        '
        Me.EnabledCheckBox.AutoSize = True
        Me.EnabledCheckBox.Location = New System.Drawing.Point(157, 67)
        Me.EnabledCheckBox.Name = "EnabledCheckBox"
        Me.EnabledCheckBox.Size = New System.Drawing.Size(65, 17)
        Me.EnabledCheckBox.TabIndex = 2
        Me.EnabledCheckBox.Text = "Enabled"
        Me.EnabledCheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 123)
        Me.Controls.Add(Me.EnabledCheckBox)
        Me.Controls.Add(Me.StartStopTimerButton)
        Me.Controls.Add(Me.ShowChildFormButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple Delegate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ShowChildFormButton As Button
    Friend WithEvents StartStopTimerButton As Button
    Friend WithEvents EnabledCheckBox As CheckBox
End Class
