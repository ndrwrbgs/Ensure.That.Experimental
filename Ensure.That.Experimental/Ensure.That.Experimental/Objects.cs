namespace Ensure.That.Experimental
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EnsureThat;

    using JetBrains.Annotations;

    [PublicAPI]
    public static class Objects
    {
        public static void IsNullOr<T>(
            this Param<T> param,
            Action<Param<T>> continuationWhenNotNull)
            where T : class
        {
            if (param.Value == null)
            {
                return;
            }

            continuationWhenNotNull(param);
        }

        public static void IsNull<T>(this Param<T> param)
            where T : class
        {
            if (param.Value != null)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    "The value must be null");
            }
        }

        public static void IsOfTypeOrSubtype<T>(this Param<T> param, Type typeToImplement)
        {
            Implements(param, typeToImplement);
        }

        public static void IsOfTypeOrSubtype(this TypeParam param, Type typeToImplement)
        {
            Implements(param, typeToImplement);
        }

        public static void Extends<T>(this Param<T> param, Type typeToImplement)
        {
            Implements(param, typeToImplement);
        }

        public static void Extends(this TypeParam param, Type typeToImplement)
        {
            Implements(param, typeToImplement);
        }

        public static void Implements<T>(this Param<T> param, Type typeToImplement)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (param.Value == null)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must implement {typeToImplement}, but is null");
            }

            var type = param.Value.GetType();
            Ensure.ThatType(type, param.Name, param.OptsFn)
                .Implements(typeToImplement);
        }

        public static void Implements(this TypeParam param, Type typeToImplement)
        {
            var type = param.Type;
            if (!typeToImplement.IsAssignableFrom(type))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Type,
                    param.OptsFn,
                    $"The type must implement {typeToImplement}");
            }
        }

        public static void IsAnyOf<T>(
            this Param<T> param,
            IEnumerable<T> allowed)
            where T : IEquatable<T>
        {
            IsAnyOf(param, allowed, EqualityComparer<T>.Default);
        }

        public static void IsAnyOf<T>(
            this Param<T> param,
            [NotNull] IEnumerable<T> allowed,
            IEqualityComparer<T> comparer)
        {
            if (!allowed.Contains(param.Value, comparer))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The parameter was not in the set of allowed values");
            }
        }

        public static void IsAnyOf<T>(
            this Param<T> param,
            IEqualityComparer<T> comparer,
            [NotNull] params T[] allowed)
        {
            if (!allowed.Contains(param.Value, comparer))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The parameter was not in the set of allowed values");
            }
        }

        /// <remarks>
        /// We can do:
        /// * TMe : IEquatable{TOthers}
        /// * TOthers : IEquatable{TMe}
        /// * TMe : TOthers
        /// * TOthers : TMe
        /// but CSharp will say all have the same signatures and a method can't have multiple disjoint constraints
        /// on types, so we have to do it at runtime
        /// </remarks>
        /// <remarks>
        /// TODO Not implemented
        /// </remarks>
        internal static void IsAnyOf<TMe, TOthers>(
            this Param<TMe> param,
            IEnumerable<TOthers> allowed)
            where TMe : IEquatable<TOthers>
        {
            throw new NotImplementedException();
        }

        public static void IsNotAnyOf<T>(
            this Param<T> param,
            IEnumerable<T> allowed)
            where T : IEquatable<T>
        {
            IsNotAnyOf(param, allowed, EqualityComparer<T>.Default);
        }

        public static void IsNotAnyOf<T>(
            this Param<T> param,
            [NotNull] IEnumerable<T> allowed,
            IEqualityComparer<T> comparer)
        {
            if (allowed.Contains(param.Value, comparer))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The parameter was in the set of disallowed values");
            }
        }

        public static void IsNotAnyOf<T>(
            this Param<T> param,
            IEqualityComparer<T> comparer,
            [NotNull] params T[] allowed)
        {
            if (allowed.Contains(param.Value, comparer))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The parameter was in the set of disallowed values");
            }
        }
    }
}