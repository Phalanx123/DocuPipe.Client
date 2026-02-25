namespace DocuPipe.Configuration;

/// <summary>
/// Configuration options for DocuPipe API communication.
/// </summary>
public sealed class DocuPipeClientOptions
{
    /// <summary>
    /// The DocuPipe base URL. Defaults to the production API host.
    /// </summary>
    public string BaseUrl { get; set; } = "https://app.docupipe.ai";

    /// <summary>
    /// API key used for authenticating requests.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Header name used to send the API key.
    /// </summary>
    public string ApiKeyHeaderName { get; set; } = "x-api-key";
}
