using MigrantProjectMVC.Application.Features.Queries.Queries;
using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.Application.Features.Queries.QueryHandlers
{
    public class GetRefferalQueryHandler : IQueryHandler<GetRefferalQuery, RefferalViewModel>
    {
        
        private IRefferalService _refferalService;

        public GetRefferalQueryHandler(IRefferalService refferalService)
        {
            _refferalService = refferalService;
        }
        
        public async Task<RefferalViewModel> Handle(GetRefferalQuery query)
        {
            var refferalViewModel = await _refferalService.GetRefferal(query.TargetName, query.Name, query.Surname, query.Patronymic);
            
            return refferalViewModel;
        }
    }
}