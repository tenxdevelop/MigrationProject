using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetDocumentListQuery : IQuery<IList<DocumentModel>>
    {
        public Guid Id { get; set; }
        public GetDocumentListQuery(Guid id) { Id = id; }
    }
}
