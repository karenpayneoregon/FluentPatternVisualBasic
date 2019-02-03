Namespace BaseClasses
    Public Class Country
        Public Property id() As Integer
        Public ReadOnly Property Identifier() As Integer
            Get
                Return id
            End Get
        End Property
        Public Property CountryName As String

        Public Overrides Function ToString() As String
            Return CountryName
        End Function
    End Class
End Namespace