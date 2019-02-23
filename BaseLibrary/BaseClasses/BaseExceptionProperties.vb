Imports System.Data.SqlClient
Public Class BaseExceptionProperties
    Protected mHasException As Boolean
    Public ReadOnly Property HasException() As Boolean
        Get
            Return mHasException
        End Get
    End Property
    Protected mLastException As Exception
    Protected ReadOnly Property LastException() As Exception
        Get
            Return mLastException
        End Get
    End Property
    Public ReadOnly Property HasSqlException() As Boolean
        Get
            If LastException IsNot Nothing Then
                Return TypeOf LastException Is SqlException
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property LastExceptionMessage() As String
        Get
            Return LastException.Message
        End Get
    End Property
    Public ReadOnly Property IsSuccessFul() As Boolean
        Get
            Return Not HasException
        End Get
    End Property
End Class
