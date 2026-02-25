# DocuPipe.Client

## Configuration

```json
{
  "DocuPipe": {
    "BaseUrl": "https://app.docupipe.ai",
    "ApiKey": "your-api-key",
    "ApiKeyHeaderName": "x-api-key"
  }
}
```

## Service registration

```csharp
services.AddDocuPipeClient(configuration);
```

## Submit a document

```csharp
using DocuPipe.Client.Document.Models;

var submitRequest = new SubmitDocumentRequest
{
    Filename = "BinderPart-16.pdf",
    Url = "https://example.com/BinderPart-16.pdf"
};

var document = await documentClient.SubmitDocumentAsync(submitRequest, cancellationToken);
var documentId = document.DocumentId;
```

## Standardization example

```csharp
using System.Text.Json;
using DocuPipe.Client.Standardization.Models;

var request = new StandardizeBatchRequest
{
    SchemaId = "G166BStg",
    Dataset = "unassigned",
    Documents =
    [
        new StandardizeDocumentRequest
        {
            DocumentId = "5N5Z0L3z",
            Filename = "BinderPart-16",
            Text = "Document content to standardize"
        }
    ]
};

var batchResponse = await standardizationClient.CreateBatchAsync(request, cancellationToken);
var standardizationId = batchResponse.Standardizations.FirstOrDefault()?.StandardizationId;

if (!string.IsNullOrWhiteSpace(standardizationId))
{
    var result = await standardizationClient
        .GetStandardizationAsync<Dictionary<string, string?>>(standardizationId, cancellationToken);

    var grade = result.Data?["Grade"];
}
```
