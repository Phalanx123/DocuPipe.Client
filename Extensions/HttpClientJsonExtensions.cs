using System.Net.Http.Json;
using DocuPipe.Serialization;

namespace DocuPipe.Extensions;

internal static class HttpClientJsonExtensions
{
    internal static Task<HttpResponseMessage> PostAsDocuPipeJsonAsync<TValue>(
        this HttpClient httpClient,
        string? requestUri,
        TValue value,
        CancellationToken cancellationToken = default)
    {
        return httpClient.PostAsJsonAsync(requestUri, value, DocuPipeJsonSerializerOptions.Default, cancellationToken);
    }
}
