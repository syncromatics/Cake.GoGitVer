using FluentAssertions;
using Xunit;
using Syncromatics.Cake.GoGitVer.CurrentVersion;

namespace Syncromatics.Cake.GoGitVer.Tests.CurrentVersion
{
    public class CurrentVersionTest
    {
		[Fact]
        public void ShouldGetVersionWithDefaultSettings()
        {
            var fixture = new CurrentVersionFixture();
            var actual = fixture.Run();

            const string expected = "some testing";
            actual.Args.Should().Be(expected);
        }

		[Fact]
        public void ShouldGetVersionWithAllSettings()
        {
            var fixture = new CurrentVersionFixture
            {
                Settings = new GoGitVerCurrentVersionSettings
                {
                    Path = "./some_path",
                    Settings = "./some_gogitver.yaml",
                }
            };
            var actual = fixture.Run();

            const string expected = @"--path ""./some_path"" --settings ""./some_gogitver.yaml""";
            actual.Args.Should().Be(expected);
        }
    }
}