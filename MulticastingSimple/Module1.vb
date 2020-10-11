Imports MulticastingSimple.Classes
Imports MulticastingSimple.Helpers

Module Module1

    Sub Main()
        ' Declare the StringContainer class and add some strings
        Dim container As New StringContainer()
        container.AddString("this")
        container.AddString("is")
        container.AddString("a")
        container.AddString("multicast")
        container.AddString("delegate")
        container.AddString("example")

        ' Create two delegates individually using different methods.
        Dim constart As StringContainer.CheckAndPrintDelegate = AddressOf StringHelpers.ConsonantStart
        Dim vowelStart As StringContainer.CheckAndPrintDelegate = AddressOf StringHelpers.VowelStart

        ' Get the list of all delegates assigned to this MulticastDelegate instance. 
        Dim delegateList() As [Delegate] = constart.GetInvocationList()
        Console.WriteLine("conStart contains {0} delegate(s).", delegateList.Length)

        delegateList = vowelStart.GetInvocationList()
        Console.WriteLine("vowelStart contains {0} delegate(s).", delegateList.Length)
        Console.WriteLine()

        ' Determine whether the delegates are System.Multicast delegates
        If TypeOf constart Is MulticastDelegate And TypeOf vowelStart Is MulticastDelegate Then
            Console.WriteLine("conStart and vowelStart are derived from MulticastDelegate.")
            Console.WriteLine()
        End If

        ' Run the two single delegates one after the other.
        Console.WriteLine("Executing the conStart delegate:")
        container.DisplayAllQualified(constart)
        Console.WriteLine("Executing the vowelStart delegate:")
        container.DisplayAllQualified(vowelStart)
        Console.WriteLine()

        ' Create a new MulticastDelegate and call Combine to add two delegates.
        Dim multipleDelegates = CType([Delegate].Combine(constart, vowelStart), StringContainer.CheckAndPrintDelegate)

        ' How many delegates does multipleDelegates contain?
        delegateList = multipleDelegates.GetInvocationList()
        Console.WriteLine("{1}multipleDelegates contains {0} delegates.{1}", delegateList.Length, vbCrLf)

        ' Pass this mulitcast delegate to DisplayAllQualified.
        Console.WriteLine("Executing the multipleDelegate delegate.")
        container.DisplayAllQualified(multipleDelegates)

        ' Call remove and combine to change the contained delegates.
        multipleDelegates = CType([Delegate].Remove(multipleDelegates, vowelStart),
                            StringContainer.CheckAndPrintDelegate)

        multipleDelegates = CType([Delegate].Combine(multipleDelegates, constart),
                            StringContainer.CheckAndPrintDelegate)

        ' Pass multipleDelegates to DisplayAllQualified again.
        Console.WriteLine()
        Console.WriteLine("Executing the multipleDelegate delegate with two conStart delegates:")
        container.DisplayAllQualified(multipleDelegates)

        Console.ReadLine()
    End Sub

End Module
