namespace MigrantProjectMVC.Interfaces
{
    public interface IQueryProcessor
    {
        public Task<TResult> Process<TResult>(IQuery<TResult> query);
    }
}
