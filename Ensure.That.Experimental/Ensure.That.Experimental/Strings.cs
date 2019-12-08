namespace Ensure.That.Experimental
{
    using EnsureThat;

    using JetBrains.Annotations;

    /// <remarks>
    /// TODO: All of these were being lazy, and are not implemented performantly, but do provide some covearge
    /// of Satisfies :-P
    /// </remarks>
    [PublicAPI]
    public static class Strings
    {
        public static void StartsWith(this StringParam param, string prefix)
        {
            param.ToParam().Satisfies(s => s.StartsWith(prefix));
        }

        public static void EndsWith(this StringParam param, string suffix)
        {
            param.ToParam().Satisfies(s => s.EndsWith(suffix));
        }

        public static void Contains(this StringParam param, string substring)
        {
            // TODO: Can move the 'context' into an argument to avoid newing up Funcs, but not sure if that'd  help with expressions. Delaying modifications until in 'hard core performance' mode'
            param.ToParam().Satisfies(s => s.Contains(substring));
        }

        public static void IsNullOrWhitespace(this StringParam param)
        {
            param.ToParam().Satisfies(s => string.IsNullOrWhiteSpace(s));
        }

        public static void IsNullOrEmpty(this StringParam param)
        {
            param.ToParam().Satisfies(s => string.IsNullOrEmpty(s));
        }

        public static void IsEmpty(this StringParam param)
        {
            param.ToParam().Satisfies(s => string.Equals(s, string.Empty));
        }

        public static Param<int> Length(this StringParam param)
        {
            return new Param<int>(
                param.Name + ".Length",
                param.Value.Length,
                param.OptsFn);
        }
    }
}