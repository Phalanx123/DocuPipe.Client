using System.Text.Json;
using System.Text.Json.Serialization;
using DocuPipe.Clients.Document.Models;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Workflow.Models;

/// <summary>
/// Request payload for /v2/workflow/{workflow_id}/run.
/// </summary>
public sealed class RunWorkflowRequest
{
    [JsonPropertyName("inputs")]
    public required List<RunWorkflowInput> Inputs { get; init; }
}

/// <summary>
/// A single document input to a workflow run.
/// </summary>
public sealed class RunWorkflowInput
{
    /// <summary>
    /// Optional caller-supplied label used to identify this input in the response.
    /// </summary>
    [JsonPropertyName("inputLabel")]
    public string? InputLabel { get; set; }

    [JsonPropertyName("dataset")] public string? Dataset { get; set; }

    [JsonPropertyName("document")]
    public required DocumentWrapper Document { get; init; }

    [JsonPropertyName("metadata")] public JsonElement? Metadata { get; set; }
}

/// <summary>
/// Response payload for /v2/workflow/{workflow_id}/run.
/// </summary>
public sealed class RunWorkflowResponse
{
    [JsonPropertyName("workflowId")]
    public required string WorkflowId { get; set; }

    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<DocumentProcessingStatusEnum>))]
    public required DocumentProcessingStatusEnum Status { get; set; }

    [JsonPropertyName("inputs")]
    public List<RunWorkflowInputResult>? Inputs { get; set; }
}

/// <summary>
/// Per-input result of a workflow run.
/// </summary>
public sealed class RunWorkflowInputResult
{
    [JsonPropertyName("inputLabel")] public string? InputLabel { get; set; }

    [JsonPropertyName("documentId")] public string? DocumentId { get; set; }

    [JsonPropertyName("uploadJobId")] public string? UploadJobId { get; set; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<DocumentProcessingStatusEnum>))]
    public DocumentProcessingStatusEnum Status { get; set; }
}

/// <summary>
/// Summary of a workflow returned by GET /workflows.
/// </summary>
public sealed class WorkflowSummary
{
    [JsonPropertyName("workflowId")]
    public required string WorkflowId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
