#tool "nuget:?package=xunit.runner.console"
#addin "Cake.FileHelpers"

// var Project = Directory("../source/Syncromatics.Cake.GoGitVer/");
// var TestProject = Directory("../source/Syncromatics.Cake.GoGitVer.Tests/");
// var CakeGoGitVerProj = Project + File("Syncromatics.Cake.GoGitVer.csproj");
// var CakeTestGoGitVerAssembly = TestProject + Directory("bin/Release") + File("Syncromatics.Cake.GoGitVer.Tests.dll");
// var CakeGoGitVerSln = File("../source/Syncromatics.Cake.GoGitVer.sln");

var solution = "../source/Syncromatics.Cake.GoGitVer.sln";
var nupkg = Directory("../source/nupkg");

var configuration = Argument("Configuration", "Release");
var target = Argument("target", "Default");
var tag = EnvironmentVariable("APPVEYOR_REPO_TAG_NAME");
var version = !string.IsNullOrEmpty(tag) ? tag : "0.0.0";

Task("Default")
	.Does(() =>
	{
		DotNetCoreRestore(solution);
		DotNetCoreBuild(solution, new DotNetCoreBuildSettings
		{
			Configuration = configuration,
			ArgumentCustomization = args => args.Append($"/property:Version={version}"),
			NoRestore = true,
		});
	});

Task("UnitTest")
	.IsDependentOn("Default")
	.Does(() =>
	{
	  var testProjects = GetFiles("../source/**/*.Tests.csproj");
		foreach (var project in testProjects)
		{
			DotNetCoreTest(project.FullPath, new DotNetCoreTestSettings
			{
					Configuration = configuration,
					NoBuild = true,
			});
		}
	});

// Task("NuGetPack")
// 	.IsDependentOn("Default")
// 	.IsDependentOn("UnitTest")
// 	.Does (() =>
// 	{
// 		CreateDirectory(nupkg);
// 		DotNetCorePack(CakeGoGitVerProj, new DotNetCorePackSettings
// 		{
// 			Configuration = "Release",
// 			OutputDirectory = nupkg,
// 			ArgumentCustomization = args => args.Append($"/property:Version={version}"),
// 			NoBuild = true,
// 			NoRestore = true,
// 		});
// 	});

// Task("NuGetPush")
// 	.IsDependentOn("NuGetPack")
// 	.Does(() =>
// 	{
// 		if (EnvironmentVariable("APPVEYOR_REPO_TAG") != "true") return;

//         var settings = new DotNetCoreNuGetPushSettings
//         {
//             Source = "https://www.nuget.org/api/v2/package",
//             ApiKey = EnvironmentVariable("NUGET_API_KEY"),
//         };

//         DotNetCoreNuGetPush(nupkg + File($"./Syncromatics.Cake.GoGitVer.{version}.nupkg"), settings);
// 	});

RunTarget (target);
