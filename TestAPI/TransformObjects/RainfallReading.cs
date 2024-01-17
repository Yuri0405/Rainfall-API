using System.Text.Json;
using System.Text.Json.Serialization;

namespace RainfallAPI.TransformObjects
{
    public class RainfallReading
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateMeasured { get; set; }
        [JsonPropertyName("value")]
        public float AmountMeasured { get; set; }
    }
}
