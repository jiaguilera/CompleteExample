using CompleteExample.Entities;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    public static class ContextExtensions
    {
        public static async ValueTask<Result<T>> ValidateExists<T>(this CompleteExampleDBContext _context, params object[] keys) where T : class
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
