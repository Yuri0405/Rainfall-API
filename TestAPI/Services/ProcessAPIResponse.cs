using RainfallAPI.TransformObjects;
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


        public async Task<RainfallReadingResponse> GetResponse(int id, int number)
        {
            var result  = await _httpClient.GetStringAsync("id/stations/"+ id +"/readings?today&_sorted&_limit=" + number);

            RainfallReadingResponse? processedResult = JsonSerializer.Deserialize<RainfallReadingResponse>(result);

            return processedResult;
        }
    }
}
