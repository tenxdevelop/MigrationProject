using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetDocumentListQueryHandler : IQueryHandler<GetDocumentListQuery, IList<DocumentModel>>
    {
        private IDocumentRepository _repository;
        public GetDocumentListQueryHandler( IDocumentRepository documentRepository) 
        {
            _repository = documentRepository;
        }
        public async Task<IList<DocumentModel>> Handle(GetDocumentListQuery query)
        {
            return await _repository.GetAllDocumentsByStatementId(query.Id);

        }
    }
}
