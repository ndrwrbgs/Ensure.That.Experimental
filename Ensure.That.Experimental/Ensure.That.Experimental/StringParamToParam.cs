namespace Ensure.That.Experimental
{
    using EnsureThat;

    internal static class StringParamToParam
    {
        public static Param<string> ToParam(this in StringParam param)
        {
            return new Param<string>(
                param.Name,
                param.Value,
                param.OptsFn);
        }
    }
}