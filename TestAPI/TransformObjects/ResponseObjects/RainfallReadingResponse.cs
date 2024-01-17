using RainfallAPI.TransformObjects.APIRequestObjects;
using System.Text.Json.Serialization;

namespace RainfallAPI.TransformObjects.ResponseObjects
{
    public class RainfallReadingResponse
    {
        [JsonPropertyName("readings")]
        public List<RainfallReading>? Readings { get; set; }
    }
}
