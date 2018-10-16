using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Syncromatics.Cake.GoGitVer.Extensions;

namespace Syncromatics.Cake.GoGitVer
{
    public class GoGitVerTool<TSettings> : Tool<TSettings>
        where TSettings : GlobalGoGitVerSettings
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;

        public GoGitVerTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
            _environment = environment;
        }

        public string Run(TSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var process = RunProcess(settings, GetArguments(settings));
            var result = process.GetStandardOutput().First();
            return result;
        }

        private ProcessArgumentBuilder GetArguments(TSettings settings)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(settings);
            return builder;
        }

        protected override string GetToolName() =>
            "GoGitVer";

        protected override IEnumerable<string> GetToolExecutableNames() =>
            new[]
            {
                "gogitver.exe",
                "gogitver"
            };

        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = GoGitVerResolver.GetGoGitVerPath(_fileSystem, _environment);
            Console.WriteLine($"**** FOUND THIS TOOL: {path}");
            Console.WriteLine($"**** WORKING DIR: {_environment.WorkingDirectory}");
            return path != null
                ? new[] { path }
                : Enumerable.Empty<FilePath>();
        }
    }
}
