Namespace Helpers
    Class StringHelpers
        ' Display a string if it starts with a consonant. 
        Public Shared Sub ConsonantStart(item As String)

            If Not (item.Chars(0) = "a"c Or item.Chars(0) = "e"c Or item.Chars(0) = "i"c Or item.Chars(0) = "o"c Or item.Chars(0) = "u"c) Then
                Console.WriteLine(item)
            End If
        End Sub

        ' Display a string if it starts with a vowel.
        Public Shared Sub VowelStart(item As String)

            If (item.Chars(0) = "a"c Or item.Chars(0) = "e"c Or item.Chars(0) = "i"c Or item.Chars(0) = "o"c Or item.Chars(0) = "u"c) Then
                Console.WriteLine(item)
            End If

        End Sub

    End Class
End Namespace