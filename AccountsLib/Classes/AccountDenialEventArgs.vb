Namespace Classes
    Public Class AccountDenialEventArgs
        Inherits EventArgs
        Private mReason As DenialReasons
        Public Sub New(Reason As DenialReasons)
            mReason = Reason
        End Sub
        Public ReadOnly Property Reason As DenialReasons
            Get
                Return mReason
            End Get
        End Property
    End Class
End NameSpace