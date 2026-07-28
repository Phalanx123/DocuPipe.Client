using System.Text.Json;
using System.Text.Json.Serialization;
using DocuPipe.Clients.Document.Models;

namespace DocuPipe.Clients.Workflow.Models;

/// <summary>
/// Request payload for /v2/workflow/{workflow_id}/run.
/// </summary>
public sealed class RunWorkflowRequest
{
    [JsonPropertyName("document")]
    public required DocumentWrapper Document { get; init; }

    [JsonPropertyName("dataset")] public string? Dataset { get; set; }

    [JsonPropertyName("metadata")] public JsonElement? Metadata { get; set; }
}

/// <summary>
/// Response payload for /v2/workflow/{workflow_id}/run.
/// </summary>
public sealed class RunWorkflowResponse
{
    [JsonPropertyName("documentId")]
    public required string DocumentId { get; set; }

    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("workflowId")]
    public string? WorkflowId { get; set; }

    [JsonPropertyName("workflowResponse")]
    public WorkflowResponse? WorkflowResponse { get; set; }
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
