Imports System.Net
Imports System.Net.Mail
Public Class Tester
    Public Sub Example1()

        Dim mailer As New MailBuilder()

        mailer.CreateMail(GmailConfiguration1).
            WithRecipient("karen@comcast.net").
            WithRecipient("bill@yahoo.com").
            WithCarbonCopy("mary@gmail.com").
            WithCarbonCopy("Jack@gmail.com").
            WithSubject("January newsletter").
            WithHtmlView("<p>Hello <strong>Bob</strong></p>...").
            SendMessage()


        mailer.CreateMail(GmailConfiguration1).
            WithRecipient("karen11@comcast.net").
            WithCarbonCopy("mary@gmail.com").
            WithSubject("Test").
            AsRichContent().
            WithBody("<p>Hello <strong>Joan</strong></p>").
            WithPickupFolder().
            WithTimeout(2000).
            SendMessage()

        mailer.CreateMail(GmailConfiguration1).
            WithRecipient("karen11@comcast.net").
            WithCarbonCopy("mary@gmail.com").
            WithSubject("Test").
            WithBody("<p>Hello <strong>Gary</strong></p>").
            WithPickupFolder().
            WithTimeout(2000).
            Priority(MailPriority.High).
            SendMessage()


    End Sub
End Class
''' <summary>
''' Used to build a complete email with the ability to send an email message.
''' </summary>
''' <remarks>
''' Developer can expose Message, Configuration and Client as Public if so desired.
''' </remarks>
Public Class MailBuilder
    ''' <summary>
    ''' Represents a <see cref="MailMessage">MailMessage</see>
    ''' </summary>
    Private Message As MailMessage
    ''' <summary>
    ''' Configuration for <see cref="Client">Client</see>
    ''' </summary>
    Private Configuration As MailConfiguration
    ''' <summary>
    ''' Underlying <see cref="SmtpClient">SmtpClient</see>
    ''' </summary>
    Private Client As SmtpClient
    ''' <summary>
    ''' Instantiation for creating a email message using a <see cref="MailConfiguration">MailConfiguration</see>
    ''' </summary>
    ''' <param name="pConfiguration"></param>
    ''' <returns>MailBuilder</returns>
    Public Function CreateMail(pConfiguration As String) As MailBuilder

        Configuration = New MailConfiguration(pConfiguration)

        Client = New SmtpClient(Configuration.Host, Configuration.Port)
        Client.Credentials = New NetworkCredential(Configuration.UserName, Configuration.Password)
        Client.EnableSsl = True
        Client.Timeout = Configuration.TimeOut

        Message = New MailMessage() With {.From = New MailAddress(Configuration.FromAddress), .IsBodyHtml = False}

        Return Me

    End Function
    ''' <summary>
    ''' Override default <see cref="SmtpClient.Timeout">Timeout</see> for sending email message
    ''' </summary>
    ''' <param name="pTimeout"></param>
    ''' <returns>MailBuilder</returns>
    Public Function WithTimeout(pTimeout As Integer) As MailBuilder

        Client.Timeout = pTimeout

        Return Me

    End Function
    ''' <summary>
    ''' Subject of email <see cref="MailMessage.Subject">subject</see>
    ''' </summary>
    ''' <param name="pSubject">Text for subject of email message</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithSubject(pSubject As String) As MailBuilder

        Message.Subject = pSubject

        Return Me

    End Function
    ''' <summary>
    ''' Specifies whom to send the email message too.
    ''' </summary>
    ''' <param name="pSender">Email address</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithRecipient(pSender As String) As MailBuilder

        Message.To.Add(pSender)

        Return Me

    End Function
    ''' <summary>
    ''' Specifies a carbon copy of the email message too.
    ''' </summary>
    ''' <param name="pSender">Email address</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithCarbonCopy(pSender As String) As MailBuilder

        Message.CC.Add(pSender)

        Return Me

    End Function
    ''' <summary>
    ''' Specifies a blind carbon copy of the email message too.
    ''' </summary>
    ''' <param name="pSender">Email address</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithBindCarbonCopy(pSender As String) As MailBuilder

        Message.Bcc.Add(pSender)

        Return Me

    End Function
    ''' <summary>
    ''' Sets the email <see cref="MailMessage.IsBodyHtml">as rich content</see> 
    ''' </summary>
    ''' <returns>MailBuilder</returns>
    Public Function AsRichContent() As MailBuilder

        Message.IsBodyHtml = True
        Return Me

    End Function
    ''' <summary>
    ''' Set body of email message <see cref="MailMessage.Body">body</see>
    ''' </summary>
    ''' <param name="pMessage"></param>
    ''' <returns>MailBuilder</returns>
    Public Function WithBody(pMessage As String) As MailBuilder

        Message.Body = pMessage
        Return Me

    End Function
    ''' <summary>
    ''' Body of message as plain text.
    ''' </summary>
    ''' <param name="pMessage">Text for body of email</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithTextView(pMessage As String) As MailBuilder

        Message.AlternateViews.PlainTextView(pMessage)
        Return Me

    End Function
    Private usingHtmlMessageBody As Boolean = False
    ''' <summary>
    ''' Body of message as HTML formatted.
    ''' </summary>
    ''' <param name="pMessage">Text for body of email</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithHtmlView(pMessage As String) As MailBuilder

        Message.AlternateViews.HTmlView(pMessage)
        usingHtmlMessageBody = True

        Return Me

    End Function
    ''' <summary>
    ''' The list of the addresses to reply to for the mail message.
    ''' </summary>
    ''' <param name="pReplayAddresses">list of email addresses</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithReplyTo(pReplayAddresses As String()) As MailBuilder

        For Each address As String In pReplayAddresses
            Message.ReplyToList.Add(New MailAddress(address))
        Next

        Return Me

    End Function
    ''' <summary>
    ''' Include one or more physical files as attachments
    ''' </summary>
    ''' <param name="pFileList">files with full path</param>
    ''' <returns>MailBuilder</returns>
    Public Function WithAttachments(pFileList As String()) As MailBuilder

        For Each file As String In pFileList
            Message.Attachments.Add(New Attachment(file))
        Next

        Return Me

    End Function
    ''' <summary>
    ''' Specifies the priority of the email
    ''' </summary>
    ''' <param name="pPriority">Normal, Low, High</param>
    ''' <returns>MailBuilder</returns>
    Public Function Priority(pPriority As MailPriority) As MailBuilder
        Message.Priority = pPriority
        Return Me
    End Function
    ''' <summary>
    ''' Indicates the message is to be sent to a folder.
    ''' </summary>
    ''' <returns>MailBuilder</returns>
    Public Function WithPickupFolder() As MailBuilder

        Client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory
        Client.PickupDirectoryLocation = Configuration.PickupFolder
        Client.EnableSsl = False

        Return Me

    End Function
    ''' <summary>
    ''' Send the email
    ''' </summary>
    ''' <remarks>
    ''' Requires to and subject, From comes from the app.Config file.
    ''' </remarks>
    Public Sub SendMessage()

        If Message.To.Count = 0 Then
            Throw New Exception("Missing send to address")
        End If

        If String.IsNullOrWhiteSpace(Message.Subject) Then
            Throw New Exception("Missing subject")
        End If


        Client.Send(Message)

    End Sub
End Class