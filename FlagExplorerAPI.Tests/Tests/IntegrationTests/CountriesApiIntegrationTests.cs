using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FlagExplorerAPI.Models;
using FlagExplorerAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using RichardSzalay.MockHttp;

namespace FlagExplorerAPI.Tests.IntegrationTests
{
    public class CountryServiceIntegrationTests
    {
        private readonly Mock<ILogger<CountryService>> _mockLogger;
        private readonly HttpClient _httpClient;
        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly CountryService _countryService;

        public CountryServiceIntegrationTests()
        {
            _mockLogger = new Mock<ILogger<CountryService>>();
            _mockHttpMessageHandler = new MockHttpMessageHandler();
            _httpClient = new HttpClient(_mockHttpMessageHandler);
            _countryService = new CountryService(_httpClient, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnsListOfCountries()
        {
            // Arrange
            var mockResponse = JsonSerializer.Serialize(new List<Country>
            {
                new Country
                {
                    Name = new Translation { Common = "South Africa", Official = "Republic of South Africa" },
                    Flag = new Flag
                    {
                        Svg = "https://flagcdn.com/w320/za.svg",
                        Png = "https://flagcdn.com/h240/za.png"
                    },
                    Capital = new[] { "Pretoria", "Bloemfontein", "Cape Town" },
                    Population = 59308690
                }
            });

            _mockHttpMessageHandler.When("https://restcountries.com/v3.1/all")
                                   .Respond(HttpStatusCode.OK, "application/json", mockResponse);

            // Act
            var countries = await _countryService.GetAllCountriesAsync();

            // Assert
            Assert.NotNull(countries);
            Assert.Single(countries);
            Assert.Equal("South Africa", countries[0].Name.Common);
        }

        [Fact]
        public async Task GetCountryAsync_ReturnsCountryDetails()
        {
            // Arrange
            var countryName = "South Africa";
            var mockResponse = JsonSerializer.Serialize(new List<Country>
            {
                new Country
                {
                    Name = new Translation { Common = "South Africa", Official = "Republic of South Africa" },
                    Flag = new Flag
                    {
                        Svg = "https://flagcdn.com/w320/za.svg",
                        Png = "https://flagcdn.com/h240/za.png"
                    },
                    Capital = new[] { "Pretoria", "Bloemfontein", "Cape Town" },
                    Population = 59308690
                }
            });

            _mockHttpMessageHandler.When($"https://restcountries.com/v3.1/name/{countryName}")
                                   .Respond(HttpStatusCode.OK, "application/json", mockResponse);

            // Act
            var country = await _countryService.GetCountryAsync(countryName);

            // Assert
            Assert.NotNull(country);
            Assert.Equal("South Africa", country.Name.Common);
            Assert.Equal("Republic of South Africa", country.Name.Official);
            Assert.Equal(59308690, country.Population);
        }

        [Fact]
        public async Task GetCountryAsync_ReturnsNull_WhenCountryNotFound()
        {
            // Arrange
            var countryName = "InvalidCountry";
            _mockHttpMessageHandler.When($"https://restcountries.com/v3.1/name/{countryName}")
                                   .Respond(HttpStatusCode.NotFound);

            // Act
            var country = await _countryService.GetCountryAsync(countryName);

            // Assert
            Assert.Null(country);
        }
    }
}