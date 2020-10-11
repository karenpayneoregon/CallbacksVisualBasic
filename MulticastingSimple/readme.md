# About

This project is a simple example for multicast delegates were the original source is from a Microsoft [code sample](https://docs.microsoft.com/en-us/dotnet/api/system.multicastdelegate?view=netcore-3.1) which has been modified to properly work.

This example defines a class, StringContainer, which includes a collection of strings. One of its members is the CheckAndDisplayDelegate delegate, which is used to display strings stored in a StringContainer object that satisfy particular criteria. The delegate takes a single string as a parameter and returns void (or, in Visual Basic, it's a Sub procedure). It also includes a method, DisplayAllQualified, that has a single parameter, a CheckAndDisplayDelegate delegate. This allows the method to be called and to display a set of strings that are filtered based on the methods that the delegate contains.

The example also defines a utility class, StringExtensions, that has two methods:
- ConsonantStart, which displays strings that begin with a consonant.
- VowelStart, which displays strings that begin with a vowel.


Note that both methods include a single string parameter and return void. In other words, both methods can be assigned to the CheckAndDisplayDelegate delegate.

The Test.Main method is the application entry point. It instantiates a StringContainer object, populates it with strings, and creates two CheckAndDisplayDelegate delegates, conStart and vowelStart, that invoke a single method. It then calls the [Delegate.Combine](https://docs.microsoft.com/en-us/dotnet/api/system.delegate.combine?view=netcore-3.1) method to create the multipleDelegates delegate, which initially contains the ConStart and VowelStart delegates. Note that when the multipleDelegates delegate is invoked, it displays all the strings in the collection in their original order. This is because each letter is passed separately to each delegate, and each letter meets the filtering criteria of only one of the two delegates. Finally, after calls to [Delegate.Remove](https://docs.microsoft.com/en-us/dotnet/api/system.delegate.remove?view=netcore-3.1) and Delegate.Combine, multipleDelegates contains two conStart delegates. When it is invoked, each string in the StringContainer object is displayed twice.