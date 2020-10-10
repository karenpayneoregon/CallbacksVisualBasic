Imports AccountsLib
Imports AccountsLib.Classes


Public Class frmMainForm
    WithEvents bsAccounts As New BindingSource
    WithEvents SingleAccount As New Account

    Private Sub _Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Accounts As List(Of Account) = GetCustomers(Me)

        bsAccounts.DataSource = Accounts
        DataGridView1.DataSource = bsAccounts
        DataGridView1.ExpandColumns()
        DataGridView1.Columns("Balance").DefaultCellStyle.Format = "C2"
        DataGridView1.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("Number").ReadOnly = True
        DataGridView1.Columns("InsufficientFunds").HeaderText = "Flag"

        bsAccounts.MoveLast()

        ActiveControl = cmdDebit

        NumericUpDown1.Value = 5

    End Sub
    Private Sub cmdDebit_Click(sender As Object, e As EventArgs) Handles cmdDebit.Click
        bsAccounts.DebtToCurrentAccount(NumericUpDown1.Value)
    End Sub
    Private Sub cmdDeposit_Click(sender As Object, e As EventArgs) Handles cmdDeposit.Click
        bsAccounts.DepositToCurrentAccount(NumericUpDown2.Value)
    End Sub
    Public Sub TheAccount_AccountBalanceWarningEvent(sender As Object, e As AccountBalanceWarningEventArgs)
        DataGridView2.Rows.Add(New Object() {e.AccountNumber, e.Balance})
        DataGridView2.CurrentCell = DataGridView2(0, DataGridView2.Rows.Count - 1)
    End Sub

    'Private Sub SingleAccount_AccountBalanceWarningEvent(sender As Object, e As AccountBalanceWarningEventArgs) Handles SingleAccount.AccountBalanceWarningEvent
    '    DataGridView2.Rows.Add(New Object() {e.AccountNumber, e.Balance})
    '    DataGridView2.CurrentCell = DataGridView2(0, DataGridView2.Rows.Count - 1)
    'End Sub

    'Private Sub MonitoredItemNotificationEventHandler(monitoredItem As MonitoredItem, e As MonitoredItemNotificationEventArgs)
    '    Console.WriteLine()
    'End Sub
End Class

Public Class MonitoredItem
End Class
Public Class MonitoredItemNotificationEventArgs

End Class