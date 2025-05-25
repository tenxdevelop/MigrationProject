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
            //for test
            var countries = new List<CountryModel>()
            {
                new CountryModel() { Name="Таджикистан"},
                new CountryModel() { Name="Узбекистан"},
                new CountryModel() { Name="Киргизия"},
                new CountryModel() { Name="Казахстан"},
                new CountryModel() { Name="Армения"},
                new CountryModel() { Name="Белорусь"},
                new CountryModel() { Name="Украина"},
                new CountryModel() { Name = "Другая страна" }
            };

            SaveToJson(countries);
            _countries = LoadFromJson();
        }

        public Task<CountryModel> GetCountryByName(string countryName)
        {
            var country = _countries.FirstOrDefault(country => country.Name.Equals(countryName));
            return Task.FromResult(country);
        }
        public Task<List<CountryModel>> GetCountries()
        {
            return Task.FromResult(_countries);
        }
    }
}