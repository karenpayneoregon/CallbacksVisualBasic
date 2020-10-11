Imports AccountsLib
Imports AccountsLib.Classes

Namespace Modules

    Module LoadMockData
        Public Function GetCustomers(sender As frmMainForm) As List(Of Account)

            Dim accounts As New List(Of Account) From
                    {
                        New Account With {.Number = "A100", .FirstName = "Kevin", .LastName = "Gallager"},
                        New Account With {.Number = "A200", .FirstName = "Jane", .LastName = "Doe"},
                        New Account With {.Number = "A300", .FirstName = "Bill", .LastName = "Smith"}
                    }


            Dim test = (From this In accounts Where this.Number = "A200").First

            test.Deposit(100)

            test = (From this In accounts Where this.Number = "A100").First
            test.Deposit(150)

            test = (From this In accounts Where this.Number = "A300").First
            test.Deposit(50)

            For Each Account In accounts
                AddHandler Account.AccountBalanceWarningEvent, AddressOf sender.TheAccount_AccountBalanceWarningEvent
            Next

            Return accounts

        End Function

    End Module
End Namespace