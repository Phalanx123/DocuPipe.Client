using System.Net.Http.Json;
using DocuPipe.Clients.Document.Models;

namespace DocuPipe.Clients.Document;

public sealed class DocumentClient(HttpClient httpClient) : IDocumentClient
{
    public async Task<SubmitDocumentResponse?> SubmitDocumentAsync(SubmitDocumentRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var response = await httpClient.PostAsJsonAsync("/document", request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<SubmitDocumentResponse>(cancellationToken).ConfigureAwait(false);
        return payload ?? null;
    }

    public async Task<ProcessedDocumentResponse?> RetrieveProcessedDocumentAsync(string documentId, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(documentId);
        using var response = await httpClient.GetAsync($"/document/{documentId}", ct).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<ProcessedDocumentResponse>(ct).ConfigureAwait(false);
        return payload ?? null;
    }
}
