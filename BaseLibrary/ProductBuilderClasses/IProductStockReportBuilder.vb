Imports BaseLibrary.Interfaces

Namespace ProductBuilderClasses
    Public Class ProductStockReportBuilder
        Implements IProductStockReportBuilder

        Private productStockReport As ProductStockReport
        Private products As IEnumerable(Of Product)

        Public Sub New(products As IEnumerable(Of Product))
            Me.products = products
            productStockReport = New ProductStockReport()
        End Sub
        Private Function BuildHeader() As IProductStockReportBuilder _
            Implements IProductStockReportBuilder.BuildHeader

            productStockReport.
                HeaderPart = $"REPORT FOR PRODUCTS ON DATE: {Date.Now}{Environment.NewLine}"

            Return Me
        End Function

        Private Function BuildBody() As IProductStockReportBuilder _
            Implements IProductStockReportBuilder.BuildBody

            productStockReport.BodyPart = String.Join(
                Environment.NewLine,
                products.Select(Function(p) $"Product name: {p.Name,8}, product price: {p.Price}"))

            Return Me

        End Function

        Private Function BuildFooter() As IProductStockReportBuilder _
            Implements IProductStockReportBuilder.BuildFooter

            productStockReport.FooterPart = vbLf & "Report provided by the ABC company."

            Return Me

        End Function

        Public Function GetReport() As ProductStockReport Implements IProductStockReportBuilder.GetReport

            Dim productStockReport = Me.productStockReport

            Clear()

            Return productStockReport

        End Function

        Private Sub Clear()
            productStockReport = New ProductStockReport()
        End Sub
    End Class
End Namespace