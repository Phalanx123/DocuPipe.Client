using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Standardization.Models.Request;

public abstract class StandardizeRequestBase
{ 
    
    [JsonPropertyName("guidelines")] 
    public string? Guidelines { get; set; }
    
}