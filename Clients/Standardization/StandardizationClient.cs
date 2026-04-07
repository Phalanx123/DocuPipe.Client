using System.Net.Http.Json;
using System.Text.Json;
using DocuPipe.Clients.Standardization.Models;
using DocuPipe.Extensions;
using DocuPipe.Serialization;

namespace DocuPipe.Clients.Standardization;

public sealed class StandardizationClient(HttpClient httpClient, DocuPipeApiVersion apiVersion = DocuPipeApiVersion.V2)
    : IStandardizationClient
{
    private readonly string _versionSegment = apiVersion switch
    {
        DocuPipeApiVersion.V2 => "v2",
        DocuPipeApiVersion.V3 => "v3",
        _ => throw new ArgumentOutOfRangeException(nameof(apiVersion))
    };
    
    private readonly string _batchEndpoint = apiVersion switch
    {
        DocuPipeApiVersion.V2 => "v2/standardize/batch",
        DocuPipeApiVersion.V3 => "v3/standardize",
        _ => throw new ArgumentOutOfRangeException(nameof(apiVersion))
    };

    public async Task<StandardizeResponseBase?> CreateBatchAsync(StandardizeBatchRequestBase request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        using var response = await httpClient
            .PostAsDocuPipeJsonAsync($"/{_batchEndpoint}", request, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return apiVersion switch
        {
            DocuPipeApiVersion.V2 => await response.Content
                .ReadFromJsonAsync<StandardizeResponseV2>(cancellationToken)
                .ConfigureAwait(false),
            DocuPipeApiVersion.V3 => await response.Content
                .ReadFromJsonAsync<StandardizeResponseV3>(cancellationToken)
                .ConfigureAwait(false),
            _ => throw new ArgumentOutOfRangeException(nameof(apiVersion))
        };
    }

    public async Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(
        string standardizationId,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(standardizationId);

        using var response = await httpClient
            .GetAsync($"/standardization/{Uri.EscapeDataString(standardizationId)}", cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content
                   .ReadFromJsonAsync<StandardizationDetailsResponse<TData>>(cancellationToken)
                   .ConfigureAwait(false)
               ?? throw new InvalidOperationException($"Failed to deserialize standardization details for ID: {standardizationId}");
    }
}