using System;
using Cake.Core;
using Cake.Core.IO;

namespace Syncromatics.Cake.GoGitVer
{
    public static class GoGitVerResolver
    {
        public static FilePath GetGoGitVerPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null) throw new ArgumentException(nameof(fileSystem));
            if (environment == null) throw new ArgumentException(nameof(environment));

            switch (environment.Platform.Family)
            {
                case PlatformFamily.Linux:
                    return FilePath.FromString("./content/executables/gogitver_linux");
                case PlatformFamily.OSX:
                    return FilePath.FromString("./content/executables/gogitver_darwin");
                case PlatformFamily.Windows:
                    return FilePath.FromString("./content/executables/gogitver_windows.exe");
                default:
                    throw new Exception("Unknown platform -- no bundled GoGitVer executable.");
            }
        }
    }
}
