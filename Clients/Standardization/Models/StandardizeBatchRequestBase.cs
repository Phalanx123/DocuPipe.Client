using System.Text.Json.Serialization;
using DocuPipe.Converters;

namespace DocuPipe.Clients.Standardization.Models;

public abstract class StandardizeBatchRequestBase
{ 
    
    [JsonPropertyName("guidelines")] 
    public string? Guidelines { get; set; }
    
}