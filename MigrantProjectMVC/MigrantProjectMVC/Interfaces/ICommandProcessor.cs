namespace MigrantProjectMVC.Interfaces
{
    public interface ICommandProcessor
    {
        public Task<TResponse> Process<TResponse>(ICommand<TResponse> command);
    }
}
