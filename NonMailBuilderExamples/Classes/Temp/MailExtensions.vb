Imports System.Net.Mail

Public Module MailExtensions
    ''' <summary>
    ''' Add alternate view for html
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="message"></param>
    ''' <remarks>
    ''' Value is shorter line in code that sends emails
    ''' </remarks>
    <System.Runtime.CompilerServices.Extension>
    Public Sub HTmlView(ByVal sender As AlternateViewCollection, ByVal message As String)
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
    <System.Runtime.CompilerServices.Extension>
    Public Sub PlainTextView(ByVal sender As AlternateViewCollection, ByVal message As String)
        sender.Add(AlternateView.CreateAlternateViewFromString(message, Nothing, "text/plain"))
    End Sub

End Module
