using FlagExplorerAPI.Models;

namespace FlagExplorerAPI.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryAsync(string name);
    }
}
