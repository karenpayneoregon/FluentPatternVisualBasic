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
        Me.mailProgressBar = New System.Windows.Forms.ProgressBar()
        Me.emlFilesListBox = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'sendMessagesButton
        '
        Me.sendMessagesButton.Location = New System.Drawing.Point(12, 23)
        Me.sendMessagesButton.Name = "sendMessagesButton"
        Me.sendMessagesButton.Size = New System.Drawing.Size(105, 23)
        Me.sendMessagesButton.TabIndex = 0
        Me.sendMessagesButton.Text = "Send messages"
        Me.sendMessagesButton.UseVisualStyleBackColor = True
        '
        'mailProgressBar
        '
        Me.mailProgressBar.Location = New System.Drawing.Point(123, 23)
        Me.mailProgressBar.Name = "mailProgressBar"
        Me.mailProgressBar.Size = New System.Drawing.Size(224, 23)
        Me.mailProgressBar.TabIndex = 1
        '
        'emlFilesListBox
        '
        Me.emlFilesListBox.FormattingEnabled = True
        Me.emlFilesListBox.Location = New System.Drawing.Point(12, 92)
        Me.emlFilesListBox.Name = "emlFilesListBox"
        Me.emlFilesListBox.Size = New System.Drawing.Size(332, 160)
        Me.emlFilesListBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Generated .eml files"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 264)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.emlFilesListBox)
        Me.Controls.Add(Me.mailProgressBar)
        Me.Controls.Add(Me.sendMessagesButton)
        Me.Name = "Form1"
        Me.Text = "Non-Builder example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sendMessagesButton As Button
    Friend WithEvents mailProgressBar As ProgressBar
    Friend WithEvents emlFilesListBox As ListBox
    Friend WithEvents Label1 As Label
End Class
