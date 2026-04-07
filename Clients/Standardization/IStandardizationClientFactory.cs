using DocuPipe.Clients.Standardization.Models;

namespace DocuPipe.Clients.Standardization;

public interface IStandardizationClientFactory
{
    IStandardizationClient GetClient(DocuPipeApiVersion version);

}