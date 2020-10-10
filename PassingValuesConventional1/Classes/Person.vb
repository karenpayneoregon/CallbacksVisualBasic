Imports System.ComponentModel.DataAnnotations
Imports WinFormValidationLibrary.Classes

Namespace Classes
    Public Class Person

        Public Property Id() As Integer
        <Required(ErrorMessage:="{0} is required"), DataType(DataType.Text)>
        <StringLength(20, MinimumLength:=3)>
        Public Property FirstName() As String
        <Required(ErrorMessage:="{0} is required"), DataType(DataType.Text)>
        <StringLength(20, MinimumLength:=5)>
        Public Property LastName() As String
        <BirthDate(ErrorMessage:="Invalid date"), DataType(DataType.Date)>
        Public Property BirthDay() As Date

        Public Overrides Function ToString() As String
            Return $"{FirstName} {LastName}"
        End Function
        ''' <summary>
        ''' Provides the ability to clone an instance of this class
        ''' </summary>
        ''' <returns></returns>
        Public Function Clone() As Person
            Return DirectCast(MemberwiseClone(), Person)
        End Function
    End Class
End Namespace