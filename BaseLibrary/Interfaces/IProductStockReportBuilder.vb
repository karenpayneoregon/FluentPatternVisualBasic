Imports BaseLibrary.ProductBuilderClasses

Namespace Interfaces
    Public Interface IProductStockReportBuilder
        Function BuildHeader() As IProductStockReportBuilder
        Function BuildBody() As IProductStockReportBuilder
        Function BuildFooter() As IProductStockReportBuilder
        Function GetReport() As ProductStockReport
    End Interface
End Namespace