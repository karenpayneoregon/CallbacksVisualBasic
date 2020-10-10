Imports AccountsLib
Imports AccountsLib.Classes

Module ExtensionMethods
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DepositToCurrentAccount(ByVal sender As BindingSource, ByVal Value As Decimal)
        If Not sender.Current Is Nothing Then
            CType(sender.Current, Account).Deposit(Value)
            sender.ResetCurrentItem()
        End If
    End Sub
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DebtToCurrentAccount(ByVal sender As BindingSource, ByVal Value As Decimal)
        If Not sender.Current Is Nothing Then
            CType(sender.Current, Account).Debit(Value)
            sender.ResetCurrentItem()
        End If
    End Sub
End Module
