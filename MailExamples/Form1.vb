Imports System.Configuration
Imports System.IO
Imports System.Net.Configuration
Imports BaseLibrary


Public Class Form1

    'Private mailOperations As New MailOperations
    Private Sub sendMessagesButton_Click(sender As Object, e As EventArgs) Handles sendMessagesButton.Click

        CleanMailFolder()
        Dim mailOperationsTest As New MailTester

        emlFilesListBox.Items.Clear()
        WatchMailPickup()

        sendMessagesButton.Enabled = False

        mailOperationsTest.Example1()

        sendMessagesButton.Enabled = True

    End Sub
    Private Sub WatchMailPickup()

        Dim pickupFolder = Path.
                Combine(AppDomain.CurrentDomain.BaseDirectory,
                        (TryCast(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection)).
                           SpecifiedPickupDirectory.PickupDirectoryLocation)

        Dim mailDropFileSystemWatcher = New FileSystemWatcher(pickupFolder)

        AddHandler mailDropFileSystemWatcher.Created, AddressOf EmlFilesCreated

        mailDropFileSystemWatcher.EnableRaisingEvents = True

    End Sub
    ''' <summary>
    ''' Here we add newly created eml files to the ListBox generated
    ''' in the mail drop folder.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub EmlFilesCreated(sender As Object, args As FileSystemEventArgs)


        If emlFilesListBox.InvokeRequired Then

            emlFilesListBox.Invoke(New MethodInvoker(
                Sub()
                    If emlFilesListBox.FindString(args.Name) = -1 Then
                        emlFilesListBox.Items.Add(args.Name)
                        emlFilesListBox.SelectedIndex = emlFilesListBox.Items.Count - 1
                    End If
                End Sub))

        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        emlFilesListBox.Items.Clear()
    End Sub
End Class
