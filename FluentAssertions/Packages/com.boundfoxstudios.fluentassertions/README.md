[![openupm](https://img.shields.io/npm/v/com.boundfoxstudios.fluentassertions?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.boundfoxstudios.fluentassertions/)

# Fluent Assertions for Unity

This package contains the current version of FluentAssertions 5.10.3 ready to use with Unity.

If you encouter any bugs, which are related to the package and not to FluentAssertions itself, feel free to open an issue. 

For more information about FluentAssertions itself, please head over to https://fluentassertions.com.

## Pre-requirements

* Unity 2018.3 or newer
* .NET Standard 2.0 scripting backend
* NETSTANDARD2_0 scripting symbol set

## Installation

### OpenUPM

The package is available on the [openupm registry](https://openupm.com). It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.boundfoxstudios.fluentassertions-unity
```

### Unity Package Manager

Window -> Package Manager -> + sign -> Add via git url:

```
https://github.com/BoundfoxStudios/fluentassertions-unity.git#upm
```

## Setup

Then, reference FluentAssertions in your test's assembly definition and you are good to go!

## Notice for Unity < 2019
When importing the package into Unity < 2019, do not import the examples folder, since it uses the new Unity Test Framework package.
However, FluentAssertions itself is working.

## Credits

All credits go to [FluentAssertions](https://fluentassertions.com) for creating an excellent library to make Unit Testing more readable and maintainable.
