using DocuPipe.Clients.Standardization.Models;
using DocuPipe.Clients.Standardization.Models.Request;
using DocuPipe.Clients.Standardization.Models.Response;

namespace DocuPipe.Clients.Standardization;

public interface IStandardizationClient
{
    Task<StandardizeResponseBase?> CreateBatchAsync(StandardizeRequestBase request,
        CancellationToken cancellationToken = default);

    Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(string standardizationId, CancellationToken cancellationToken = default);
}
