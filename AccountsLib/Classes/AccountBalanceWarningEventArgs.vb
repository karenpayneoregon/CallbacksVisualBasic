Namespace Classes
    Public Class AccountBalanceWarningEventArgs
        Inherits EventArgs

        Private _level As Decimal
        Private _current As Decimal
        Private _accountNumber As String

        Public Sub New(number As String, warningLevel As Decimal, currentBalance As Decimal)

            _level = warningLevel
            _current = currentBalance
            _accountNumber = number

        End Sub
        Public ReadOnly Property AccountNumber As String
            Get
                Return _accountNumber
            End Get
        End Property
        Public ReadOnly Property WarningLevel() As Decimal
            Get
                Return _level
            End Get
        End Property
        Public ReadOnly Property Balance() As Decimal
            Get
                Return _current
            End Get
        End Property
    End Class
End NameSpace