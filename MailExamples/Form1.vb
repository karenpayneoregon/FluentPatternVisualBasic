
Imports System.ComponentModel
Imports System.Configuration
Imports System.IO
Imports System.Net.Configuration
Imports BaseLibrary

Public Class Form1

    Private mailOperations As New MailOperations
    Private Sub sendMessagesButton_Click(sender As Object, e As EventArgs) Handles sendMessagesButton.Click
        CleanMailFolder()
        Dim mailOperationsTest As New MailTester

        WatchMailPickup()

        sendMessagesButton.Enabled = False

        mailOperationsTest.Example1()

        sendMessagesButton.Enabled = True

    End Sub
    Private Sub WatchMailPickup()

        emlFilesListBox.Items.Clear()

        Dim pickupFolder = Path.
                Combine(AppDomain.CurrentDomain.BaseDirectory,
                        (TryCast(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection)).
                           SpecifiedPickupDirectory.PickupDirectoryLocation)

        Dim mailDropFileSystemWatcher = New FileSystemWatcher(pickupFolder)

        AddHandler mailDropFileSystemWatcher.Created, AddressOf EmlFilesCreated

        mailDropFileSystemWatcher.EnableRaisingEvents = True

    End Sub

    Private Sub EmlFilesCreated(sender As Object, args As FileSystemEventArgs)


        If emlFilesListBox.InvokeRequired Then

            emlFilesListBox.Invoke(New MethodInvoker(
                Sub()
                    emlFilesListBox.Items.Add(args.Name)
                    emlFilesListBox.SelectedIndex = emlFilesListBox.Items.Count - 1
                End Sub))


        End If

    End Sub
End Class
