using System;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Extensions
{
    public static class ResultExtensions
    {
        public static async ValueTask<Result<U>> ThenAsync<T, U>(this ValueTask<Result<T>> task, Func<T, ValueTask<Result<U>>> continuation)
        {
            var result = await task;
            return await result.ThenAsync(continuation);
        }
    }
}
