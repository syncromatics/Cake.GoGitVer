using System;
using Cake.Core;
using Cake.Core.Annotations;
using Syncromatics.Cake.GoGitVer.CurrentVersion;

namespace Syncromatics.Cake.GoGitVer
{
    partial class GoGitVerAliases
    {
        /// <summary>
        /// Parses a <see cref="VersionInfo">VersionInfo</see> object created from commits to specified git repository.
        /// </summary>
        [CakeMethodAlias]
        public static VersionInfo GetCurrentVersion(this ICakeContext context, GoGitVerCurrentVersionSettings settings)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var tool = new GoGitVerTool<GlobalGoGitVerSettings>(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools);
            var result = tool.Run(settings ?? new GoGitVerCurrentVersionSettings());
            return VersionInfo.Parse(result);
        }
    }
}