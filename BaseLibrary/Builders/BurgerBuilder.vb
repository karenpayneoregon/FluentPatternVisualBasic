Imports BaseLibrary.BaseClasses

Namespace Builders
    Public Class BurgerBuilder
        Public ReadOnly Property Size() As Integer

        Private mCheese As Boolean
        Public Property Cheese() As Boolean
            Get
                Return mCheese
            End Get
            Private Set(ByVal value As Boolean)
                mCheese = value
            End Set
        End Property
        Private mPepperoni As Boolean
        Public Property Pepperoni() As Boolean
            Get
                Return mPepperoni
            End Get
            Private Set(ByVal value As Boolean)
                mPepperoni = value
            End Set
        End Property
        Private mLettuce As Boolean
        Public Property Lettuce() As Boolean
            Get
                Return mLettuce
            End Get
            Private Set(ByVal value As Boolean)
                mLettuce = value
            End Set
        End Property
        Private mTomato As Boolean
        Public Property Tomato() As Boolean
            Get
                Return mTomato
            End Get
            Private Set(ByVal value As Boolean)
                mTomato = value
            End Set
        End Property

        Public Sub New(ByVal size As Integer)
            Me.Size = size
        End Sub

        Public Function AddPepperoni() As BurgerBuilder
            Pepperoni = True
            Return Me
        End Function

        Public Function AddLettuce() As BurgerBuilder
            Lettuce = True
            Return Me
        End Function

        Public Function AddCheese() As BurgerBuilder
            Cheese = True
            Return Me
        End Function

        Public Function AddTomato() As BurgerBuilder
            Tomato = True
            Return Me
        End Function

        Public Function Build() As Burger
            Return New Burger(Me)
        End Function
    End Class
End Namespace