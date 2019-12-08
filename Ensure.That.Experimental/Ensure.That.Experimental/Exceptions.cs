namespace Ensure.That.Experimental
{
    using System;

    using EnsureThat;

    internal static class Exceptions
    {
        public static void ThrowArgumentException(
            string paramName,
            object paramValue,
            OptsFn optsFn,
            string defaultMessage)
        {
            throw ArgumentException(paramName, paramValue, optsFn, defaultMessage);
        }

        private static Exception ArgumentException(
            string paramName,
            object paramValue,
            OptsFn optsFn,
            string defaultMessage)
        {
            if (optsFn != null)
            {
                EnsureOptions ensureOptions = optsFn(new EnsureOptions());
                if (ensureOptions.CustomException != null)
                {
                    return ensureOptions.CustomException;
                }

                if (ensureOptions.CustomMessage != null)
                {
                    return (Exception) new ArgumentOutOfRangeException(ensureOptions.CustomMessage, paramValue, paramName);
                }
            }

            return (Exception) new ArgumentOutOfRangeException(paramName, paramValue, defaultMessage);
        }
    }
}