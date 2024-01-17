namespace RainfallAPI.TransformObjects
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public List<ErrorDetail>? Details { get; set; }
    }
}
