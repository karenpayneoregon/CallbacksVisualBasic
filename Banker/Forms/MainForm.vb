Imports AccountsLib.Classes
Imports Banker.Modules


Public Class frmMainForm
    WithEvents _accountsBindingSource As New BindingSource
    Private Sub _Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim accounts As List(Of Account) = GetCustomers(Me)

        _accountsBindingSource.DataSource = accounts
        DataGridView1.DataSource = _accountsBindingSource

        DataGridView1.ExpandColumns()

        DataGridView1.Columns("Balance").DefaultCellStyle.Format = "C2"
        DataGridView1.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("Number").ReadOnly = True
        DataGridView1.Columns("InsufficientFunds").HeaderText = "Flag"

        _accountsBindingSource.MoveLast()

        ActiveControl = cmdDebit

        NumericUpDown1.Value = 5

    End Sub
    Private Sub cmdDebit_Click(sender As Object, e As EventArgs) Handles cmdDebit.Click
        _accountsBindingSource.DebtToCurrentAccount(NumericUpDown1.Value)
    End Sub
    Private Sub cmdDeposit_Click(sender As Object, e As EventArgs) Handles cmdDeposit.Click
        _accountsBindingSource.DepositToCurrentAccount(NumericUpDown2.Value)
    End Sub
    Public Sub TheAccount_AccountBalanceWarningEvent(sender As Object, e As AccountBalanceWarningEventArgs)
        DataGridView2.Rows.Add(New Object() {e.AccountNumber, e.Balance})
        DataGridView2.CurrentCell = DataGridView2(0, DataGridView2.Rows.Count - 1)
    End Sub

End Class

