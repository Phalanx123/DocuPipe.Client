namespace DocuPipe.Clients.Schema;

/// <summary>
/// Placeholder for schema-specific endpoints.
/// </summary>
public sealed class SchemaClient(HttpClient httpClient) : ISchemaClient
{
    internal HttpClient HttpClient { get; } = httpClient;
}
