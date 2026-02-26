using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Document.Models;

/// <summary>
/// Request payload for /document.
/// </summary>
public sealed class SubmitDocumentRequest
{
    [JsonPropertyName("dataset")] public string? Dataset { get; set; }

    [JsonPropertyName("parseVersion")] public ParseVersionEnum? ParseVersion { get; set; }

    [JsonPropertyName("workflowId")] public string? WorkflowId { get; set; }

    [JsonPropertyName("metadata")] public JsonElement? Metadata { get; set; }
    
    [JsonPropertyName("file")]
    public DocuPipeFile? File { get; set; }
}

public sealed class DocuPipeFile
{
    [JsonPropertyName("contents")] 
    public required string Contents { get; set; }
}

public enum ParseVersionEnum
{
    Version1 = 1,
    Version2 = 2,
    Version3 = 3
}

/// <summary>
/// Response payload for /document.
/// </summary>
public record SubmitDocumentResponse
{
    [JsonPropertyName("documentId")]
    public required string DocumentId { get; set; }

    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("workflowResponse")]
    public WorkflowResponse? WorkflowResponse { get; set; }
}
public sealed class WorkflowResponse
{
    [JsonPropertyName("workflowId")]
    public required string WorkflowId { get; set; }

    [JsonPropertyName("standardizeStep")]
    public StandardizeStep? StandardizeStep { get; set; }

    [JsonPropertyName("splitStandardizeStep")]
    public SplitStandardizeStep? SplitStandardizeStep { get; set; }

    [JsonPropertyName("splitClassifyStandardizeStep")]
    public SplitClassifyStandardizeStep? SplitClassifyStandardizeStep { get; set; }

    [JsonPropertyName("standardizeReviewStep")]
    public StandardizeReviewStep? StandardizeReviewStep { get; set; }

    [JsonPropertyName("classifyStandardizeStep")]
    public ClassifyStandardizeStep? ClassifyStandardizeStep { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }
}

public sealed class StandardizeStep
{
    [JsonPropertyName("standardizationIds")]
    public required List<string> StandardizationIds { get; set; }

    [JsonPropertyName("standardizationJobIds")]
    public required List<string> StandardizationJobIds { get; set; }
    
}

public sealed class SplitStandardizeStep
{
    [JsonPropertyName("splitJobId")]
    public required string SplitJobId { get; set; }

    [JsonPropertyName("standardizationJobIdsByDocument")]
    public Dictionary<string, List<string>>? StandardizationJobIdsByDocument { get; set; }

    [JsonPropertyName("standardizationIdsByDocument")]
    public Dictionary<string, List<string>>? StandardizationIdsByDocument { get; set; }
}

public sealed class SplitClassifyStandardizeStep
{
    [JsonPropertyName("splitJobId")]
    public required string SplitJobId { get; set; }

    [JsonPropertyName("classificationJobIdsByDocument")]
    public Dictionary<string, string>? ClassificationJobIdsByDocument { get; set; }

    [JsonPropertyName("classToStandardizationJobIdsByDocument")]
    public Dictionary<string, Dictionary<string, string>>? ClassToStandardizationJobIdsByDocument { get; set; }

    [JsonPropertyName("classToStandardizationIdsByDocument")]
    public Dictionary<string, Dictionary<string, string>>? ClassToStandardizationIdsByDocument { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}

public sealed class StandardizeReviewStep
{
    [JsonPropertyName("standardizationIds")]
    public required List<string> StandardizationIds { get; set; }

    [JsonPropertyName("standardizationJobIds")]
    public required List<string> StandardizationJobIds { get; set; }

    [JsonPropertyName("reviewIds")]
    public required List<string> ReviewIds { get; set; }

    [JsonPropertyName("reviewJobIds")]
    public required List<string> ReviewJobIds { get; set; }
}

public sealed class ClassifyStandardizeStep
{
    [JsonPropertyName("classificationJobId")]
    public required string ClassificationJobId { get; set; }

    [JsonPropertyName("classToStandardizationIds")]
    public required Dictionary<string, JsonElement> ClassToStandardizationIds { get; set; }

    [JsonPropertyName("classToStandardizationJobIds")]
    public required Dictionary<string, JsonElement> ClassToStandardizationJobIds { get; set; }
}