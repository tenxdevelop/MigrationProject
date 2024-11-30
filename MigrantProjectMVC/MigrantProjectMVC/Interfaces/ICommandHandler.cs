namespace MigrantProjectMVC.Interfaces
{
    public interface ICommandHandler<TRequist, TResponse> where TRequist : ICommand<TResponse>
    {
        public Task<TResponse> Handler(TRequist requist);
    }
}
