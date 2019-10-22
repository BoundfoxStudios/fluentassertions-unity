# Fluent Assertions for Unity

This package contains the current version of FluentAssertions 5.9.0 ready to use with Unity.

The code of this package can also be found on GitHub: https://github.com/manuelrauber/fluentassertions-unity.
If you encouter any bugs, which are related to the package and not to FluentAssertions itself, feel free to open an issue. 

For more information about FluentAssertions itself, please head over to https://fluentassertions.com.

## Pre-requirements

* Unity 2018.3 or newer
* .NET Standard 2.0 scripting backend
* NETSTANDARD2_0 scripting symbol set

## Installation
Simply install the package, reference FluentAssertions in your test's assembly definition and you are good to go!

## Notice for Unity < 2019
When importing the package into Unity < 2019, do not import the examples folder, since it uses the new Unity Test Framework package.
However, FluentAssertions itself is working.
