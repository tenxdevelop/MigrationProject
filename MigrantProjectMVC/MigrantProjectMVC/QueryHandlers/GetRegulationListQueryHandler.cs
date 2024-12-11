using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetRegulationListQueryHandler : IQueryHandler<GetRegulationListQuery, List<RegulationModel>>
    {
        IRegulationRepository _regulationRespository;
        public GetRegulationListQueryHandler(IRegulationRepository regulationRepository) 
        {
            _regulationRespository = regulationRepository;
        }

        public async Task<List<RegulationModel>> Handle(GetRegulationListQuery query)
        {
            var regulations = await _regulationRespository.GetAllRegulations();
            return regulations as List<RegulationModel>;
        }
    }
}
