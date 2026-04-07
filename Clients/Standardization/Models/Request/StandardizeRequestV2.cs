using System.Text.Json.Serialization;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Standardization.Models.Request;

/// <summary>
/// Request payload for /v2/standardize/batch.
/// </summary>
public sealed class StandardizeRequestBaseV2 : StandardizeRequestBase
{
    [JsonPropertyName("documentIds")] 
    public required List<string> DocumentIds { get; set; }
    
    [JsonPropertyName("displayMode")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<DisplayModeEnum>))]
    public DisplayModeEnum DisplayMode { get; set; } = DisplayModeEnum.Auto;

    [JsonPropertyName("effortLevel")] 
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<EffortLevelEnumV2>))]
    public EffortLevelEnumV2 EffortLevel { get; set; } = EffortLevelEnumV2.Standard;
    
    [JsonPropertyName("splitMode")]
    [JsonConverter(typeof(LowercaseStringEnumJsonConverter<SplitModeEnum>))]
    public SplitModeEnum SplitMode { get; set; } = SplitModeEnum.Auto;
    
    
    [JsonPropertyName("useMetadata")]
    public bool UseMetadata { get; set; } = false;

    [JsonPropertyName("stdVersion")]
    public decimal StdVersion { get; set; } = 2.3m;
    
    [JsonPropertyName("schemaId")] 
    public string? SchemaId { get; set; }
}