using DocuPipe.Client.Document.Models;

namespace DocuPipe.Client.Document;

public interface IDocumentClient
{
    Task<SubmitDocumentResponse> SubmitDocumentAsync(SubmitDocumentRequest request, CancellationToken cancellationToken = default);
}
