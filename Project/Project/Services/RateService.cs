using Project.Entities;
using System.Text.Json;

namespace Project.Services
{
    public class RateService : IRateService
    {
        private HttpClient _httpClient;

        public RateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Rate> GetRates(DateTime date)
        {
            string uri = $"https://www.nbrb.by/api/exrates/rates/?ondate={date:yyyy-MM-dd}&periodicity=0";

            var message = new HttpRequestMessage(HttpMethod.Get, uri);
            message.Headers.Add("Accept", "application/json");

            var response = _httpClient.SendAsync(message).Result;
            if (!response.IsSuccessStatusCode) return null;


            StreamReader streamReader = new StreamReader(response.Content.ReadAsStream());

            return JsonSerializer.Deserialize<IEnumerable<Rate>>(
                                                     streamReader.ReadToEnd());
        }
    }
}
