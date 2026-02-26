using System.Text.Json;
using System.Text.Json.Serialization;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Document.Models;

public record ProcessedDocumentResponse
{
    /// <summary>
    /// Unique identifier for the document.
    /// </summary>
    [JsonPropertyName("documentId")]
    public required string DocumentId { get; set; }

    /// <summary>
    /// Dataset the document belongs to.
    /// </summary>
    [JsonPropertyName("dataset")]
    public string? Dataset { get; set; }

    /// <summary>
    /// Indicates whether the document has been classified.
    /// </summary>
    [JsonPropertyName("classified")]
    public bool Classified { get; set; }

    /// <summary>
    /// Classification identifiers, if classification has occurred.
    /// </summary>
    [JsonPropertyName("classIds")]
    public string[]? ClassIds { get; set; }

    /// <summary>
    /// Name of the file.
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// File type (e.g. pdf, image, docx).
    /// </summary>
    [JsonPropertyName("fileType")]
    public string? FileType { get; set; }

    /// <summary>
    /// File extension.
    /// </summary>
    [JsonPropertyName("fileExtension")]
    public string? FileExtension { get; set; }

    /// <summary>
    /// Number of pages in the document.
    /// </summary>
    [JsonPropertyName("numPages")]
    public int? NumPages { get; set; }

    /// <summary>
    /// Detected document language.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// Additional metadata returned by the API.
    /// </summary>
    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; set; }

    /// <summary>
    /// Processing status of the document.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<DocumentProcessingStatusEnum>))]
    public required DocumentProcessingStatusEnum Status { get; set; }

    /// <summary>
    /// Timestamp of the processing event.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required DateTimeOffset Timestamp { get; set; }
}

public enum DocumentProcessingStatusEnum
{
    Processing,
    Completed,
    Error
}