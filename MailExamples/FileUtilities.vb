Imports System.Configuration
Imports System.IO
Imports System.Net.Configuration

Module FileUtilities
    ''' <summary>
    ''' Delete any files in the pickup folder
    ''' </summary>
    Public Sub CleanMailFolder()

        Dim mailPickupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                        (TryCast(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection)).
                                           SpecifiedPickupDirectory.PickupDirectoryLocation)

        Dim mailFiles = Directory.GetFiles(mailPickupFolder, "*.eml")

        For index As Integer = 0 To mailFiles.Count() - 1
            File.Delete(mailFiles(index))
        Next

    End Sub
End Module
