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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.readCustomersByCountryButton = New System.Windows.Forms.Button()
        Me.countriesComboBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.readCustomersButton = New System.Windows.Forms.Button()
        Me.decendingOrderCheckBox = New System.Windows.Forms.CheckBox()
        Me.columnNamesComboBox = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(800, 345)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 345)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 105)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.readCustomersByCountryButton)
        Me.GroupBox2.Controls.Add(Me.countriesComboBox)
        Me.GroupBox2.Location = New System.Drawing.Point(308, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 84)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Read by country"
        '
        'readCustomersByCountryButton
        '
        Me.readCustomersByCountryButton.Location = New System.Drawing.Point(181, 23)
        Me.readCustomersByCountryButton.Name = "readCustomersByCountryButton"
        Me.readCustomersByCountryButton.Size = New System.Drawing.Size(75, 23)
        Me.readCustomersByCountryButton.TabIndex = 2
        Me.readCustomersByCountryButton.Text = "Read"
        Me.readCustomersByCountryButton.UseVisualStyleBackColor = True
        '
        'countriesComboBox
        '
        Me.countriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.countriesComboBox.FormattingEnabled = True
        Me.countriesComboBox.Location = New System.Drawing.Point(9, 23)
        Me.countriesComboBox.Name = "countriesComboBox"
        Me.countriesComboBox.Size = New System.Drawing.Size(152, 21)
        Me.countriesComboBox.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.readCustomersButton)
        Me.GroupBox1.Controls.Add(Me.decendingOrderCheckBox)
        Me.GroupBox1.Controls.Add(Me.columnNamesComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Order by"
        '
        'readCustomersButton
        '
        Me.readCustomersButton.Location = New System.Drawing.Point(181, 23)
        Me.readCustomersButton.Name = "readCustomersButton"
        Me.readCustomersButton.Size = New System.Drawing.Size(75, 23)
        Me.readCustomersButton.TabIndex = 2
        Me.readCustomersButton.Text = "Read"
        Me.readCustomersButton.UseVisualStyleBackColor = True
        '
        'decendingOrderCheckBox
        '
        Me.decendingOrderCheckBox.AutoSize = True
        Me.decendingOrderCheckBox.Location = New System.Drawing.Point(9, 50)
        Me.decendingOrderCheckBox.Name = "decendingOrderCheckBox"
        Me.decendingOrderCheckBox.Size = New System.Drawing.Size(78, 17)
        Me.decendingOrderCheckBox.TabIndex = 1
        Me.decendingOrderCheckBox.Text = "Decending"
        Me.decendingOrderCheckBox.UseVisualStyleBackColor = True
        '
        'columnNamesComboBox
        '
        Me.columnNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.columnNamesComboBox.FormattingEnabled = True
        Me.columnNamesComboBox.Location = New System.Drawing.Point(9, 23)
        Me.columnNamesComboBox.Name = "columnNamesComboBox"
        Me.columnNamesComboBox.Size = New System.Drawing.Size(152, 21)
        Me.columnNamesComboBox.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Builder patten sample"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents columnNamesComboBox As ComboBox
    Friend WithEvents readCustomersButton As Button
    Friend WithEvents decendingOrderCheckBox As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents readCustomersByCountryButton As Button
    Friend WithEvents countriesComboBox As ComboBox
End Class
