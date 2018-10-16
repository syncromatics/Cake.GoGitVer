using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
using Cake.Testing.Fixtures;
using Syncromatics.Cake.GoGitVer.CurrentVersion;


namespace Syncromatics.Cake.GoGitVer.Tests.CurrentVersion
{
    public class CurrentVersionFixture : ToolFixture<GoGitVerCurrentVersionSettings>, ICakeContext
    {
        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public CurrentVersionFixture() : base("GoGitVer")
        {
            var executables = new[]
            {
                "./content/executables/gogitver_darwin",
                "./content/executables/gogitver_linux",
                "./content/executables/gogitver_windows.exe",
            };
            foreach (var executable in executables)
            {
                var relativePath = FilePath.FromString(executable);
                var fullPath = Environment.WorkingDirectory.CombineWithFilePath(relativePath);
                FileSystem.CreateFile(fullPath);
            }

            Tools = new ToolLocator(Environment,
                new ToolRepository(Environment),
                new ToolResolutionStrategy(FileSystem, Environment, new Globber(FileSystem, Environment), new CakeConfiguration(new Dictionary<string, string>())));

            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }

        protected override void RunTool()
        {
            this.GetCurrentVersion(Settings);
        }
    }
}