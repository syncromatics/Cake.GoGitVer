using System;

namespace Syncromatics.Cake.GoGitVer.CurrentVersion
{
    public class VersionInfo
    {
        /// <summary>
        /// The full semantic version, including major, minor, patch, and pre-release metadata.
        /// </summary>
        public string FullVersion { get; private set; }

        /// <summary>
        /// The major and minor versions only.
        /// </summary>
        public string MajorMinorVersion { get; set; }

        /// <summary>
        /// The major, minor, and patch versions only.
        /// </summary>
        public string MajorMinorPatchVersion { get; set; }

        /// <summary>
        /// The major version.
        /// </summary>
        public string MajorVersion { get; private set; }

        /// <summary>
        /// The minor version.
        /// </summary>
        public string MinorVersion { get; private set; }

        /// <summary>
        /// The patch version.
        /// </summary>
        public string PatchVersion { get; private set; }

        /// <summary>
        /// The pre-release metadata, if any.
        /// </summary>
        public string PreReleaseTag { get; private set; }

        /// <summary>
        /// Whether this version includes pre-release metadata.
        /// </summary>
        public bool IsPreRelease { get; private set; }

        private VersionInfo()
        { }

        /// <summary>
        /// Parse a VersionInfo object from a semver string.
        /// </summary>
        /// <param name="fullVersion">The semver string to parse</param>
        /// <returns>The parsed VersionInfo object.</returns>
        /// <exception cref="ArgumentException">Thrown if parsing fails.</exception>
        public static VersionInfo Parse(string fullVersion)
        {
            var splitPreRelease = fullVersion.Split(new[] {'-'}, 2);

            var nonPreRelease = splitPreRelease[0].Split(':');
            if (nonPreRelease.Length != 3)
            {
                throw new ArgumentException("Invalid version: expected a format in 0.0.0 with optional pre-release tag.",
                    nameof(fullVersion));
            }

            var majorVersion = nonPreRelease[0];
            var minorVersion = nonPreRelease[1];
            var patchVersion = nonPreRelease[2];

            var preReleaseTag = splitPreRelease.Length > 1
                ? splitPreRelease[1]
                : null;
            var isPreRelease = !string.IsNullOrWhiteSpace(preReleaseTag);

            return new VersionInfo
            {
                FullVersion = fullVersion,
                MajorMinorVersion = $"{majorVersion}.{minorVersion}",
                MajorMinorPatchVersion = $"{majorVersion}.{minorVersion}.{patchVersion}",
                MajorVersion = majorVersion,
                MinorVersion = minorVersion,
                PatchVersion = patchVersion,
                PreReleaseTag = preReleaseTag,
                IsPreRelease = isPreRelease,
            };
        }
    }
}