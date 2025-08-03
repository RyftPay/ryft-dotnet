#!/usr/bin/env bash
set -e

dotnet test -c Release RyftDotNet/test/RyftDotNet.Tests/RyftDotNet.Tests.csproj --no-build --verbosity normal
