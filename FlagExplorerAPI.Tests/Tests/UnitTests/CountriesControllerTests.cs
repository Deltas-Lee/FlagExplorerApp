using FlagExplorerAPI.Controllers;
using FlagExplorerAPI.Services;
using Xunit;
using Moq;
using FlagExplorerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlagExplorerAPI.Tests.UnitTests
{
    public class CountriesControllerTests
    {
        private readonly Mock<ICountryService> _mockCountryService;
        private readonly CountriesController _controller;
        public CountriesControllerTests()
        {
            _mockCountryService = new Mock<ICountryService>();
            _controller = new CountriesController(_mockCountryService.Object);
        }
        // Test for GetCountries
        [Fact]
        public async Task GetCountries_ReturnsOkResult_WithListOfCountries()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country
                {
                    Name = new Translation { Common = "South Africa", Official = "Republic of South Africa"},
                    Flag = new Flag
                    {
                        Svg = "https://flagcdn.com/w320/za.svg",
                        Png = "https://flagcdn.com/h240/za.png"
                    },
                    Capital = ["Pretoria", "Bloemfontein", "Cape Town"],
                    Population = 59308690
                }
            };
            _mockCountryService.Setup(service => service.GetAllCountriesAsync()).ReturnsAsync(new List<Country>());

            // Act
            var result = await _controller.GetCountries();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedCountries = Assert.IsType<List<Country>>(okResult.Value);
            Assert.Equal(1, returnedCountries.Count);
        }

        // Test for GetCountryDetails
        [Fact]
        public async Task GetCountryDetails_ReturnsOkResult_WithCountryDetails()
        {
            // Arrange
            var countryName = "South Africa";
            var country = new Country
            {
                Name = new Translation { Common = "South Africa", Official = "Republic of South Africa" },
                Flag = new Flag
                {
                    Svg = "https://flagcdn.com/w320/za.svg",
                    Png = "https://flagcdn.com/h240/za.png"
                },
                Capital = new[] { "Pretoria", "Bloemfontein", "Cape Town" },
                Population = 59308690
            };
            _mockCountryService.Setup(service => service.GetCountryByNameAsync(countryName)).ReturnsAsync(country);

            // Act
            var result = await _controller.GetCountryAsync(countryName);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedCountry = Assert.IsType<Country>(okResult.Value);
            Assert.Equal(countryName, returnedCountry.Name.Common);
            Assert.Equal("Republic of South Africa", returnedCountry.Name.Official);
            Assert.Equal(59308690, returnedCountry.Population);
            Assert.Equal(3, returnedCountry.Capital.Length);
            Assert.Equal("Pretoria", returnedCountry.Capital[0]);
        }
    }
}
