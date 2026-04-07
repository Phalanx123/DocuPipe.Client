using System.Text.Json.Serialization;
using DocuPipe.Clients.Standardization.Models.Response;

namespace DocuPipe.Clients.Standardization.Models;

/// <summary>
/// Response payload for /v2/standardize/batch.
/// </summary>
public sealed class StandardizeResponseV2 : StandardizeResponseBase
{
    [JsonPropertyName("timestamp")]
    public required DateTimeOffset Timestamp { get; init; }

    [JsonPropertyName("documentCount")]
    public required int DocumentCount { get; init; }

    [JsonPropertyName("standardizationJobIds")]
    public string[]? StandardizationJobIds { get; init; }

    [JsonPropertyName("standardizationIds")]
    public string[]? StandardizationIds { get; init; }

    [JsonPropertyName("details")]
    public string? Details { get; init; }
}