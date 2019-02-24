Imports BaseLibrary.BaseClasses

Public Class ContactEditorForm
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Contact As Contact
    Private companyName As String
    Private contactName As String
    Public Sub New(pCompanyName As String, pContactName As String)

        InitializeComponent()

        companyName = pCompanyName
        contactName = pContactName

    End Sub
    Private Sub ContactEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        companyNameTextBox.Text = companyName
        contactNameTextBox.Text = contactName
        phoneNumberTextBox.Text = contact.PhoneNumber
        activeCheckBox.Checked = contact.Active

        ActiveControl = phoneNumberTextBox
        phoneNumberTextBox.Select(0, 0)

    End Sub

    Private Sub ContactEditorForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        contact.PhoneNumber = phoneNumberTextBox.Text
        contact.PhoneTypeIdenitfier = CType(phoneTypeComboBox.SelectedItem, ContactPhoneType).PhoneTypeIdenitfier
        contact.Active = activeCheckBox.Checked
    End Sub
End Class