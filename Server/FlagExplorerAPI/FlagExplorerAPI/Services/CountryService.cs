using FlagExplorerAPI.Models;
using System.Text.Json;

namespace FlagExplorerAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
            var countries = JsonSerializer.Deserialize<List<Country>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return countries;
        }

        public async Task<CountryDetails> GetCountryDetailsAsync(string name)
        {
            var response = await _httpClient.GetStringAsync($"https://restcountries.com/v3.1/name/{name}");
            var countryDetails = JsonSerializer.Deserialize<List<CountryDetails>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return countryDetails?[0];
        }
    }
}
