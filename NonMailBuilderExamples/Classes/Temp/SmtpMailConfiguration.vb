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
        _smtpSection = (TryCast(ConfigurationManager.GetSection(section), SmtpSection))
    End Sub
    Public ReadOnly Property FromAddress As String
        Get
            Return _smtpSection.From
        End Get
    End Property
    Public ReadOnly Property UserName As String
        Get
            Return _smtpSection.Network.UserName
        End Get
    End Property
    Public ReadOnly Property Password As String
        Get
            Return _smtpSection.Network.Password
        End Get
    End Property
    Public ReadOnly Property DefaultCredentials() As Boolean
        Get
            Return _smtpSection.Network.DefaultCredentials
        End Get
    End Property
    Public ReadOnly Property EnableSsl() As Boolean
        Get
            Return _smtpSection.Network.EnableSsl
        End Get
    End Property
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
    Public Function PickupFolderExists() As Boolean
        Return Directory.Exists(PickupFolder)
    End Function
    Public ReadOnly Property Host As String
        Get
            Return _smtpSection.Network.Host
        End Get
    End Property
    Public ReadOnly Property Port As Integer
        Get
            Return _smtpSection.Network.Port
        End Get
    End Property
    Public ReadOnly Property TimeOut As Integer
        Get
            Return 2000
        End Get
    End Property
End Class
