Imports System.Configuration
Imports System.IO
Imports System.Net.Configuration

Public Module ProjectMailSections
    Public GmailConfiguration1 As String = "mailSettings/smtp_1"
    Public GmailConfiguration2 As String = "mailSettings/smtp_2"
    Public Configuration1 As String = "mailSettings/smtp_3"
    Public ComcastConfiguration As String = "system.net/mailSettings/smtp"
End Module
Public Class MailConfiguration
    Private ReadOnly _smtpSection As SmtpSection

    Public Sub New(Optional ByVal section As String = "system.net/mailSettings/smtp")
        Try
            _smtpSection = (TryCast(ConfigurationManager.GetSection(section), SmtpSection))
        Catch ex As Exception
            '
            ' It's possible to land here if the following exception is raised
            '    mscorlib.pdb not loaded” yet the mscorlib.dll is NOT missing
            ' The fix
            '    Goto Tools, Options, Debugging, General, Enable Just My Code
        End Try
    End Sub
    ''' <summary>
    ''' Specifies whom an email is from
    ''' </summary>
    ''' <returns>From email address from app.config file under mailSettings</returns>
    Public ReadOnly Property FromAddress As String
        Get
            Return _smtpSection.From
        End Get
    End Property
    ''' <summary>
    ''' User name for SmtpClient setup
    ''' </summary>
    ''' <returns>user name from mailsection in app.config</returns>
    Public ReadOnly Property UserName As String
        Get
            Return _smtpSection.Network.UserName
        End Get
    End Property
    ''' <summary>
    ''' Password for SmtpClient setup
    ''' </summary>
    ''' <returns>password under mailsection from app.config</returns>
    Public ReadOnly Property Password As String
        Get
            Return _smtpSection.Network.Password
        End Get
    End Property
    ''' <summary>
    ''' Specify if default credentials are used for smtpclient configuration
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property DefaultCredentials() As Boolean
        Get
            Return _smtpSection.Network.DefaultCredentials
        End Get
    End Property
    ''' <summary>
    ''' Specifies if SSL is used on the mail server
    ''' </summary>
    ''' <returns>To use SSL from mailsection under app.config</returns>
    Public ReadOnly Property EnableSsl() As Boolean
        Get
            Return _smtpSection.Network.EnableSsl
        End Get
    End Property
    ''' <summary>
    ''' Get pickup folder when simulating sending email messages.
    ''' </summary>
    ''' <returns>Name of folder for sending messages too.</returns>
    Public ReadOnly Property PickupFolder() As String
        Get
            Dim mailDrop = _smtpSection.SpecifiedPickupDirectory.PickupDirectoryLocation
            If mailDrop IsNot Nothing Then
                mailDrop = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    _smtpSection.SpecifiedPickupDirectory.PickupDirectoryLocation)
            End If

            Return mailDrop
        End Get
    End Property
    ''' <summary>
    ''' Determines if the Pickup folder exists specified in app.config
    ''' </summary>
    ''' <returns></returns>
    Public Function PickupFolderExists() As Boolean
        Return Directory.Exists(PickupFolder)
    End Function
    ''' <summary>
    ''' Host for SmtpClient configuration
    ''' </summary>
    ''' <returns>Host</returns>
    Public ReadOnly Property Host As String
        Get
            Return _smtpSection.Network.Host
        End Get
    End Property
    ''' <summary>
    ''' Port for SmtpClient configuration
    ''' </summary>
    ''' <returns>Port</returns>
    Public ReadOnly Property Port As Integer
        Get
            Return _smtpSection.Network.Port
        End Get
    End Property
    ''' <summary>
    ''' Timeout for sending email messages
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property TimeOut As Integer
        Get
            Return 2000
        End Get
    End Property
End Class
