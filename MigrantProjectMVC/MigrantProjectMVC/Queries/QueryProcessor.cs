using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Queries
{
    public class QueryProcessor : IQueryProcessor
    { 
        public Dictionary<Type, object> _handlers = new Dictionary<Type, object>();
        public Task<TResult> Process<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            if (_handlers.TryGetValue(queryType, out var handlerObj))
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
                var handler = handlerType.GetMethod("Handle");
                return handler.Invoke(handlerObj, new object[] {query}) as Task<TResult>;
            }
            return null;
        }

        public void RegisterQueryHandler<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler) where TQuery : IQuery<TResult>
        {
            var type = typeof(TQuery);
            if (_handlers.ContainsKey(type)) return;
            _handlers[type] = handler;
        }
    }
}
