using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Queries.QueryHandlers
{
    public class GetRegulationsQueryHandler : IQueryHandler<GetRegulationsQuery, List<RegulationModel>>
    {
        private ITargetRepository _targetRepository;

        public GetRegulationsQueryHandler(ITargetRepository targetRepository)
        {
            _targetRepository = targetRepository;
        }
        
        public async Task<List<RegulationModel>> Handle(GetRegulationsQuery query)
        {
            var isHaveTarget = await _targetRepository.IsHaveTarget(query.TargetName);

            if (!isHaveTarget)
                return null;
            
            var target = await _targetRepository.GetTarget(query.TargetName, DateTime.Now);
            
            return target.GetRegulations();
        }
    }    
}

