using System.Net.Http.Json;
using DocuPipe.Clients.Standardization.Models;

namespace DocuPipe.Clients.Standardization;

public sealed class StandardizationClient(HttpClient httpClient) : IStandardizationClient
{
    public async Task<StandardizeBatchResponse?> CreateBatchAsync(StandardizeBatchRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var response = await httpClient.PostAsJsonAsync("/v2/standardize/batch", request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<StandardizeBatchResponse>(cancellationToken).ConfigureAwait(false);
        return payload ?? null;
    }

    public async Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(string standardizationId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(standardizationId);

        using var response = await httpClient.GetAsync($"/standardization/{Uri.EscapeDataString(standardizationId)}", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<StandardizationDetailsResponse<TData>>(cancellationToken).ConfigureAwait(false);
        return payload ?? throw new Exception($"Failed to retrieve standardization details for ID: {standardizationId}");
    }
}
