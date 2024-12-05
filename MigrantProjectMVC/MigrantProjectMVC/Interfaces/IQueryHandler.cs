namespace MigrantProjectMVC.Interfaces
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        public Task<TResult> Handle(TQuery query);
    }
}
