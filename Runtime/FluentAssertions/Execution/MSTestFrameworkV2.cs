﻿namespace FluentAssertions.Execution;

internal class MSTestFrameworkV2 : LateBoundTestFramework
{
    protected override string ExceptionFullName => "Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException";

    protected internal override string AssemblyName => "Microsoft.VisualStudio.TestPlatform.TestFramework";
}
