Imports BaseLibrary.Interfaces

Namespace ProductBuilderClasses

    Public Class ProductStockReportDirector
        Private ReadOnly _productStockReportBuilder As IProductStockReportBuilder

        Public Sub New(productStockReportBuilder As IProductStockReportBuilder)
            _productStockReportBuilder = productStockReportBuilder
        End Sub

        Public Sub BuildStockReport()
            _productStockReportBuilder.BuildHeader()
            _productStockReportBuilder.BuildBody()
            _productStockReportBuilder.BuildFooter()
        End Sub
    End Class
End Namespace