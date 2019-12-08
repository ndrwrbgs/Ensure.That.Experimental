namespace Ensure.That.Experimental
{
    using System.Collections;

    using EnsureThat;

    using JetBrains.Annotations;

    /// <remarks>
    /// TODO: Postponing Collections since the ICollection, ICollection{T}, IReadOnlyCollection{T} mess with
    /// type inference failures of multiple types and variance of the generic arguments means that either
    /// we fail to support many types, or users always have to specify the types on the calls.
    /// We can get around this by requiring 1 type (e.g. IReadOnlyCollection) and making the user convert the
    /// others (we provide utility method) but until we decide which type to expose, postponing implementation
    /// TODO: Ditto for dictionary
    /// </remarks>
    [PublicAPI]
    public static class Collections
    {
        /// <remarks>
        /// TODO:
        /// Between this and Ensure.That.Expressions, introduce a .Property() method that takes a delegate
        /// and correctly modifies the Param{T}.Name with the original parameter AND the property being used
        /// (such as Count in this example)
        /// </remarks>
        public static Param<int> Count<T>(this Param<T> param)
            where T : ICollection
        {
            return new Param<int>(
                param.Name + ".Count",
                param.Value.Count,
                param.OptsFn);
        }
    }
}