Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class MailOperations
    Inherits SqlServerConnection
    ''' <summary>
    ''' Responsible for obtaining various settings for sending email messages stored in the calling
    ''' application configuration file.
    ''' </summary>
    Private MailConfig As MailConfiguration
    Public ReadOnly Property PickupFolder As String
        Get
            Return MailConfig.PickupFolder
        End Get
    End Property
    ''' <summary>
    ''' Instantiates configuration class 
    ''' </summary>
    Public Sub New()
        MailConfig = New MailConfiguration(GmailConfiguration2)
    End Sub
    ''' <summary>
    ''' For test purposes remove all .eml files from pickup folder
    ''' which is setup in the calling application build event.
    ''' </summary>
    Public Sub FlushMailFolder()
        Dim mailFiles = Directory.GetFiles(PickupFolder)
        For index As Integer = 0 To mailFiles.Count() - 1
            File.Delete(mailFiles(index))
        Next
    End Sub
    ''' <summary>
    ''' Fixed example for obtaining message text for an email by a primary key
    ''' </summary>
    ''' <param name="messageIdentifier"></param>
    ''' <returns></returns>
    Public Function Message(Optional messageIdentifier As Integer = 1) As MailCanMessage

        DefaultCatalog = "EmailTesting"

        mHasException = False
        Dim cannedMessage As New MailCanMessage
        Dim selectStatement As String = "SELECT HtmlMessage,TextMessage " &
                                       $"FROM dbo.CannedMessages WHERE id = {messageIdentifier}"

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}
                Try
                    cn.Open()
                    Dim reader = cmd.ExecuteReader()
                    reader.Read()
                    cannedMessage.Html = reader.GetString(0)
                    cannedMessage.Plain = reader.GetString(1)
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try
            End Using
        End Using

        Return cannedMessage

    End Function
    ''' <summary>
    ''' Creates a list of recipients for sending messages.
    ''' </summary>
    ''' <returns>List of email objects obtained from a SQL-Server database table</returns>
    Public Function MailToList() As List(Of MailMessage)

        DefaultCatalog = "EmailTesting"

        mHasException = False
        Dim messageBodyData = Message()
        Dim htmlMessage = messageBodyData.Html
        Dim plainMessage = messageBodyData.Plain

        Dim result As New List(Of MailMessage)
        Dim selectStatement As String = "SELECT EmailAddress FROM EmailTesting.dbo.EmailAddresses"
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = selectStatement}

                Try
                    cn.Open()
                    Dim reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim mail = New MailMessage() With
                            {
                            .From = New MailAddress(MailConfig.FromAddress),
                            .Subject = "Example",
                            .IsBodyHtml = True
                            }
                        mail.To.Add(reader.GetString(0))
                        mail.AlternateViews.PlainTextView(plainMessage)
                        mail.AlternateViews.HTmlView(htmlMessage)
                        result.Add(mail)

                    End While
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Using
        Return result
    End Function
    ''' <summary>
    ''' Send a single email. This could be enhanced via subscribing
    ''' to SendCompleted event to determine issues and success perhaps
    ''' with a log file or email to the developer.
    ''' </summary>
    ''' <param name="pMessage"></param>
    ''' <param name="userPickupFolder"></param>
    Public Sub SendSingleMessage(pMessage As MailMessage, Optional userPickupFolder As Boolean = True)
        Using smtp = New SmtpClient(MailConfig.Host, MailConfig.Port)
            smtp.Credentials = New NetworkCredential(MailConfig.UserName, MailConfig.Password)

            If userPickupFolder Then
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory
                smtp.PickupDirectoryLocation = MailConfig.PickupFolder
            End If

            smtp.EnableSsl = Not userPickupFolder
            smtp.Send(pMessage)
        End Using
    End Sub
End Class
