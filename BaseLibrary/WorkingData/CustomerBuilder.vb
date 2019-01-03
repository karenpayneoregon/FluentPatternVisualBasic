Imports System.Data.SqlClient

Public Class CustomersBuilder

    Private _hasException As Boolean
    Public ReadOnly Property HasException() As Boolean
        Get
            Return _hasException
        End Get
    End Property
    Private _LastException As Exception
    Public ReadOnly Property Exception() As Exception
        Get
            Return _LastException
        End Get
    End Property
    Public Shared Property Table() As DataTable
    Private Shared Property HideIdentifiers() As Boolean = False
    Private Shared Property OrderByFieldName() As String
    Private Shared Property OrderDecending() As Boolean = False
    Public Function Begin() As CustomersBuilder

        Table = New DataTable()
        Return Me

    End Function
    Public Function WithoutIdentifiers() As CustomersBuilder

        HideIdentifiers = True
        Return Me

    End Function
    Public Function OrderBy(pFieldName As String) As CustomersBuilder

        OrderByFieldName = pFieldName
        Return Me

    End Function
    Public Function DecendingOrder() As CustomersBuilder

        OrderDecending = True
        Return Me

    End Function
    Public Function Read() As DataTable

        Dim ops = New DataOperations
        ops.GetCustomers()

        _hasException = ops.HasException
        If _hasException Then
            _LastException = ops.Exception
        End If

        Return Table

    End Function
    Private Class DataOperations
        Inherits BaseSqlServerConnection

        Public ReadOnly Property Exception() As Exception
            Get
                Return mLastException
            End Get
        End Property
        Public Sub New()
            DefaultCatalog = "NorthWindAzure1"
        End Sub
        ''' <summary>
        ''' Return all customers
        ''' </summary>
        Public Sub GetCustomers()

            mHasException = False

            Dim selectStatement = "SELECT Cust.CustomerIdentifier ,Cust.CompanyName ,CT.ContactTitle ,C.FirstName ," &
                                  "C.LastName ,Cust.ContactIdentifier ,Cust.ContactTypeIdentifier ,Cust.Street ," &
                                  "Cust.City ,Cust.PostalCode ,Cust.CountryIdentifier ,Countries.CountryName,Cust.Phone ," &
                                  "Cust.ModifiedDate " &
                                  "FROM Customers AS Cust " &
                                  "INNER JOIN Contact AS C ON Cust.ContactIdentifier = C.ContactIdentifier " &
                                  "INNER JOIN ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier " &
                                  "INNER JOIN Countries ON Cust.CountryIdentifier = Countries.id"


            If Not String.IsNullOrWhiteSpace(OrderByFieldName) Then
                selectStatement &= $" ORDER BY {OrderByFieldName} {If(OrderDecending, "DESC", "ASC")}"
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

    End Class
End Class

