# MicrosoftTextAnalytics.Api.Net

This is API wrapper for the Microsoft Text Analytics server.

You can see the specification on: https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics.V2.0/operations/56f30ceeeda5650db055a3c7

Here is a quick sample how to use it:

```
var endpoint = "";
var apiKey = "{Your api key here}";

var manager = new TextAnalyticsApiManager(string endpoint, string apiKey);

var documentList = new List<DocumentInput>();
documentList.Add(new DocumentInput {
   Id = 1,
   Language = "en",
   Text = "{Your text here}"
});

var result = await manager.GetLanguages(documentList);
```

It currently impements all methods available in the API 2.0.
