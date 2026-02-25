using DocuPipe.Clients.Document.Models;

namespace DocuPipe.Clients.Document;

public interface IDocumentClient
{
    Task<SubmitDocumentResponse> SubmitDocumentAsync(SubmitDocumentRequest request, CancellationToken cancellationToken = default);
}
