Imports WindowsFormsLibrary
Imports BaseLibrary
Imports BaseLibrary.BaseClasses

Public Class Form1
    ''' <summary>
    ''' 
    ''' </summary>
    Private bindingSourceCustomers As New BindingSource
    ''' <summary>
    ''' * Initialize reference tables
    ''' * Read Customers data using a builder class
    ''' * Format DataGridView columns
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim initialOrderByFieldName = "LastName"

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

        Dim northWindDataOperations = New NorthWindDataOperations.DataOperations

        columnNamesComboBox.DataSource = northWindDataOperations.ColumnNamesForCustomersContactsCountries
        columnNamesComboBox.SelectedIndex = columnNamesComboBox.FindString(initialOrderByFieldName)

        countriesComboBox.DataSource = northWindDataOperations.CountryNames()

    End Sub
    ''' <summary>
    ''' Display Customers records with a specific sort selected by the current user
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub readCustomersButton_Click(sender As Object, e As EventArgs) Handles readCustomersButton.Click

        bindingSourceCustomers.DataSource = Nothing

        Dim customerReader = New CustomersBuilder

        customerReader.Begin()
        customerReader.OrderBy(columnNamesComboBox.Text)

        If decendingOrderCheckBox.Checked Then
            customerReader.DescendingOrder()
        Else
            customerReader.AscendingOrder()
        End If

        bindingSourceCustomers.DataSource = customerReader.ReadAllCustomersRecords()
        DataGridView1.DataSource = bindingSourceCustomers

        DataGridView1.ExpandAllColumns
        DataGridView1.NormalizeColumnHeaders()

    End Sub
    ''' <summary>
    ''' Display Customers by country
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' In some edge cases column headers of the DataGridView may require two lines
    ''' which is dependent on width of column to underlying data.
    ''' </remarks>
    Private Sub readCustomersByCountryButton_Click(sender As Object, e As EventArgs) Handles readCustomersByCountryButton.Click
        bindingSourceCustomers.DataSource = Nothing

        Dim customerReader = New CustomersBuilder

        bindingSourceCustomers.DataSource = customerReader.
            Begin().
            NoOrderBy.
            WhereCountryIdentifierIs(CType(countriesComboBox.SelectedItem, Country).Identifier).
            ReadCustomerRecordsByCountry()


        DataGridView1.DataSource = bindingSourceCustomers

        DataGridView1.ExpandAllColumns
        DataGridView1.NormalizeColumnHeaders()

    End Sub

End Class
