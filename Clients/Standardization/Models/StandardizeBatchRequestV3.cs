using System.Text.Json;
using System.Text.Json.Serialization;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Standardization.Models;

/// <summary>
/// Request payload for /v2/standardize/batch.
/// </summary>
public sealed class StandardizeBatchRequestV3 : StandardizeBatchRequestBase
{
    [JsonPropertyName("documentId")] public required string DocumentId { get; set; }

    [JsonPropertyName("schemaId")] public required string SchemaId { get; set; }
    [JsonPropertyName("useMetadata")] public bool UseMetadata { get; set; } = false;
    [JsonPropertyName("pages")] public int[]? Pages { get; set; }
    [JsonPropertyName("stdVersion")]
    public double StdVersion { get; set; } = 3;

    [JsonPropertyName("effortLevel")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<EffortLevelEnumV3>))]
    public EffortLevelEnumV3 EffortLevel { get; set; } = EffortLevelEnumV3.Standard;
    [JsonPropertyName("timeout")] public int? Timeout { get; set; }
}

public enum EffortLevelEnumV3
{
    Standard,
    High
}