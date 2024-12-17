using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetStatementListByPlaceOwnerQueryHandler : IQueryHandler<GetStatementListByPlaceOWnerQuery, List<StatementModel>>
    {
        private IStatementRepository _statementRepository;

        public GetStatementListByPlaceOwnerQueryHandler(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public async Task<List<StatementModel>> Handle(GetStatementListByPlaceOWnerQuery query)
        {
            var statemenst = await _statementRepository.GetAllStatementsByPlaceOwnerId(query.UserId);
            return statemenst.ToList();
        }
    }
}
