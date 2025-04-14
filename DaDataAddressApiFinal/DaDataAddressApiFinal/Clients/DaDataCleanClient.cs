using System.Net.Http.Headers;
using System.Text;
using DaDataAddressApiFinal.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DaDataAddressApiFinal.Clients
{
    public class DaDataCleanClient : ICleanAddressClient
    {
        private readonly HttpClient _httpClient;
        private readonly DaDataOptions _options;

        public DaDataCleanClient(HttpClient httpClient, IOptions<DaDataOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;

            _httpClient.BaseAddress = new Uri(_options.BaseUri);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _options.Token);
            _httpClient.DefaultRequestHeaders.Add("X-Secret", _options.Secret);
        }

        public async Task<AddressResponse?> CleanAddressAsync(string query)
        {
            var payload = JsonSerializer.Serialize(new[] { query });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("", content);

            if (!response.IsSuccessStatusCode) { return null; }

            var json = await response.Content.ReadAsStringAsync();
            var array = JsonSerializer.Deserialize<List<AddressResponse>>(json);
            return array?.FirstOrDefault() ?? new AddressResponse();
        }
    }
}
