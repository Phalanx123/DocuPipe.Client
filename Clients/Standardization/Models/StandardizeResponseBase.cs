using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Standardization.Models;

public class StandardizeResponseBase
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("pageCount")]
    public int PageCount { get; init; }
}