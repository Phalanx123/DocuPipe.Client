namespace DocuPipe.Client.Api.Document;

/// <summary>
/// Placeholder for document-specific endpoints.
/// </summary>
public sealed class DocumentClient(HttpClient httpClient) : IDocumentClient
{
    internal HttpClient HttpClient { get; } = httpClient;
}
