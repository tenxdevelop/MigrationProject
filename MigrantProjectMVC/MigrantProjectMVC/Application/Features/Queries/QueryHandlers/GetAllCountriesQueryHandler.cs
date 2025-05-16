using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Queries.QueryHandlers
{
    public class GetAllCountriesQueryHandler : IQueryHandler<GetAllCountriesQuery, List<CountryModel>>
    {
        private ICountryRepository _countryRepository;

        public GetAllCountriesQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        
        public async Task<List<CountryModel>> Handle(GetAllCountriesQuery query)
        {
            var countries = await _countryRepository.GetCountries();
            return countries;
        }
    }
}