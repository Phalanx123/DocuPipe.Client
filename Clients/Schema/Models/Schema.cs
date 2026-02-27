using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Schema.Models;

/// <summary>
/// Represents a schema definition returned from the API.
/// </summary>
public sealed record SchemaResponse
{
    /// <summary>
    /// Unique identifier of the schema.
    /// </summary>
    [JsonPropertyName("schemaId")]
    public required string SchemaId { get; init; }

    /// <summary>
    /// Friendly name of the schema.
    /// </summary>
    [JsonPropertyName("schemaName")]
    public required string SchemaName { get; init; }

    /// <summary>
    /// JSON schema definition. May be null.
    /// </summary>
    [JsonPropertyName("jsonSchema")]
    public JsonElement? JsonSchema { get; init; }

    /// <summary>
    /// Optional guidelines associated with the schema.
    /// </summary>
    [JsonPropertyName("guidelines")]
    public string? Guidelines { get; init; }

    /// <summary>
    /// Optional job ID associated with the schema.
    /// </summary>
    [JsonPropertyName("jobId")]
    public string? JobId { get; init; }

    /// <summary>
    /// Timestamp when the schema was created or updated.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; init; }
}