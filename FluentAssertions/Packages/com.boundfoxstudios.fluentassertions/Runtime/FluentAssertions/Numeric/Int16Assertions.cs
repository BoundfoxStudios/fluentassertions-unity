﻿using System.Diagnostics;
using System.Globalization;

namespace FluentAssertions.Numeric {

/// <summary>
/// Contains a number of methods to assert that a <see cref="short"/> is in the expected state.
/// </summary>
[DebuggerNonUserCode]
internal class Int16Assertions : NumericAssertions<short>
{
    internal Int16Assertions(short value)
        : base(value)
    {
    }

    private protected override string CalculateDifferenceForFailureMessage(short subject, short expected)
    {
        if (subject < 10 && expected < 10)
        {
            return null;
        }

        int difference = subject - expected;
        return difference != 0 ? difference.ToString(CultureInfo.InvariantCulture) : null;
    }
}
}