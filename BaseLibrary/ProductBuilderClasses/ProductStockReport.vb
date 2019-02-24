Imports System.Text

Namespace ProductBuilderClasses

    Public Class ProductStockReport
        Public Property HeaderPart() As String
        Public Property BodyPart() As String
        Public Property FooterPart() As String

        Public Overrides Function ToString() As String

            Return New StringBuilder().
                AppendLine(HeaderPart).
                AppendLine(BodyPart).
                AppendLine(FooterPart).
                ToString()

        End Function
    End Class
End Namespace