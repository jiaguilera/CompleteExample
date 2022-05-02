using CompleteExample.Entities;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Extensions
{
    internal static class ContextExtensions
    {
        internal static async ValueTask<Result<T>> ValidateExistsAsync<T>(this CompleteExampleDBContext _context, params object[] keys) where T : class
        {
            var entity = await _context.FindAsync<T>(keys);

            if (entity == default)
            {
                return new Result<T>($"{typeof(T).Name} identified by id {string.Join(", ", keys)} was not found.");
            }

            return new Result<T>(entity);
        }
    }
}
