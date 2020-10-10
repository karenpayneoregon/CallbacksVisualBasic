Namespace Classes
    Public Class Account

        Private _warningLevel As Decimal
        Private _balance As Decimal

        Public Event AccountBalanceWarningEvent As AccountBalanceWarningEventHandler
        Public Event AccountDenialEvent As AccountDenyingEventHandler

        Public Property Number As String
        Public Property FirstName As String
        Public Property LastName As String

        Public Sub New()
            _warningLevel = 10
        End Sub

        ''' <summary>
        ''' Warning level is when to send an alert via our delegate
        ''' </summary>
        ''' <param name="warningLevel"></param>
        ''' <remarks></remarks>
        Public Sub New(warningLevel As Decimal)
            _warningLevel = warningLevel
            _insufficientFunds = _balance <= 0
        End Sub
        ''' <summary>
        ''' Current balance of account
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Balance As Decimal
            Get
                Return _balance
            End Get
        End Property
        ''' <summary>
        ''' Deposit money into account
        ''' </summary>
        ''' <param name="amount"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Deposit(amount As Decimal) As Decimal

            _balance += amount

            Console.WriteLine($"Warning level {_warningLevel} balance {_balance}")

            If _balance < _warningLevel Then
                RaiseEvent AccountBalanceWarningEvent(Me, New AccountBalanceWarningEventArgs(Number, _warningLevel, _balance))
            End If

            If _balance - amount < 0 Then
                _insufficientFunds = True
                RaiseEvent AccountDenialEvent(Me, New AccountDenialEventArgs(DenialReasons.InsufficientFunds))
            Else
                _insufficientFunds = False
            End If

            Return _balance

        End Function
        ''' <summary>
        ''' Withdraw from account
        ''' </summary>
        ''' <param name="amount"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Debit(amount As Decimal) As Decimal

            If _balance - amount < 0 Then
                ' Deny withdraw
                _insufficientFunds = True
                RaiseEvent AccountDenialEvent(Me, New AccountDenialEventArgs(DenialReasons.InsufficientFunds))
                Return _balance
            End If

            _balance -= amount

            If _balance < _warningLevel Then
                RaiseEvent AccountBalanceWarningEvent(Me, New AccountBalanceWarningEventArgs(Number, _warningLevel, _balance))
            End If

            Return _balance

        End Function
        Private _insufficientFunds As Boolean
        Public ReadOnly Property InsufficientFunds As Boolean
            Get
                Return _insufficientFunds
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Balance.ToString("c2")
        End Function
    End Class
End Namespace