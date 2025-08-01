using HandsOnLab.ASPCoreClient.Models;
using System.Text.Json;

namespace HandsOnLab.ASPCoreClient.Services
{
    public class DealerService : IDealerService
    {
        private readonly HttpClient _httpClient;
        public DealerService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://localhost:7095/");
        }

        public async Task<Dealer> CreateDealerAsync(Dealer dealer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDealerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Dealer> GetDealerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Dealer>> GetDealersAsync()
        {
            var response = await _httpClient.GetAsync("api/Dealers");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var dealers = JsonSerializer.Deserialize<IEnumerable<Dealer>>(data);
                return dealers ?? Enumerable.Empty<Dealer>();
            }
            else
            {
                throw new HttpRequestException($"Error fetching dealers: {response.ReasonPhrase}");
            }
        }

        public Task<Dealer> UpdateDealerAsync(Dealer dealer)
        {
            throw new NotImplementedException();
        }
    }
}
