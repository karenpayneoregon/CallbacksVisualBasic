Imports AccountsLib.Classes

Namespace Modules

    Module ExtensionMethods
        <DebuggerHidden()>
        <Runtime.CompilerServices.Extension()>
        Public Sub ExpandColumns(sender As DataGridView)
            For Each col As DataGridViewColumn In sender.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End Sub
        <DebuggerHidden()>
        <Runtime.CompilerServices.Extension()>
        Public Sub DepositToCurrentAccount(sender As BindingSource, value As Decimal)
            If Not sender.Current Is Nothing Then
                CType(sender.Current, Account).Deposit(value)
                sender.ResetCurrentItem()
            End If
        End Sub
        <DebuggerHidden()>
        <Runtime.CompilerServices.Extension()>
        Public Sub DebtToCurrentAccount(sender As BindingSource, value As Decimal)
            If Not sender.Current Is Nothing Then
                CType(sender.Current, Account).Debit(value)
                sender.ResetCurrentItem()
            End If
        End Sub
    End Module
End Namespace