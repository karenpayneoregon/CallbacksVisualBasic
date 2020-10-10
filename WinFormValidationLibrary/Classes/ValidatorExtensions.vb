Option Infer On

Imports System.ComponentModel.DataAnnotations
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic
Imports WinFormValidationLibrary.LanguageExtensions
Imports WinFormValidationLibrary.Validators

Namespace Classes
    Public Module ValidatorExtensions
        ''' <summary>
        ''' Remove extra whitespace
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <System.Runtime.CompilerServices.Extension>
        Public Function SanitizedErrorMessage(ByVal sender As ValidationResult) As String
            Return Regex.Replace(sender.ErrorMessage.SplitCamelCase(), " {2,}", " ")
        End Function
        ''' <summary>
        ''' Combine error validation text for display, in this case a MessageBox.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns>Current validation issue</returns>
        <System.Runtime.CompilerServices.Extension>
        Public Function ErrorMessageList(ByVal sender As EntityValidationResult) As String

            Dim sb = New StringBuilder()
            sb.AppendLine("Validation issues" & vbLf)

            For Each errorItem In sender.Errors
                sb.AppendLine(errorItem.SanitizedErrorMessage() & vbLf)
            Next errorItem

            Return sb.ToString()

        End Function

    End Module
End Namespace
