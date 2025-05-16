using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Queries.QueryHandlers
{
    public class GetAllTargetsQueryHandler : IQueryHandler<GetAllTargetsQuery, List<TargetModel>>
    {
        private ITargetRepository _targetRepository;

        public GetAllTargetsQueryHandler(ITargetRepository targetRepository)
        {
            _targetRepository = targetRepository;
        }
        
        public async Task<List<TargetModel>> Handle(GetAllTargetsQuery query)
        {
            var targets = await _targetRepository.GetTargets();
            return targets;
        }
    }
}