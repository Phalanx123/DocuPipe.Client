using DocuPipe.Clients.Standardization.Models;

namespace DocuPipe.Clients.Standardization;

public interface IStandardizationClient
{
    Task<StandardizeResponseBase?> CreateBatchAsync(StandardizeBatchRequestBase request,
        CancellationToken cancellationToken = default);

    Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(string standardizationId, CancellationToken cancellationToken = default);
}
