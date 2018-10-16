using Cake.Core.Tooling;

namespace Syncromatics.Cake.GoGitVer
{
    public class GlobalGoGitVerSettings : ToolSettings
    {
        /// <summary>
        /// Path to the Git repository to parse
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Path to the gogitver.yaml settings file
        /// </summary>
        public string Settings { get; set; }
    }
}