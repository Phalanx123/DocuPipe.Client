using DocuPipe.Clients.Standardization.Models;
using DocuPipe.Clients.Standardization.Models.Request;
using DocuPipe.Clients.Standardization.Models.Response;

namespace DocuPipe.Clients.Standardization;

public interface IStandardizationClient
{
    Task<StandardizeResponseBase?> CreateBatchAsync(StandardizeRequestBase request,
        CancellationToken cancellationToken = default);

    Task<StandardizationDetailsResponse<TData>> GetStandardizationAsync<TData>(string standardizationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// The standardizations DocuPipe made from one document, as the JSON array it returns
    /// (<c>GET /standardizations?document_id=</c>), with each one's data included.
    /// </summary>
    Task<string> ListForDocumentRawAsync(string documentId, CancellationToken cancellationToken = default);
}
