// ReSharper disable CompareOfFloatsByEqualityOperator
namespace Ensure.That.Experimental
{
    using System;

    using EnsureThat;

    using JetBrains.Annotations;

    /// <remarks>
    /// TODO: Really need a t4 for this
    /// </remarks>
    [PublicAPI]
    public static class Number
    {
        public static void IsApproximately(
            this Param<decimal> param,
            decimal value,
            decimal maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        public static void IsApproximately(
            this Param<double> param,
            double value,
            double maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        public static void IsApproximately(
            this Param<short> param,
            short value,
            short maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        public static void IsApproximately(
            this Param<int> param,
            int value,
            int maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        public static void IsApproximately(
            this Param<long> param,
            long value,
            long maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        public static void IsApproximately(
            this Param<sbyte> param,
            sbyte value,
            sbyte maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        public static void IsApproximately(
            this Param<float> param,
            float value,
            float maxDifference)
        {
            var difference = Math.Abs(param.Value - value);
            if (difference > maxDifference)
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    $"The value must be within {maxDifference} of {value}");
            }
        }

        /// <summary>
        /// Evidently zero is... complicated
        /// <see href="https://math.stackexchange.com/questions/26705/is-zero-positive-or-negative"/>
        /// </summary>
        [Flags]
        [PublicAPI]
        public enum ZeroSignMode
        {
            ZeroIsNeither = 0,
            ZeroIsPositive = 1 << 0,
            ZeroIsNegative = 1 << 1,
            ZeroIsBoth = ZeroIsPositive | ZeroIsNegative
        }

        public static void IsPositive(
            this Param<decimal> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<decimal> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<decimal> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }

        public static void IsPositive(
            this Param<double> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<double> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<double> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }

        public static void IsPositive(
            this Param<short> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<short> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<short> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }

        public static void IsPositive(
            this Param<int> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<int> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<int> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }

        public static void IsPositive(
            this Param<long> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<long> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<long> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }

        public static void IsPositive(
            this Param<sbyte> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<sbyte> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<sbyte> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }

        public static void IsPositive(
            this Param<float> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsPositive))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be positive");
        }

        public static void IsNegative(
            this Param<float> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value < 0)
            {
                return;
            }

            if (param.Value == 0 && zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be negative");
        }

        public static void IsNonNegative(
            this Param<float> param,
            ZeroSignMode zeroSignMode = ZeroSignMode.ZeroIsNeither)
        {
            if (param.Value > 0)
            {
                return;
            }

            if (param.Value == 0 && !zeroSignMode.HasFlag(ZeroSignMode.ZeroIsNegative))
            {
                return;
            }

            Exceptions.ThrowArgumentException(
                param.Name,
                param.Value,
                param.OptsFn,
                "The value must be non-negative");
        }
    }
}