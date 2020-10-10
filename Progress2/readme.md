# Progress(Of T) Asynchronous

Second of three code samples for [Progress(Of T)](https://docs.microsoft.com/en-us/dotnet/api/system.progress-1?view=netframework-4.8) provides [IProgress(Of T) Interface](https://docs.microsoft.com/en-us/dotnet/api/system.iprogress-1?view=netframework-4.8) a way to invoke callbacks for each reported progress which in the wild allows an operation such as downloading files from the web or reading a delimited file from disk in a form or a class called from a form to report current progress. For example, when reading a file report the current line of total lines in a label rather than a progressbar.

---

Going with cancellation keeping the operation in the form, the third example will move away from the form to a class. Rather than using a class for the callback this example uses a Integer. The key to cancel option is [CancellationTokenSource](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtokensource?view=netframework-4.8). A CancellationTokenSource object is setup a form level scope as a private variable. The [Token](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtokensource.token?view=netframework-4.8) of the CancellationTokenSource is passed to a callback which is the worker of the operation, in this case a do-nothing method.

In the worker method an assertion is done to see if the CancellationTokenSource.[IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtokensource.iscancellationrequested?view=netframework-4.8) is true (meaning a cancel to request has been issued) then invoke [ThrowIfCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.throwifcancellationrequested?view=netframework-4.8) of the CancellationTokenSource object which will throw an exception which means the call to the worker method must be in a Try-Catch statement. In this example the only exception watched is OperationCanceledException Jump but for an application in production there should also be a second catch for general exceptions as the last catch. To cancel the operation Cancel method is invoked on the CancellationTokenSource object.

> Important: To reuse the CancellationTokenSource object to restart the object must first be disposed then recreated.


