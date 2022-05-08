#!/usr/bin/env bash

# Sync master sources
rsync --recursive --delete --exclude "*.csproj" --exclude "*.snk" fluentassertions-master/Src/FluentAssertions FluentAssertions/Packages/com.boundfoxstudios.fluentassertions/Runtime/

# Remove files which we adopt in Unity
rm FluentAssertions/Packages/com.boundfoxstudios.fluentassertions/Runtime/FluentAssertions/Common/AppSettingsConfigurationStore.cs
