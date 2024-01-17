using System.Text.Json.Serialization;

namespace RainfallAPI.TransformObjects.ResponseObjects
{
    public class RainfallReading
    {
        [JsonPropertyName("dateMeasured")]
        public DateTime DateMeasured { get; set; }
        [JsonPropertyName("amountMeasured")]
        public float AmountMeasured { get; set; }
    }
}
