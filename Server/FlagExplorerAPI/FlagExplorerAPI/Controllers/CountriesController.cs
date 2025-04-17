using FlagExplorerAPI.Models;
using FlagExplorerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlagExplorerAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/countries
        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        // GET: api/country-details/{name}
        [HttpGet("country-details/{name}")]
        public async Task<ActionResult<Country>> GetCountry(string name)
        {

            var country = await _countryService.GetCountryAsync(name);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}
