using System.Text.Json;
using System.Text.Json.Serialization;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Standardization.Models;

/// <summary>
/// Request payload for /v2/standardize/batch.
/// </summary>
public sealed class StandardizeBatchRequestBaseV2 : StandardizeBatchRequestBase
{
    [JsonPropertyName("documentIds")] 
    public required List<string> DocumentIds { get; set; }
    

 

    [JsonPropertyName("displayMode")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<DisplayModeEnum>))]
    public DisplayModeEnum DisplayMode { get; set; } = DisplayModeEnum.Auto;

    [JsonPropertyName("effortLevel")] 
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<EffortLevelEnumV2>))]
    public EffortLevelEnumV2 EffortLevel { get; set; } = EffortLevelEnumV2.Standard;
    
    [JsonPropertyName("splitMode")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<SplitModeEnum>))]
    public SplitModeEnum SplitMode { get; set; } = SplitModeEnum.Auto;
    
    
    [JsonPropertyName("useMetadata")]
    public bool UseMetadata { get; set; } = false;

    [JsonPropertyName("stdVersion")]
    public decimal StdVersion { get; set; } = 2.3m;
    
    [JsonPropertyName("schemaId")] 
    public string? SchemaId { get; set; }
    
    [JsonPropertyName("guidelines")] 
    public string? Guidelines { get; set; }
}

public enum DisplayModeEnum
{
    Auto,
    Spatial,
    Sections,
    Image
}

public enum EffortLevelEnumV2
{
    Standard,
    High,
    Extended
}

public enum SplitModeEnum
{
    Auto,
    All,
    Never
}

/// <summary>
/// A document entry to standardize in the batch request.
/// </summary>
public sealed class StandardizeDocumentRequest
{
    [JsonPropertyName("documentId")] public string? DocumentId { get; set; }

    [JsonPropertyName("filename")] public string? Filename { get; set; }

    [JsonPropertyName("text")] public string? Text { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("base64")] public string? Base64 { get; set; }

    [JsonPropertyName("metadata")] public JsonElement? Metadata { get; set; }

    [JsonExtensionData] public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}

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

/// <summary>
/// Response payload for /standardization/{standardization_id}.
/// </summary>
/// <typeparam name="TData">Type used to deserialize the standardization data object.</typeparam>
public sealed class StandardizationDetailsResponse<TData>
{
    [JsonPropertyName("standardizationId")]
    public required string StandardizationId { get; init; }

    [JsonPropertyName("documentId")] public required string DocumentId { get; init; }

    [JsonPropertyName("data")] public required TData Data { get; init; }

    [JsonPropertyName("schemaId")] public string? SchemaId { get; init; }

    [JsonPropertyName("schemaName")] public string? SchemaName { get; init; }

    [JsonPropertyName("jobId")] public string? JobId { get; init; }

    [JsonPropertyName("dataset")] public string? Dataset { get; init; }

    [JsonPropertyName("filename")] public string? Filename { get; init; }

    [JsonPropertyName("displayMode")] public string? DisplayMode { get; init; }

    [JsonPropertyName("timestamp")] public DateTimeOffset Timestamp { get; init; }

    [JsonPropertyName("metadata")] public JsonElement? Metadata { get; init; }
}