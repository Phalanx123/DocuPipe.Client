using System.Net.Http.Json;
using DocuPipe.Clients.Job.Models;
using DocuPipe.Clients.Schema.Models;

namespace DocuPipe.Clients.Schema;

/// <summary>
/// Placeholder for schema-specific endpoints.
/// </summary>
public sealed class SchemaClient(HttpClient httpClient) : ISchemaClient
{
    internal HttpClient HttpClient { get; } = httpClient;
   
    public async Task<List<SchemaResponse>> GetSchemaListAsync(CancellationToken cancellationToken = default)
    {

        using var response = await HttpClient.GetAsync($"/schemas", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<List<SchemaResponse>>(cancellationToken).ConfigureAwait(false);
        return payload ?? [];
    }
}
