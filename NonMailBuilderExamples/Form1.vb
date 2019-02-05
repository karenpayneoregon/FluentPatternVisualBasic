Imports System.ComponentModel
Imports System.Configuration
Imports System.IO
Imports System.Net.Configuration
Imports BaseLibrary

Public Class Form1
    Private WithEvents MailOperationsBackGroundWorker As New BackgroundWorker
    Private mailOperations As New MailOperations

    Private Sub sendMessagesButton_Click(sender As Object, e As EventArgs) _
        Handles sendMessagesButton.Click

        WatchMailPickup()

        ' reset
        mailProgressBar.Value = 0

        sendMessagesButton.Enabled = False

        MailOperationsBackGroundWorker.WorkerReportsProgress = True
        MailOperationsBackGroundWorker.WorkerSupportsCancellation = True

        mailOperations.FlushMailFolder()

        Dim mailMessageList = mailOperations.MailToList()
        MailOperationsBackGroundWorker.RunWorkerAsync(mailMessageList.Count)

    End Sub
    Private Sub WatchMailPickup()

        emlFilesListBox.Items.Clear()

        Dim pickupFolder = Path.
                Combine(AppDomain.CurrentDomain.BaseDirectory,
                        (TryCast(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection)).
                           SpecifiedPickupDirectory.PickupDirectoryLocation)

        Dim mailDropFileSystemWatcher = New FileSystemWatcher(pickupFolder)

        AddHandler mailDropFileSystemWatcher.Created, AddressOf emlFilesCreated

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

    ''' <summary>
    ''' Process email messages one at a time
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mailOperationsBackGroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) _
        Handles MailOperationsBackGroundWorker.DoWork

        Dim numberOfMessagesToProcess As Integer = CInt(e.Argument)

        For mailIndex As Integer = 1 To mailOperations.MailToList().Count - 1

            ' Using this because otherwise things run rather faster for demonstration purposes
            ' of 50 records.
            Threading.Thread.Sleep(100)

            mailOperations.SendSingleMessage(mailOperations.MailToList()(mailIndex))

            MailOperationsBackGroundWorker.
                ReportProgress(Convert.ToInt32((mailIndex / numberOfMessagesToProcess) * 100))
        Next

    End Sub
    ''' <summary>
    ''' Is fired off each time an iteration has completed in do work.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MailOperationsBackGroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) _
        Handles MailOperationsBackGroundWorker.ProgressChanged

        UpdateProgress(e.ProgressPercentage)

        If e.ProgressPercentage >= 98 Then
            MessageBox.Show("Finished")
        End If

    End Sub
    ''' <summary>
    ''' Is fired off when all messages have been sent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MailOperationsBackGroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) _
        Handles MailOperationsBackGroundWorker.RunWorkerCompleted

        mailProgressBar.Value = mailProgressBar.Maximum
        sendMessagesButton.Enabled = True

    End Sub
    ''' <summary>
    ''' This can be done in the changed event but split out so 
    ''' a developer can use this in another form.
    ''' </summary>
    ''' <param name="percentDone">Percentage done of the entire operation</param>
    Public Sub UpdateProgress(percentDone As Integer)

        mailProgressBar.Value = mailProgressBar.Maximum
        mailProgressBar.Value = percentDone

    End Sub
End Class
