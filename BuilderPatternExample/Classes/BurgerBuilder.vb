Namespace Classes

    Public Delegate Sub MonitorHandler(arg As String)

    Public Class BurgerBuilder
        Public Shared Event OnMonitor As MonitorHandler

        Public ReadOnly Property Size() As Integer

        Private _cheese As Boolean
        Public Property Cheese() As Boolean
            Get
                Return _cheese
            End Get
            Private Set
                _cheese = Value
            End Set
        End Property
        Private _pepperoni As Boolean
        Public Property Pepperoni() As Boolean
            Get
                Return _pepperoni
            End Get
            Private Set
                _pepperoni = Value
            End Set
        End Property
        Private _lettuce As Boolean
        Public Property Lettuce() As Boolean
            Get
                Return _lettuce
            End Get
            Private Set
                _lettuce = Value
            End Set
        End Property
        Private _tomato As Boolean
        Public Property Tomato() As Boolean
            Get
                Return _tomato
            End Get
            Private Set
                _tomato = Value
            End Set
        End Property

        Public Sub New(size As Integer)
            Me.Size = size
        End Sub
        Public Function GetSize() As BurgerBuilder
            OnMonitorEvent?.Invoke($"Size {Size}")
            Return Me
        End Function
        Public Function AddPepperoni() As BurgerBuilder
            OnMonitorEvent?.Invoke("Added Pepperoni")

            Pepperoni = True
            Return Me

        End Function

        Public Function AddLettuce() As BurgerBuilder

            OnMonitorEvent?.Invoke("Added Lettuce")

            Lettuce = True

            Return Me

        End Function

        Public Function AddCheese() As BurgerBuilder
            OnMonitorEvent?.Invoke("Added Cheese")

            Cheese = True

            Return Me

        End Function

        Public Function AddTomato() As BurgerBuilder
            OnMonitorEvent?.Invoke("Added Tomato")

            Tomato = True

            Return Me

        End Function

        Public Function Build() As Burger
            Return New Burger(Me)
        End Function
    End Class
End Namespace