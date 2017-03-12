using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcoc.ResultType
{
    abstract class Result<T>
    {
        public abstract bool WasSuccessful { get; }
    }

    class Success<T> : Result<T>
    {
        public T Value { get; }

        public override bool WasSuccessful => true;

        public Success(T value)
        {
            this.Value = value;
        }
    }

    class Error<T> : Result<T>
    {
        public string Message { get; }

        public override bool WasSuccessful => false;

        public Error(string msg)
        {
            this.Message = msg;
        }
    }

    class Result
    {
        public static Result<T> From<T>(T value, string errorMsg)
        {
            if(value  == null)
            {
                return new Error<T>(errorMsg);
            } else
            {
                return new Success<T>(value);
            }
        }
    }

}
