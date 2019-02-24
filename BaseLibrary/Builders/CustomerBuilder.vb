
Imports System.Data.SqlClient
Imports BaseLibrary.BaseClasses


''' <summary>
''' Responsible for creating queries for Customers table.
''' </summary>
Public Class CustomersBuilder

    ''' <summary>
    ''' Container for Customers data
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Table() As DataTable
    ''' <summary>
    ''' Indicates if primary keys should be included in returning container.
    ''' </summary>
    ''' <returns></returns>
    Private Shared Property HideIdentifiers() As Boolean = False
    ''' <summary>
    ''' Specifies a column name to perform an ORDER BY on for Customers
    ''' </summary>
    ''' <returns></returns>
    Private Shared Property OrderByFieldName() As String
    ''' <summary>
    ''' Specifies descending or ascending order for SELECT Customers
    ''' </summary>
    ''' <returns></returns>
    Private Shared Property OrderDescending() As Boolean = False
    ''' <summary>
    ''' Used to indicate a country to find using country key.
    ''' </summary>
    ''' <returns></returns>
    Private Shared Property WhereCountryKeyIs() As Integer

    ''' <summary>
    ''' Initialize the builder
    ''' </summary>
    ''' <returns></returns>
    Public Function Begin() As CustomersBuilder

        Table = New DataTable()
        Return Me

    End Function
    Private mContactIdentfier As Integer
    ''' <summary>
    ''' Update contact phone number by contact identifier
    ''' </summary>
    ''' <param name="pContactIdentifier"></param>
    ''' <returns></returns>
    Public Function UpdateContactPhone(pContactIdentifier As Integer) As CustomersBuilder

        mContactIdentfier = pContactIdentifier
        Return Me

    End Function
    Private mPhoneType As PhoneTypes
    ''' <summary>
    ''' Set contact phone type for updating contact phone number
    ''' </summary>
    ''' <param name="pPhoneType"></param>
    ''' <returns></returns>
    Public Function SetContactPhoneTypeAs(pPhoneType As PhoneTypes) As CustomersBuilder

        mPhoneType = pPhoneType
        Return Me

    End Function
    Private mContactPhoneNumber As String
    ''' <summary>
    ''' Contact phone number to use for update
    ''' </summary>
    ''' <param name="pContactPhoneNumber"></param>
    ''' <returns></returns>
    Public Function WithPhoneNumber(pContactPhoneNumber As String) As CustomersBuilder

        mContactPhoneNumber = pContactPhoneNumber
        Return Me

    End Function
    Private mContactActiveStatus As Boolean
    Public Function PhoneStatusIsActive(pActive As Boolean) As CustomersBuilder

        mContactActiveStatus = pActive
        Return Me

    End Function
    Public Function UpdateContactPhoneDetails() As Boolean

        Dim contact As New Contact With
                {
                    .Id = mContactIdentfier,
                    .PhoneTypeIdenitfier = mPhoneType,
                    .Active = mContactActiveStatus,
                    .PhoneNumber = mContactPhoneNumber
                }

        Dim ops As New NorthWindDataOperations.DataOperations
        Return ops.UpdateContactPhone(contact)

    End Function
    ''' <summary>
    ''' Causes primary keys to be marked as not visible.
    ''' </summary>
    ''' <returns></returns>
    Public Function WithoutIdentifiers() As CustomersBuilder

        HideIdentifiers = True
        Return Me

    End Function
    ''' <summary>
    ''' Specifies column name/field name to order the SELECT by
    ''' </summary>
    ''' <param name="pFieldName"></param>
    ''' <returns></returns>
    Public Function OrderBy(pFieldName As String) As CustomersBuilder

        OrderByFieldName = pFieldName
        Return Me

    End Function
    ''' <summary>
    ''' Specifies descending order for ORDER BY
    ''' </summary>
    ''' <returns></returns>
    Public Function DescendingOrder() As CustomersBuilder

        OrderDescending = True
        Return Me

    End Function
    ''' <summary>
    ''' Specifies ascending order for ORDER BY
    ''' </summary>
    ''' <returns></returns>
    Public Function AscendingOrder() As CustomersBuilder

        OrderDescending = False
        Return Me

    End Function
    ''' <summary>
    ''' Specifies no ORDER BY on SELECT Customers
    ''' </summary>
    ''' <returns></returns>
    Public Function NoOrderBy() As CustomersBuilder

        OrderByFieldName = ""
        Return Me

    End Function
    ''' <summary>
    ''' Specifies a country key taken from a list of existing countries in a table of countries.
    ''' </summary>
    ''' <param name="countryId"></param>
    ''' <returns></returns>
    Public Function WhereCountryIdentifierIs(countryId As Integer) As CustomersBuilder

        WhereCountryKeyIs = countryId
        Return Me

    End Function

    ''' <summary>
    ''' Reads data from database table
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadAllCustomersRecords() As DataTable

        Dim ops = New DataOperations
        ops.GetCustomers()

        Return Table

    End Function
    ''' <summary>
    ''' Read customers by country using a country key
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadCustomerRecordsByCountry() As DataTable

        Dim ops = New DataOperations
        ops.GetCustomersByCountryName(WhereCountryKeyIs)

        Return Table

    End Function
    Private Class DataOperations
        Inherits SqlServerConnection

        ''' <summary>
        ''' Report last (if any) runtime exception.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Exception() As Exception
            Get
                Return mLastException
            End Get
        End Property
        Public Sub New()
            DefaultCatalog = "NorthWindAzure1"
        End Sub
        ''' <summary>
        ''' Base SELECT statement for reading Customers which will
        ''' have ORDER BY appended in some cases and in other cases
        ''' WHERE conditions appended.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' This method could potentially become a builder pattern also.
        ''' </remarks>
        Private Function BaseSelectCustomerStatement() As String
            Dim selectStatement As String =
                    "SELECT Cust.CustomerIdentifier ,Cust.CompanyName ,CT.ContactTitle ,C.FirstName ," &
                    "C.LastName ,Cust.ContactIdentifier ,Cust.ContactTypeIdentifier ,Cust.Street ," &
                    "Cust.City ,Cust.PostalCode ,Cust.CountryIdentifier ,Countries.CountryName,Cust.Phone ," &
                    "Cust.ModifiedDate " &
                    "FROM Customers AS Cust " &
                    "INNER JOIN Contact AS C ON Cust.ContactIdentifier = C.ContactIdentifier " &
                    "INNER JOIN ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier " &
                    "INNER JOIN Countries ON Cust.CountryIdentifier = Countries.id"


            '
            ' Will be talked about in article
            '
            'selectStatement = selectStatement.Replace(",Cust.ModifiedDate", "")

            Return selectStatement
        End Function
        ''' <summary>
        ''' Return all customers
        ''' </summary>
        Public Sub GetCustomers()

            mHasException = False

            Dim selectStatement = BaseSelectCustomerStatement()

            If Not String.IsNullOrWhiteSpace(OrderByFieldName) Then
                selectStatement = $"{selectStatement} ORDER BY {OrderByFieldName} {If(OrderDescending, "DESC", "ASC")}"
            End If

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}

                    Try

                        cn.Open()

                        Table.Load(cmd.ExecuteReader())

                        If HideIdentifiers Then
                            For Each column As DataColumn In Table.Columns
                                If column.ColumnName.ToLower().Contains("identifier") Then
                                    column.ColumnMapping = MappingType.Hidden
                                End If
                            Next
                        End If

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                End Using
            End Using
        End Sub
        ''' <summary>
        ''' Return all customers by specified country key
        ''' </summary>
        ''' <param name="countryIdentifier"></param>
        Public Sub GetCustomersByCountryName(countryIdentifier As Integer)

            mHasException = False

            Dim selectStatement = $"{BaseSelectCustomerStatement()} WHERE (Cust.CountryIdentifier = @CountryIdentifier)"


            If Not String.IsNullOrWhiteSpace(OrderByFieldName) Then
                selectStatement = $"{selectStatement} ORDER BY {OrderByFieldName} {If(OrderDescending, "DESC", "ASC")}"
            End If

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}

                    cmd.Parameters.AddWithValue("@CountryIdentifier", countryIdentifier)

                    Try

                        cn.Open()

                        Table.Load(cmd.ExecuteReader())

                        If HideIdentifiers Then
                            For Each column As DataColumn In Table.Columns
                                If column.ColumnName.ToLower().Contains("identifier") Then
                                    column.ColumnMapping = MappingType.Hidden
                                End If
                            Next
                        End If

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                End Using
            End Using
        End Sub

    End Class


End Class

