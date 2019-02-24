Namespace BaseClasses
    Public Class Contact
        ''' <summary>
        ''' Contact identifier
        ''' </summary>
        ''' <returns></returns>
        Public Property Id() As Integer
        ''' <summary>
        ''' Contact phone number
        ''' </summary>
        ''' <returns></returns>
        Public Property PhoneNumber() As String
        ''' <summary>
        ''' Status of contact
        ''' </summary>
        ''' <returns></returns>
        Public Property Active() As Boolean
        ''' <summary>
        ''' Foreign key to phone type reference table
        ''' </summary>
        ''' <returns></returns>
        Public Property PhoneTypeIdenitfier() As Integer
        ''' <summary>
        ''' English name for phone type
        ''' </summary>
        ''' <returns></returns>
        Public Property PhoneTypeDescription() As String
        Public ReadOnly Property PhoneType() As PhoneTypes
            Get
                Return CType(PhoneTypeIdenitfier, PhoneTypes)
            End Get
        End Property
        ''' <summary>
        ''' Foreign key to device type
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Maps to ContactContactDevices.Identifier
        ''' </remarks>
        Public Property Identifier() As Integer
        ''' <summary>
        ''' Provides DisplayMember for controls e.g. ComboBox
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return PhoneNumber
        End Function
    End Class
End Namespace