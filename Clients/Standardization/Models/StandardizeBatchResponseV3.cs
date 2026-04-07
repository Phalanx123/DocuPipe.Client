using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Standardization.Models;

public sealed class StandardizeResponseV3 : StandardizeResponseBase
{
    [JsonPropertyName("standardizationId")]
    public required string StandardizationId { get; init; }

    [JsonPropertyName("documentId")]
    public required string DocumentId { get; init; }
}