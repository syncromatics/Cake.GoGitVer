# Syncromatics.Cake.GoGitVer

This Cake AddIn extends Cake with [gogitver](https://github.com/annymsMthd/gogitver)  functionality.
Use it to easily semantically version your projects across all platforms with specially-formed
commit messages.

## Quickstart

Add this addin to your Cake script:

```chsarp
#addin "Syncromatics.Cake.GoGitVer"
```

Then use it to retrieve a version:

```csharp
var versionInfo = GoGitVer.GetCurrentVersion();

var fullSemVer = VersionInfo.FullVersion;
var majorVersion = VersionInfo.MajorVersion;
var preReleaseTag = VersionInfo.PreReleaseTag;
```

Other parsed properties are available -- see the XMLDoc comments on VersionInfo for comprehensive
descriptions.

## Building

[![Travis](https://img.shields.io/travis/syncromatics/Cake.GoGitVer.svg)](https://travis-ci.org/syncromatics/Cake.GoGitVer)
[![NuGet](https://img.shields.io/nuget/v/.svg)](https://www.nuget.org/packages//)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/.svg)](https://www.nuget.org/packages//)

This project is built using the Cake scripts located in the `ci-script` folder.

### On Windows

```powershell
cd ci-script
./build.ps1
```

### On Linux

```bash
cd ci-script
./build.sh
```

## Code of Conduct

We are committed to fostering an open and welcoming environment. Please read our [code of conduct](CODE_OF_CONDUCT.md) before participating in or contributing to this project.

## Contributing

We welcome contributions and collaboration on this project. Please read our [contributor's guide](CONTRIBUTING.md) to understand how best to work with us.

## License and Authors

[![GMV Syncromatics Engineering logo](https://secure.gravatar.com/avatar/645145afc5c0bc24ba24c3d86228ad39?size=16) GMV Syncromatics Engineering](https://github.com/syncromatics)

[![license](https://img.shields.io/github/license/syncromatics/Cake.GoGitVer.svg)](https://github.com/syncromatics/Cake.GoGitVer/blob/master/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/syncromatics/Cake.GoGitVer.svg)](https://github.com/syncromatics/Cake.GoGitVer/graphs/contributors)

This software is made available by GMV Syncromatics Engineering under the MIT license.
