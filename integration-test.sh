#!/usr/bin/env bash
set -e

dotnet test -c Release --filter 'FullyQualifiedName~IntegrationTests' --no-build --verbosity normal
