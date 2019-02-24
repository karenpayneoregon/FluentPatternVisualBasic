Imports BaseLibrary.Interfaces

Namespace ProductBuilderClasses
    Public Class ProductStockReportBuilder
        Implements IProductStockReportBuilder

        Private _productStockReport As ProductStockReport
        Private _products As IEnumerable(Of Product)

        Public Sub New(products As IEnumerable(Of Product))
            _products = products
            _productStockReport = New ProductStockReport()
        End Sub
        Private Function BuildHeader() As IProductStockReportBuilder _
            Implements IProductStockReportBuilder.BuildHeader

            _productStockReport.
                HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {Date.Now}{Environment.NewLine}"

            Return Me
        End Function

        Private Function BuildBody() As IProductStockReportBuilder _
            Implements IProductStockReportBuilder.BuildBody

            _productStockReport.BodyPart = String.Join(
                Environment.NewLine,
                _products.Select(Function(p) $"Product name: {p.Name}, product price: {p.Price}"))

            Return Me

        End Function

        Private Function BuildFooter() As IProductStockReportBuilder _
            Implements IProductStockReportBuilder.BuildFooter

            _productStockReport.FooterPart = vbLf & "Report provided by the ABC company."

            Return Me

        End Function

        Public Function GetReport() As ProductStockReport Implements IProductStockReportBuilder.GetReport

            Dim productStockReport = _productStockReport

            Clear()

            Return productStockReport

        End Function

        Private Sub Clear()
            _productStockReport = New ProductStockReport()
        End Sub
    End Class
End Namespace