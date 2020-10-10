# Progress(Of T) Asynchronous

First of three code samples for [Progress(Of T)](https://docs.microsoft.com/en-us/dotnet/api/system.progress-1?view=netframework-4.8) provides [IProgress(Of T) Interface](https://docs.microsoft.com/en-us/dotnet/api/system.iprogress-1?view=netframework-4.8) a way to invoke callbacks for each reported progress which in the wild allows an operation such as downloading files from the web or reading a delimited file from disk in a form or a class called from a form to report current progress. For example, when reading a file report the current line of total lines in a label rather than a progressbar.

---

Starting off simple by executing a Do While statement Jump 10,000 times, within the Do While construct a callback of type [TaskProgressReport](https://github.com/karenpayneoregon/CallbacksVisualBasic/blob/master/Progress1/Classes/TaskProgressReport.vb), pass the current index, total (10,000) and a string message.
