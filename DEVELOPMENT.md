# Development

This document describes the process for setting up and developing the solution locally.

## Getting started

You will need a compatible `.Net` installation. We recommend at a minimum `.NET 8.0`.

> Note that you will need to install `Mono` if you are developing on MacOS/Linux and want to build/test
> the `net48` target.

### Building the solution

You can use the `dotnet` CLI directly:

```bash
dotnet build -c Release
```

Or simply run the pre-prepared script:
```bash
./build.sh
```

### Testing the solution

The solution consists of both a unit test and integration test project.
At this time, we recommend only running the unit tests locally as the integration test project requires several
environment variables to setup in order to run.

 > The integration tests will be run on all PRs

You can use the `dotnet` CLI directly:

```bash
dotnet test -c Release RyftDotNet/test/RyftDotNet.Tests/RyftDotNet.Tests.csproj
```

Or simply run the pre-prepared script:
```bash
./test.sh
```

Note that the script does not build the project.

### Maintaining Coding Guidelines

We apply linting based on the `.editorconfig` file housed at the root of the project.

You can run the lint via the pre-prepared script:

```bash
./lint.sh
```

Before raising a PR, please ensure you have formatted all code as follows:

```bash
dotnet format
```
