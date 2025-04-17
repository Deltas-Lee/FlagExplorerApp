using FlagExplorerAPI.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FlagExplorerAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CountryService> _logger;

        public CountryService(HttpClient httpClient, ILogger<CountryService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true,
                NoStore = true
            };
        }
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
            var countries = JsonSerializer.Deserialize<List<Country>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return countries;
        }

        public async Task<Country> GetCountryAsync(string name)
        {
            try
            {
                // Use a dedicated API endpoint to fetch the country by name
                var response = await _httpClient.GetStringAsync($"https://restcountries.com/v3.1/name/{name}");
                var countries = JsonSerializer.Deserialize<List<Country>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Return the first matching country
                return countries?.FirstOrDefault();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error fetching country details");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error deserializing country data");
                return null;
            }
        }
    }
}
