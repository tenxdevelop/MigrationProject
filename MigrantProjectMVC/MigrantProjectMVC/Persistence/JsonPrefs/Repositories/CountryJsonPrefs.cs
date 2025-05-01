using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class CountryJsonPrefs : JsonPrefs<List<CountryModel>>, ICountryRepository
    {
        private const string FILE_PATH = "jsons/country.json";
        
        private List<CountryModel> _countries;
        
        public CountryJsonPrefs() : base(FILE_PATH)
        {
            _countries = LoadFromJson();
        }

        public Task<CountryModel> GetCountryByName(string countryName)
        {
            var country = _countries.FirstOrDefault(country => country.Name.Equals(countryName));
            return Task.FromResult(country);
        }
    }
}