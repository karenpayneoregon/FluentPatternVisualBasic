

# Fluent Design pattern
This repository provides code samples for writing code using 
fluent desing pattern with VB.NET programming language.

[TechNet article](https://social.technet.microsoft.com/wiki/contents/articles/52583.vb-net-fluent-builder-design-pattern.aspx)


>What exactly constitutes a fluent interface? Fowler describes the way that processes are defined by creating the various objects and then wiring them up together by means of an internal domain-specific language (DSL). The intention is to produce an API that is readable and flows. He suggests using method chaining, with nested functions and object scoping. There are several approaches to implementing this depending on the language that is used. 


#### Advantages of Builder Design Pattern
- The parameters to the constructor are reduced and are provided in highly readable method calls.
- Builder design pattern also helps in minimizing the number of parameters in constructor and thus there is no need to pass in null for optional parameters to the constructor.
- Object is always instantiated in a complete state
- Immutable objects can be build without much complex logic in object building process.

#### Disadvantages of Builder Design Pattern
- The number of lines of code increase at least to double in builder pattern, but the effort pays off in terms of design flexibility and much more readable code.
- Requires creating a separate ConcreteBuilder for each different type of class item.

Example for building a report
```csharp
Namespace ProductBuilderClasses

    Public Class ProductBuilderDemo
        Public Sub New()
            Dim products = New List(Of Product) From {
                    New Product With {.Name = "Monitor", .Price = 200.5},
                    New Product With {.Name = "Mouse", .Price = 20.41},
                    New Product With {.Name = "Keyboard", .Price = 30.15}}

            Dim builder = New ProductStockReportBuilder(products)
            Dim director = New ProductStockReportDirector(builder)
            director.BuildStockReport()

            Dim report = builder.GetReport()
            Console.WriteLine(report)
        End Sub
    End Class
End Namespace
```

Example for updating a SQL-Server record 
```csharp
Dim result = customerReader.
        Begin().
        UpdateContactPhone(contact.Id).
        SetContactPhoneTypeAs(contact.PhoneType).
        WithPhoneNumber(contact.PhoneNumber).
        PhoneStatusIsActive(contact.Active).
        UpdateContactPhoneDetails()
```
 

Example working with a SQL-Server table read operation chain.
```csharp
bindingSourceCustomers.DataSource = customerReader.
    Begin().
    OrderBy("LastName").
    DescendingOrder.
    WithoutIdentifiers().
    ReadAllCustomersRecords()
```
Broken chain
```csharp
Dim customerReader = New CustomersBuilder

customerReader.Begin()
customerReader.OrderBy(columnNamesComboBox.Text)

If decendingOrderCheckBox.Checked Then
    customerReader.DescendingOrder()
Else
    customerReader.AscendingOrder()
End If

bindingSourceCustomers.DataSource = customerReader.ReadAllCustomersRecords()
```

Example sending email
```csharp
Dim mailer As New MailBuilder()

mailer.CreateMail(GmailConfiguration1).
    WithRecipient("karen@comcast.net").
    WithCarbonCopy("mary@gmail.com").
    WithSubject("Test").
    AsRichContent().
    WithHtmlView("<p>Hello <strong>Bob</strong></p>").
    WithPickupFolder().
    WithTimeout(2000).
    SendMessage()
```


---

### Requires
- Microsoft [Visual Studio](https://visualstudio.microsoft.com/) 2017 or higher
- Microsoft [SQL-Server](https://www.microsoft.com/en-us/sql-server/sql-server-2017?&OCID=AID739534_SEM_fkhHI4O5&MarinID=sfkhHI4O5_258104145762_sql%20server_e_c__57166984510_aud-397602258452:kwd-14998960_) 2012 or higher

### Build steps

Run the following data scripts against your SQL-Server.
- [emailDatabase.sql](https://github.com/karenpayneoregon/FluentPatternVisualBasic/blob/master/emailDatabase.sql) 
- [NorthWindParialScrript.sql](https://github.com/karenpayneoregon/FluentPatternVisualBasic/blob/master/NorthWindPartialScript.sql) 
- [CreateDatabaseTablesAndPopulate.sql](https://github.com/karenpayneoregon/FluentPatternVisualBasic/blob/master/NonMailBuilderExamples/CreateDatabaseTablesAndPopulate.sql) 

