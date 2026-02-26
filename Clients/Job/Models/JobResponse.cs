using System.Text.Json.Serialization;
using DocuPipe.Clients.Document.Models;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Job.Models;

public class JobResponse
{
    [JsonPropertyName("jobId")] public required string JobId { get; init; }

    [JsonPropertyName("jobType")] public required string JobType { get; init; }
    
    [JsonPropertyName("status")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<DocumentProcessingStatusEnum>))]
    public required DocumentProcessingStatusEnum Status { get; init; }

    [JsonPropertyName("errorMessage")] public string? ErrorMessage { get; init; }

    [JsonPropertyName("standardizationIds")]
    public string[]? StandardizationIds { get; init; }

    [JsonPropertyName("standardizationJobIds")]
    public string[]? StandardizationJobIds { get; init; }

    [JsonPropertyName("schemaId")] public string? SchemaId { get; init; }

    [JsonPropertyName("documentIds")] public string[]? DocumentIds { get; init; }

    [JsonPropertyName("documentCount")] public int? DocumentCount { get; init; }

    [JsonPropertyName("pageCount")] public int? PageCount { get; init; }
}