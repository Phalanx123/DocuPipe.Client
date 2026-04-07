using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Converters;

public sealed class DecimalNoTrailingZeroConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetDecimal();

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        => writer.WriteRawValue(value.ToString("G29"));
}