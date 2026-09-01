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

    /// <summary>
    /// Like <see cref="HttpResponseMessage.EnsureSuccessStatusCode"/>, but includes the response
    /// body in the exception message — DocuPipe error responses carry a reason in the body that
    /// <c>EnsureSuccessStatusCode</c> alone discards.
    /// </summary>
    internal static async Task EnsureSuccessWithBodyAsync(
        this HttpResponseMessage response,
        CancellationToken cancellationToken = default)
    {
        if (response.IsSuccessStatusCode)
            return;

        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        throw new HttpRequestException(
            $"DocuPipe request to {response.RequestMessage?.RequestUri} failed with {(int)response.StatusCode} {response.StatusCode}: {body}");
    }
}
