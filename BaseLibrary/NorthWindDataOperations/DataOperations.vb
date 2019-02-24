Imports System.Data.SqlClient
Imports BaseLibrary.BaseClasses
Imports DataProviderCommandHelpers

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

        Public Function ContactPhoneTypes() As List(Of ContactPhoneType)
            Dim contactPhoneTypesList As New List(Of ContactPhoneType)

            Dim selectStatement = "SELECT PhoneTypeIdenitfier,PhoneTypeDescription FROM dbo.PhoneType"

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}
                    Try

                        cn.Open()

                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()

                            contactPhoneTypesList.Add(New ContactPhoneType() With
                                                   {
                                                       .PhoneTypeIdenitfier = reader.GetInt32(0),
                                                       .PhoneTypeDescription = reader.GetString(1)
                                                   })
                        End While

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                End Using
            End Using

            Return contactPhoneTypesList

        End Function
        Public Function ContactDetails(pContactIdentifier As Integer) As Contact
            Dim contact As New Contact With {.Id = pContactIdentifier}

            Dim selectStatement = "SELECT " &
                                  "CCD.ContactIdentifier AS Id , " &
                                  "PT.PhoneTypeDescription , " &
                                  "CCD.PhoneNumber , " &
                                  "CCD.Active , " &
                                  "CCD.PhoneTypeIdenitfier , " &
                                  "CCD.Identifier " &
                                  "FROM  dbo.ContactContactDevices AS CCD " &
                                  "INNER JOIN dbo.PhoneType AS PT ON CCD.PhoneTypeIdenitfier = PT.PhoneTypeIdenitfier " &
                                  "WHERE  ( CCD.ContactIdentifier = @ContactIdentifier );"


            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}
                    cmd.Parameters.AddWithValue("@ContactIdentifier", pContactIdentifier)

                    Try

                        cn.Open()

                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then

                            reader.Read()

                            contact.PhoneTypeDescription = reader.GetString(1)
                            contact.PhoneNumber = reader.GetString(2)
                            contact.Active = reader.GetBoolean(3)
                            contact.PhoneTypeIdenitfier = reader.GetInt32(4)
                            contact.Identifier = reader.GetInt32(5)
                        End If

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try
                End Using
            End Using

            Return contact

        End Function
        Public Function UpdateContactPhone(contact As Contact, Optional showCommand As Boolean = False) As Boolean
            Dim updateStatement As String =
                    "UPDATE dbo.ContactContactDevices " &
                    "SET " &
                    "PhoneTypeIdenitfier = @PhoneTypeIdenitfier, " &
                    "PhoneNumber = @PhoneNumber ," &
                    "Active = @Active " &
                    "WHERE ContactIdentifier = @ContactIdentifier"

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = updateStatement}

                    cmd.Parameters.AddWithValue("@PhoneTypeIdenitfier", contact.PhoneTypeIdenitfier)
                    cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber)
                    cmd.Parameters.AddWithValue("@Active", contact.Active)
                    cmd.Parameters.AddWithValue("@ContactIdentifier", contact.Id)

                    If showCommand Then
                        Console.WriteLine(cmd.ActualCommandText())
                    End If

                    Try
                        cn.Open()
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try
                End Using
            End Using

            Return IsSuccessFul

        End Function
        ''' <summary>
        ''' Returns an order list of column names for the current catalog.
        ''' </summary>
        ''' <param name="TableName">Existing table in current catalog</param>
        ''' <returns>Ordered list of column names</returns>
        Public Function TableColumnNames(TableName As String, Optional IncludePrimaryKeys As Boolean = False) As List(Of String)
            Dim columnNameList As New List(Of String)
            Dim selectStatement =
                    "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " &
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