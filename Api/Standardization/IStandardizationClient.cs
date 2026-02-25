using DocuPipe.Client.Api.Standardization.Models;

namespace DocuPipe.Client.Api.Standardization;

public interface IStandardizationClient
{
    Task<StandardizeBatchResponse> CreateBatchAsync(StandardizeBatchRequest request, CancellationToken cancellationToken = default);

    Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(string standardizationId, CancellationToken cancellationToken = default);
}
