

# Fluent Design pattern
This repository provides code samples for writing code using fluent desing pattern with VB.NET programming language.



>What exactly constitutes a fluent interface? Fowler describes the way that processes are defined by creating the various objects and then wiring them up together by means of an internal domain-specific language (DSL). The intention is to produce an API that is readable and flows. He suggests using method chaining, with nested functions and object scoping. There are several approaches to implementing this depending on the language that is used. 

Example working with a SQL-Server table read operation
```vb
bindingSourceCustomers.DataSource = customerReader.
    Begin().
    OrderBy("LastName").
    DescendingOrder.
    WithoutIdentifiers().
    ReadAllCustomersRecords()
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
**NOTE**
<p style='background-color:lightyellow;padding:15px;text-align: center;'>This repository is a work in progress, current code may change and new code samples will be added over time.</p>



