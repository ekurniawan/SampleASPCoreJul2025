using HandsOnLab.ASPCoreClient.Models;
using NuGet.Common;

namespace HandsOnLab.ASPCoreClient.Services
{
    public class AccountService : IAccount
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AccountService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            var backendUrl = _configuration.GetValue<string>("BackendUrl");
            _httpClient.BaseAddress = new Uri(backendUrl);

        }


        public async Task<UserViewModel> Login(LoginViewModel loginViewModel)
        {
            try
            {
                var jsonContent = System.Text.Json.JsonSerializer.Serialize(loginViewModel);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/Usman/login", content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<UserViewModel>(data);
                    if (result == null)
                    {
                        throw new ArgumentException("Login failed, no data returned.");
                    }
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"Error logging in: {response.ReasonPhrase}");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
