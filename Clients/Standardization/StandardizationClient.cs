using System.Net.Http.Json;
using DocuPipe.Client.Standardization.Models;

namespace DocuPipe.Client.Standardization;

public sealed class StandardizationClient(HttpClient httpClient) : IStandardizationClient
{
    public async Task<StandardizeBatchResponse> CreateBatchAsync(StandardizeBatchRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var response = await httpClient.PostAsJsonAsync("/v2/standardize/batch", request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<StandardizeBatchResponse>(cancellationToken).ConfigureAwait(false);
        return payload ?? new StandardizeBatchResponse();
    }

    public async Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(string standardizationId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(standardizationId);

        using var response = await httpClient.GetAsync($"/standardization/{Uri.EscapeDataString(standardizationId)}", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<StandardizationDetailsResponse<TData>>(cancellationToken).ConfigureAwait(false);
        return payload ?? new StandardizationDetailsResponse<TData>();
    }
}
