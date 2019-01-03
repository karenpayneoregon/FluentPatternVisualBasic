Imports BaseLibrary
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim customerReader = New CustomersBuilder

        DataGridView1.DataSource = customerReader.
            Begin().
            OrderBy("LastName").
            DecendingOrder.
            WithoutIdentifiers().
            Read()

    End Sub
End Class
