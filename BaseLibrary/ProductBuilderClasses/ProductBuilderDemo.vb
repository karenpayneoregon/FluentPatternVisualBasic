Namespace ProductBuilderClasses

    Public Class ProductBuilderDemo
        Public Sub New()
            Dim products = New List(Of Product) From
                    {
                        New Product With {.Name = "Monitor", .Price = 200.5},
                        New Product With {.Name = "Mouse", .Price = 20.41},
                        New Product With {.Name = "Keyboard", .Price = 30.15}
                    }

            Dim builder = New ProductStockReportBuilder(products)
            Dim director = New ProductStockReportDirector(builder)
            director.BuildStockReport()

            Dim report = builder.GetReport()
            Console.WriteLine(report)
        End Sub
    End Class
End Namespace