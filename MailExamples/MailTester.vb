Imports System.Net.Mail
Imports BaseLibrary
Imports BaseLibrary.Builders

Public Class MailTester
    Public Sub Example1()

        Dim mailer As New MailBuilder()

        mailer.CreateMail(GmailConfiguration1).
            WithRecipient("karen@comcast.net").
            WithCarbonCopy("mary@gmail.com").
            WithSubject("Test").
            AsRichContent().
            WithHtmlView("<p>Hello <strong>Bob</strong></p>").
            WithPickupFolder().
            WithTimeout(2000).
            SendMessage()

        mailer.Begin().
            WithRecipient("karen11@comcast.net").
            WithCarbonCopy("mary@gmail.com").
            WithSubject("Test").
            AsRichContent().
            WithBody("<p>Hello <strong>Joan</strong></p>").
            WithPickupFolder().
            WithTimeout(2000).
            SendMessage()

        mailer.Begin(GmailConfiguration1).
            WithRecipient("karen11@comcast.net").
            WithCarbonCopy("mary@gmail.com").
            WithSubject("Test").
            WithBody("Hello Gary").
            WithPickupFolder().
            WithTimeout(2000).
            Priority(MailPriority.High).
            SendMessage()

    End Sub
End Class