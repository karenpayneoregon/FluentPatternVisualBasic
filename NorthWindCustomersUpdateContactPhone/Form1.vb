Imports BaseLibrary
Imports BaseLibrary.BaseClasses
Imports WindowsFormsLibrary

Public Class Form1
    '
    Private bindingSourceCustomers As New BindingSource
    ''' <summary>
    ''' Responsible for data operations
    ''' </summary>
    Private northWindDataOperations As NorthWindDataOperations.DataOperations = New NorthWindDataOperations.DataOperations
    ''' <summary>
    ''' Cache phone types as they don't change
    ''' </summary>
    ''' <returns></returns>
    Property contactPhoneTypeList() As List(Of ContactPhoneType)

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim customerReader = New CustomersBuilder


        bindingSourceCustomers.DataSource = customerReader.
            Begin().
            OrderBy("LastName").
            DescendingOrder.
            WithoutIdentifiers().
            ReadAllCustomersRecords()

        DataGridView1.DataSource = bindingSourceCustomers
        DataGridView1.ExpandAllColumns
        DataGridView1.NormalizeColumnHeaders()

        contactPhoneTypeList = northWindDataOperations.ContactPhoneTypes()

        If Debugger.IsAttached Then
            DataBindings.Add("Text", bindingSourceCustomers, "CustomerIdentifier")
        End If

        '
        ' Move to the record we want to work with
        '
        Dim position = bindingSourceCustomers.Find("CustomerIdentifier", 3)
        AddHandler bindingSourceCustomers.PositionChanged, AddressOf PositionChanged

        If position > -1 Then
            bindingSourceCustomers.Position = position
        End If
    End Sub

    Private Sub PositionChanged(sender As Object, e As EventArgs)

    End Sub
    ''' <summary>
    ''' Edit current company contact phone details
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub editCurrentContactPhone_Click(sender As Object, e As EventArgs) Handles editCurrentContactPhone.Click

        Dim currentCustomerRow = CType(bindingSourceCustomers.Current, DataRowView).Row
        Dim contactIdentifier = currentCustomerRow.Field(Of Integer)("CustomerIdentifier")
        Dim contactName = $"{currentCustomerRow.Field(Of String)("FirstName")} {currentCustomerRow.Field(Of String)("LastName")}"
        Dim companyName = currentCustomerRow.Field(Of String)("CompanyName")

        Dim contact = northWindDataOperations.ContactDetails(contactIdentifier)

        Dim f As New ContactEditorForm(companyName, contactName)
        f.contact = contact
        f.phoneTypeComboBox.DataSource = contactPhoneTypeList

        Dim position = f.phoneTypeComboBox.FindString(contact.PhoneTypeDescription)

        If position > -1 Then
            f.phoneTypeComboBox.SelectedIndex = position
        End If

        Try

            If f.ShowDialog() = DialogResult.OK Then
                Dim customerReader = New CustomersBuilder

                Dim result = customerReader.
                        Begin().
                        UpdateContactPhone(contact.Id).
                        SetContactPhoneTypeAs(contact.PhoneType).
                        WithPhoneNumber(contact.PhoneNumber).
                        PhoneStatusIsActive(contact.Active).
                        UpdateContactPhoneDetails()

                If Not result Then
                    MessageBox.Show($"Failed to update contact for {companyName}")
                End If
            End If

        Finally
            f.Dispose()
        End Try
    End Sub
End Class
