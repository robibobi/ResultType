using System;
using System.Collections.Generic;
using System.Text;

namespace Tcoc
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this T value)
        {
            return Result.From(value);
        }

        public static Result<T> Match<T>(this Result<T> self, Action<string> onError, Action<T> onSuccess)
        {
            switch (self)
            {
                case Success<T> s: onSuccess(s.Value); return s;
                case Error<T> e: onError(e.Message); return e;
                default:
                case null: return new Error<T>("Failed to match result. Result was NULL");
            }
        }


        public static Result<B> Bind<A, B>(this Result<A> self, Func<A, Result<B>> f)
        {
            switch (self)
            {
                case Success<A> s: return f(s.Value);
                case Error<A> e: return new Error<B>(e.Message);
                default:
                case null: return new Error<B>("Failed to Bind result. Result was Null");
            }
        }


        public static Result<B> Map<A, B>(this Result<A> source, Func<A, B> selector)
        {
            switch (source)
            {
                case Success<A> s: return new Success<B>(selector(s.Value));
                case Error<A> e: return new Error<B>(e.Message);
                default:
                case null: return new Error<B>("Failed to map Result. Passed Result was null");
            }
        }


        public static Result<B> Select<A, B>(this Result<A> source, Func<A, B> selector)
        {
            return source.Map(selector);
        }


        public static Result<B> SelectMany<A, B>(this Result<A> source, Func<A, Result<B>> selector)
        {
            return source.Bind(selector);
        }

      

    }
}
