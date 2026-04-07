using DocuPipe.Clients.Standardization.Models;

namespace DocuPipe.Clients.Standardization;
public sealed class StandardizationClientFactory(IHttpClientFactory httpClientFactory)
    : IStandardizationClientFactory
{
    public IStandardizationClient GetClient(DocuPipeApiVersion version) => version switch
    {
        DocuPipeApiVersion.V2 => new StandardizationClient(httpClientFactory.CreateClient("DocuPipe"), DocuPipeApiVersion.V2),
        DocuPipeApiVersion.V3 => new StandardizationClient(httpClientFactory.CreateClient("DocuPipe"), DocuPipeApiVersion.V3),
        _ => throw new ArgumentOutOfRangeException(nameof(version))
    };
}