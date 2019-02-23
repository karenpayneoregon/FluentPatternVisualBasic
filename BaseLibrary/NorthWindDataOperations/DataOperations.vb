Imports System.Data.SqlClient
Imports BaseLibrary.BaseClasses

Namespace NorthWindDataOperations
    Public Class DataOperations
        Inherits SqlServerConnection

        Public Sub New()
            DefaultCatalog = "NorthWindAzure1"
        End Sub
        ''' <summary>
        ''' Return a list of column names for Customers, Contact and Countries tables
        ''' excluding primary key column names. Column names are used to populate
        ''' a ComboBox used to allow the user to select an ORDER BY when reading data.
        ''' </summary>
        ''' <returns></returns>
        Public Function ColumnNamesForCustomersContactsCountries() As List(Of String)
            Dim columnNameList As New List(Of String)

            Dim customersColumnNames = TableColumnNames("Customers")
            Dim contactColumnNames = TableColumnNames("Contact")
            Dim countriesColumnNames = TableColumnNames("Countries")

            columnNameList.AddRange(customersColumnNames)
            columnNameList.AddRange(contactColumnNames)
            columnNameList.AddRange(countriesColumnNames)

            columnNameList.Sort()

            Return columnNameList
        End Function
        ''' <summary>
        ''' Returns a list of countries.
        ''' </summary>
        ''' <returns></returns>
        Public Function CountryNames() As List(Of Country)
            Dim countryNameList As New List(Of Country)
            Dim selectStatement = "SELECT id,CountryName FROM dbo.Countries"

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}
                    Try

                        cn.Open()

                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()

                            countryNameList.Add(New Country() With
                                                   {
                                                        .id = reader.GetInt32(0),
                                                        .CountryName = reader.GetString(1)
                                                   })
                        End While

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                End Using
            End Using

            Return countryNameList

        End Function
        ''' <summary>
        ''' Returns an order list of column names for the current catalog.
        ''' </summary>
        ''' <param name="TableName">Existing table in current catalog</param>
        ''' <returns>Ordered list of column names</returns>
        Public Function TableColumnNames(TableName As String, Optional IncludePrimaryKeys As Boolean = False) As List(Of String)
            Dim columnNameList As New List(Of String)
            Dim selectStatement = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " &
                                  "WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA='dbo' " &
                                  "ORDER BY COLUMN_NAME"

            Dim columnName As String = ""
            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}
                    Try

                        cmd.Parameters.AddWithValue("@TableName", TableName)

                        cn.Open()

                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()

                            columnName = reader.GetString(0)

                            If Not IncludePrimaryKeys Then
                                If Not columnName.Contains("Identifier") AndAlso Not columnName.Equals("id") Then
                                    columnNameList.Add(columnName)
                                End If
                            Else
                                columnNameList.Add(columnName)
                            End If

                        End While


                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                End Using
            End Using

            Return columnNameList

        End Function
    End Class
End Namespace