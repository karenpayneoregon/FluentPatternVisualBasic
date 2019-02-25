Imports BaseLibrary.Builders

Module Module1

    Sub Main()

        Dim burger = (New BurgerBuilder(14)).
                AddPepperoni().
                AddLettuce().
                AddTomato().
                Build()

        Console.ReadLine()
    End Sub

End Module
