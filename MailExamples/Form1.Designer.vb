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
        Me.sendMessagesButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.emlFilesListBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'sendMessagesButton
        '
        Me.sendMessagesButton.Location = New System.Drawing.Point(19, 19)
        Me.sendMessagesButton.Name = "sendMessagesButton"
        Me.sendMessagesButton.Size = New System.Drawing.Size(329, 23)
        Me.sendMessagesButton.TabIndex = 0
        Me.sendMessagesButton.Text = "Send messages"
        Me.sendMessagesButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Generated .eml files"
        '
        'emlFilesListBox
        '
        Me.emlFilesListBox.FormattingEnabled = True
        Me.emlFilesListBox.Location = New System.Drawing.Point(16, 81)
        Me.emlFilesListBox.Name = "emlFilesListBox"
        Me.emlFilesListBox.Size = New System.Drawing.Size(332, 160)
        Me.emlFilesListBox.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 256)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.emlFilesListBox)
        Me.Controls.Add(Me.sendMessagesButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail Builder examples"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sendMessagesButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents emlFilesListBox As ListBox
End Class
