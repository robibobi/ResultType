using System;

namespace Tcoc
{
    public interface Result<out T>
    {
        bool WasSuccessful { get; } 
    }

    public sealed class Success<T> : Result<T>
    {
        public T Value { get; }

        public bool WasSuccessful => true;

        public Success(T value)
        {
            Value = value;
        }
    }

    public sealed class Error<T> : Result<T>
    {
        public bool WasSuccessful => false;
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }
    }

    public static class Result
    {
        public static Success<T> CreateSuccess<T>(T value)
        {
            return new Success<T>(value);
        }

        public static Error<T> CreateError<T>(string message)
        {
            return new Error<T>(message);
        }

        public static Result<T> From<T>(T value, string onErroressage = default(string))
        {
            if (value == null)
            {
                string msg = onErroressage ?? $"Result.From(..):" +
                    $" The specified value was null. At {Environment.StackTrace}";
                return CreateError<T>(msg);
            }
            else
            {
                return CreateSuccess<T>(value);
            }
        }
    }
}
