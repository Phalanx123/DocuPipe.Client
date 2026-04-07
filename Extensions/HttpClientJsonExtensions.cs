using System.Net.Http.Json;
using System.Text.Json;
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
        var json = JsonSerializer.SerializeToDocument(value, value!.GetType(), DocuPipeJsonSerializerOptions.Default);
        return httpClient.PostAsJsonAsync(requestUri, json, DocuPipeJsonSerializerOptions.Default, cancellationToken);
    }
}
