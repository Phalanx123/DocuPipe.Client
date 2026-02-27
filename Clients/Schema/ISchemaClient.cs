using DocuPipe.Clients.Schema.Models;

namespace DocuPipe.Clients.Schema;

public interface ISchemaClient
{
    Task<List<SchemaResponse>> GetSchemaListAsync(CancellationToken cancellationToken = default);
}
