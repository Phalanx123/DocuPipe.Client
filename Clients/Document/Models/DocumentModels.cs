using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Document.Models;

/// <summary>
/// Request payload for /document.
/// </summary>
public sealed class SubmitDocumentRequest
{
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
/// Response payload for /document.
/// </summary>
public sealed class SubmitDocumentResponse
{
    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalData { get; set; } = new();
}
