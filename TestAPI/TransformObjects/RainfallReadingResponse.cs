using System.Text.Json.Serialization;

namespace RainfallAPI.TransformObjects
{
    public class RainfallReadingResponse
    {
        [JsonPropertyName("items")]
        public List<RainfallReading>? Readings { get; set; }
        
    }
}
