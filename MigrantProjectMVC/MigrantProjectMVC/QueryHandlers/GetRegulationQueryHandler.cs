using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetRegulationQueryHandler : IQueryHandler<GetRegulationQuery, RegulationModel>
    {
        IMigrantRepository _migrantReppository;
        IRegulationRepository _regulationRepository;
        public GetRegulationQueryHandler(IMigrantRepository migrantRepository, IRegulationRepository regulationRepository) 
        {
            _migrantReppository = migrantRepository;
            _regulationRepository = regulationRepository;
        }

        public async Task<RegulationModel> Handle(GetRegulationQuery query) 
        {
            var country = await _migrantReppository.GetCountryByEmail(query.Email);
            return await _regulationRepository.GetRegulationWithCountry(country);
        }
    }
}
