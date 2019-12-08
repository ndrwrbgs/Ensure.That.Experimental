namespace Ensure.That.Experimental
{
    using System.IO;

    using EnsureThat;
    using JetBrains.Annotations;

    [PublicAPI]
    public static class Paths
    {
        public static void DirectoryExists(
            this in StringParam param)
        {
            if (!Directory.Exists(param.Value))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    "The specified directory must exist");
            }
        }

        public static void DirectoryDoesNotExist(
            this in StringParam param)
        {
            if (Directory.Exists(param.Value))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    "The specified directory must not exist");
            }
        }

        public static void FileExists(
            this in StringParam param)
        {
            if (!File.Exists(param.Value))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    "The specified file must exist");
            }
        }

        public static void FileDoesNotExist(
            this in StringParam param)
        {
            if (File.Exists(param.Value))
            {
                Exceptions.ThrowArgumentException(
                    param.Name,
                    param.Value,
                    param.OptsFn,
                    "The specified file must not exist");
            }
        }
    }
}