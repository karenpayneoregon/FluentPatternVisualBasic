Namespace BaseClasses
    Public Class ContactPhoneType
        Public Property PhoneTypeIdenitfier() As Integer
        Public Property PhoneTypeDescription() As String

        Public Overrides Function ToString() As String
            Return PhoneTypeDescription
        End Function
    End Class
End Namespace