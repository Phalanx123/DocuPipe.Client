using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Serialization;

internal static class DocuPipeJsonSerializerOptions
{
    internal static JsonSerializerOptions Default { get; } = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}
