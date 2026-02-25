using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Client.Standardization.Models;

/// <summary>
/// Request payload for /v2/standardize/batch.
/// </summary>
public sealed class StandardizeBatchRequest
{
    [JsonPropertyName("documents")]
    public List<StandardizeDocumentRequest> Documents { get; set; } = [];

    [JsonPropertyName("schemaId")]
    public string? SchemaId { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("dataset")]
    public string? Dataset { get; set; }

    [JsonPropertyName("displayMode")]
    public string? DisplayMode { get; set; }

    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}

/// <summary>
/// A document entry to standardize in the batch request.
/// </summary>
public sealed class StandardizeDocumentRequest
{
    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("base64")]
    public string? Base64 { get; set; }

    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}

/// <summary>
/// Response payload for /v2/standardize/batch.
/// </summary>
public sealed class StandardizeBatchResponse
{
    [JsonPropertyName("batchId")]
    public string? BatchId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("standardizations")]
    public List<StandardizeBatchItemResponse> Standardizations { get; set; } = [];

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}

/// <summary>
/// Item response for each document submitted in the standardization batch.
/// </summary>
public sealed class StandardizeBatchItemResponse
{
    [JsonPropertyName("standardizationId")]
    public string? StandardizationId { get; set; }

    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}

/// <summary>
/// Response payload for /standardization/{standardization_id}.
/// </summary>
/// <typeparam name="TData">Type used to deserialize the standardization data object.</typeparam>
public sealed class StandardizationDetailsResponse<TData>
{
    [JsonPropertyName("standardizationId")]
    public string StandardizationId { get; set; } = string.Empty;

    [JsonPropertyName("documentId")]
    public string DocumentId { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public TData? Data { get; set; }

    [JsonPropertyName("schemaId")]
    public string? SchemaId { get; set; }

    [JsonPropertyName("schemaName")]
    public string? SchemaName { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("dataset")]
    public string? Dataset { get; set; }

    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    [JsonPropertyName("displayMode")]
    public string? DisplayMode { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}
