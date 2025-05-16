using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface ICountryRepository
    {
        Task<CountryModel> GetCountryByName(string countryName);

        Task<List<CountryModel>> GetCountries();
    }
}