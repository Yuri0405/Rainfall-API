using System.Text.Json.Serialization;

namespace RainfallAPI.TransformObjects.APIRequestObjects
{
    public class RainfallReadingResponseReq
    {
        [JsonPropertyName("items")]
        public List<RainfallReadingReq>? Readings { get; set; }
    }
}
