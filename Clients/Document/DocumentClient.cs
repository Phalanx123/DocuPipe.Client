using System.Net.Http.Json;
using DocuPipe.Client.Document.Models;

namespace DocuPipe.Client.Document;

public sealed class DocumentClient(HttpClient httpClient) : IDocumentClient
{
    public async Task<SubmitDocumentResponse> SubmitDocumentAsync(SubmitDocumentRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var response = await httpClient.PostAsJsonAsync("/document", request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<SubmitDocumentResponse>(cancellationToken).ConfigureAwait(false);
        return payload ?? new SubmitDocumentResponse();
    }
}
