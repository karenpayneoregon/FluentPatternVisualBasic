Imports BaseLibrary.Builders

Namespace BaseClasses
    Public Class Burger
        Public ReadOnly Property Size() As Integer
        Public ReadOnly Property Cheese() As Boolean
        Public ReadOnly Property Pepperoni() As Boolean
        Public ReadOnly Property Lettuce() As Boolean
        Public ReadOnly Property Tomato() As Boolean

        Public Sub New(builder As BurgerBuilder)
            Size = builder.Size
            Cheese = builder.Cheese
            Pepperoni = builder.Pepperoni
            Lettuce = builder.Lettuce
            Tomato = builder.Tomato
        End Sub
    End Class
End Namespace