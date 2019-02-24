<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactEditorForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.companyNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.contactNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.phoneTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.phoneNumberTextBox = New System.Windows.Forms.TextBox()
        Me.activeCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.updateButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company "
        '
        'companyNameTextBox
        '
        Me.companyNameTextBox.Location = New System.Drawing.Point(88, 31)
        Me.companyNameTextBox.Name = "companyNameTextBox"
        Me.companyNameTextBox.ReadOnly = True
        Me.companyNameTextBox.Size = New System.Drawing.Size(194, 20)
        Me.companyNameTextBox.TabIndex = 1
        Me.companyNameTextBox.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contact"
        '
        'contactNameTextBox
        '
        Me.contactNameTextBox.Location = New System.Drawing.Point(88, 68)
        Me.contactNameTextBox.Name = "contactNameTextBox"
        Me.contactNameTextBox.ReadOnly = True
        Me.contactNameTextBox.Size = New System.Drawing.Size(194, 20)
        Me.contactNameTextBox.TabIndex = 3
        Me.contactNameTextBox.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Phone type"
        '
        'phoneTypeComboBox
        '
        Me.phoneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.phoneTypeComboBox.FormattingEnabled = True
        Me.phoneTypeComboBox.Location = New System.Drawing.Point(88, 94)
        Me.phoneTypeComboBox.Name = "phoneTypeComboBox"
        Me.phoneTypeComboBox.Size = New System.Drawing.Size(194, 21)
        Me.phoneTypeComboBox.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Phone"
        '
        'phoneNumberTextBox
        '
        Me.phoneNumberTextBox.Location = New System.Drawing.Point(88, 131)
        Me.phoneNumberTextBox.Name = "phoneNumberTextBox"
        Me.phoneNumberTextBox.Size = New System.Drawing.Size(100, 20)
        Me.phoneNumberTextBox.TabIndex = 1
        '
        'activeCheckBox
        '
        Me.activeCheckBox.AutoSize = True
        Me.activeCheckBox.Location = New System.Drawing.Point(88, 157)
        Me.activeCheckBox.Name = "activeCheckBox"
        Me.activeCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.activeCheckBox.TabIndex = 2
        Me.activeCheckBox.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Active"
        '
        'updateButton
        '
        Me.updateButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.updateButton.Location = New System.Drawing.Point(12, 192)
        Me.updateButton.Name = "updateButton"
        Me.updateButton.Size = New System.Drawing.Size(75, 23)
        Me.updateButton.TabIndex = 3
        Me.updateButton.Text = "Update"
        Me.updateButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelButton.Location = New System.Drawing.Point(207, 192)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 4
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'ContactEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 227)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.updateButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.activeCheckBox)
        Me.Controls.Add(Me.phoneNumberTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.phoneTypeComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.contactNameTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.companyNameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ContactEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit contact"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents companyNameTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents contactNameTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents phoneTypeComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents phoneNumberTextBox As TextBox
    Friend WithEvents activeCheckBox As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents updateButton As Button
    Friend WithEvents cancelButton As Button
End Class
