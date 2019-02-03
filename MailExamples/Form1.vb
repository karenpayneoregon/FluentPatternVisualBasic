
Public Class Form1
    Private Sub sendMessagesButton_Click(sender As Object, e As EventArgs) Handles sendMessagesButton.Click
        CleanMailFolder()
        Dim mailOperationsTest As New MailTester

        mailOperationsTest.Example1()
    End Sub
End Class
