using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocuPipe.Converters;

/// <summary>
/// Reads enum values from lowercase (and generally case-insensitive) strings.
/// Writes enum values as lowercase strings.
/// </summary>
public sealed class LowercaseStringEnumJsonConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException($"Expected string token for {typeof(TEnum).Name}.");

        var raw = reader.GetString();
        if (string.IsNullOrWhiteSpace(raw))
            throw new JsonException($"Empty value for {typeof(TEnum).Name}.");

        // Case-insensitive parse handles "processing" -> Processing
        if (Enum.TryParse<TEnum>(raw, ignoreCase: true, out var value))
            return value;

        throw new JsonException($"Unknown {typeof(TEnum).Name} value '{raw}'.");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString().ToLowerInvariant());
}