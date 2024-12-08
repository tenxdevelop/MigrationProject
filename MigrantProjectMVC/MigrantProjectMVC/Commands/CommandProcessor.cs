using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Repositories;

namespace MigrantProjectMVC.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        public Dictionary<Type, object> _handlers = new();

        public CommandProcessor() { }

        public Task<TResponse> Process<TResponse>(ICommand<TResponse> command)
        {
            var commandType = command.GetType();

            if (_handlers.TryGetValue(commandType, out var handlerObj))
            {
                var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResponse));
                var handler = handlerType.GetMethod("Handle");
                return handler.Invoke(handlerObj, new object[] {command}) as Task<TResponse>;
            }

            throw new ArgumentNullException("Handler hadn't been registered ");
        }

        public void RegisterCommandHadnler<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> handler) where TCommand : ICommand<TResponse>
        {
            var type = typeof(TCommand);
            if (_handlers.ContainsKey(type)) return;
            _handlers[type] = handler;
            
            
        }




    }
}
