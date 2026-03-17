#!/usr/bin/env bash
set -e

dotnet test -c Release -f net8.0 RyftDotNet/test/RyftDotNet.Tests/RyftDotNet.Tests.csproj --no-build --verbosity normal
