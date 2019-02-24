Imports System.Net.Mail
Namespace Classes
    Module SimpleMailOperations
        Public Sub Demo1()
            Dim mail As New MailMessage()
            mail.From = New MailAddress("jane@comcast.net")
            mail.To.Add("bill@comcast.net")
            mail.Subject = "This is an email"

            Dim plainMessage As AlternateView =
                    AlternateView.CreateAlternateViewFromString(
                        "Hello, plain text", Nothing, "text/plain")

            Dim htmlMessage As AlternateView =
                    AlternateView.CreateAlternateViewFromString(
                        "This is an automated email, please do not respond<br><br>An exception " &
                        "ocurred in <br><span style=""font-weight: bold; padding-left: 20px;" &
                        "padding-right:5px"">Application name</span>MyApp<br>" &
                        "<span style=""font-weight: bold; " &
                        " padding-left: 5px;padding-right:5px"">Application Version</span>" &
                        "1.00<br><span style=""font-weight: bold; padding-left: " &
                        "70px;padding-right:5px"">", Nothing, "text/html")

            mail.AlternateViews.Add(plainMessage)
            mail.AlternateViews.Add(htmlMessage)
            Dim smtp As New SmtpClient("smtp.comcast.net")
            smtp.Send(mail)
        End Sub

    End Module
End Namespace