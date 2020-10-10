# Progress(Of T) Asynchronous

Last of three code samples for [Progress(Of T)](https://docs.microsoft.com/en-us/dotnet/api/system.progress-1?view=netframework-4.8) provides [IProgress(Of T) Interface](https://docs.microsoft.com/en-us/dotnet/api/system.iprogress-1?view=netframework-4.8) a way to invoke callbacks for each reported progress which in the wild allows an operation such as downloading files from the web or reading a delimited file from disk in a form or a class called from a form to report current progress. For example, when reading a file report the current line of total lines in a label rather than a progressbar.

---

In this example a class is used for reporting, similar to example 1. The same cancellation method is used as in example 2. The main difference this time is that the worker method resides outside a form in a class.
