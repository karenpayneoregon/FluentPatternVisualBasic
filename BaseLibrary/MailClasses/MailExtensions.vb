Imports System.Net.Mail
''' <summary>
''' Helper language extension methods for creating email messages
''' </summary>
Public Module MailExtensions
    ''' <summary>
    ''' Add alternate view for html
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="message"></param>
    ''' <remarks>
    ''' Value is shorter line in code that sends emails
    ''' </remarks>
    <Runtime.CompilerServices.Extension>
    Public Sub HTmlView(sender As AlternateViewCollection, message As String)
        sender.Add(AlternateView.CreateAlternateViewFromString(message, Nothing, "text/html"))
    End Sub
    ''' <summary>
    ''' Add alternate view for plain text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="message"></param>
    ''' <remarks>
    ''' Value is shorter line in code that sends emails
    ''' </remarks>
    <Runtime.CompilerServices.Extension>
    Public Sub PlainTextView(sender As AlternateViewCollection, message As String)
        sender.Add(AlternateView.CreateAlternateViewFromString(message, Nothing, "text/plain"))
    End Sub
End Module
