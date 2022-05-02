using System;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    public class Result<T>
    {
        private readonly T _result;
        private readonly string _error;

        public Result(T result)
        {
            _result = result;
        }

        public Result(string error)
        {
           _error = error;
        }

        public U Select<U>(Func<T,U> result, Func<string,U> error)
        {
            if (_error != default)
            {
                return error(_error);
            }

            return result(_result);
        }

        public async ValueTask<Result<U>> ThenAsync<U>(Func<T, ValueTask<Result<U>>> func)
        {
            if (_error != default)
            {
                return new Result<U>(_error);
            }

            return await func(_result);
        }
    }
}
