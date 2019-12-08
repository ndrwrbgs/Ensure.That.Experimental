namespace Ensure.That.Experimental
{
    using System;
    using System.Linq.Expressions;

    using EnsureThat;

    using JetBrains.Annotations;

    [PublicAPI]
    public static class Anything
    {
        public static void Satisfies<T>(
            this Param<T> param,
            Expression<Func<T, bool>> condition)
        {
            var body = condition.Body;

            // TODO: Cache the compilation of the expression, etc, for performance
            var conditionFunc = condition.Compile();
            var result = conditionFunc(param.Value);
            if (!result)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must satisfy {body.ToString()}");
            }
        }
    }
}