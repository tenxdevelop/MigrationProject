using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Repositories;

namespace MigrantProjectMVC.Models
{
    public class CommandProcessor : ICommandProcessor
    {
        public Dictionary<Type, object> _handlers = new();

        public CommandProcessor() { }

        public async Task<TResponse> Process<TResponse>(ICommand<TResponse> command)
        {
            var commandType = command.GetType();

            // Проверяем, зарегистрирован ли обработчик для команды
            if (_handlers.TryGetValue(commandType, out var handlerObj))
            {
                // Получаем реальный тип обработчика и используем dynamic для вызова
                var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResponse));
                if (handlerObj.GetType().GetInterfaces().Any(i => i == handlerType))
                {
                    // Используем dynamic для вызова обработчика
                    dynamic handler = handlerObj;
                    return await handler.Handler((dynamic)command);
                }
            }

            throw new InvalidOperationException("Handler not found in CommandProcessor");
        }

        public void RegisterCommandHadnler<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> handler) where TCommand : ICommand<TResponse>
        {
            _handlers[typeof(TCommand)] = handler;
        }



       
    }
}
