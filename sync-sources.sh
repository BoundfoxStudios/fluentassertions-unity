#!/usr/bin/env bash

# Sync master sources
rsync --recursive --delete --exclude "*.csproj" --exclude "*.snk" fluentassertions-master/Src/FluentAssertions FluentAssertions/Assets/FluentAssertions

# Remove files which we adopt in Unity
rm FluentAssertions/Assets/FluentAssertions/FluentAssertions/Common/AppSettingsConfigurationStore.cs
