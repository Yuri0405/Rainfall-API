using RainfallAPI.TransformObjects.APIRequestObjects;
using RainfallAPI.TransformObjects.ResponseObjects;
using System.Text.Json;

namespace RainfallAPI.Services
{
    public class ProcessAPIResponse
    {
        private readonly HttpClient _httpClient;

        public ProcessAPIResponse(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RainfallReadingResponse?> GetResponse(int id, int number)
        {
            var result = await _httpClient.GetStringAsync("id/stations/" + id + "/readings?today&_sorted&_limit=" + number);
            RainfallReadingResponseReq? getResult = JsonSerializer.Deserialize<RainfallReadingResponseReq>(result);

            if (getResult == null)
                return null;

            var processedResult = ResponseMapper(getResult);

            return processedResult;
        }

        public RainfallReadingResponse ResponseMapper(RainfallReadingResponseReq response)
        {
            var mappedReadings = response.Readings?.Select(res =>
                new RainfallReading
                {
                    DateMeasured = res.DateMeasured,
                    AmountMeasured = res.AmountMeasured
                }
            ).ToList();

            return new RainfallReadingResponse { Readings = mappedReadings };

        }
    }
}
