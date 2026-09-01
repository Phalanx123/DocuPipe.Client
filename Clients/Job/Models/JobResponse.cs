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

    /// <summary>
    /// Typed results for a workflow-run job (see POST /v2/workflow/{workflow_id}/run). Absent for
    /// other job types, which report results via <see cref="DocumentIds"/>/<see cref="StandardizationIds"/> instead.
    /// </summary>
    [JsonPropertyName("outputs")] public List<JobOutput>? Outputs { get; init; }
}

public class JobOutput
{
    [JsonPropertyName("outputType")] public string? OutputType { get; init; }

    [JsonPropertyName("extraction")] public JobExtractionOutput? Extraction { get; init; }

    [JsonPropertyName("redaction")] public JobRedactionOutput? Redaction { get; init; }
}

public class JobExtractionOutput
{
    [JsonPropertyName("items")] public List<JobExtractionItem>? Items { get; init; }
}

public class JobExtractionItem
{
    [JsonPropertyName("documentId")] public string? DocumentId { get; init; }

    [JsonPropertyName("standardizationId")] public string? StandardizationId { get; init; }
}

public class JobRedactionOutput
{
    [JsonPropertyName("items")] public List<JobRedactionItem>? Items { get; init; }
}

public class JobRedactionItem
{
    [JsonPropertyName("redactionId")] public string? RedactionId { get; init; }

    [JsonPropertyName("downloadUrl")] public string? DownloadUrl { get; init; }
}