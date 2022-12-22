﻿using System.Globalization;

namespace FluentAssertions.Formatting {

public class UInt64ValueFormatter : IValueFormatter
{
    /// <summary>
    /// Indicates whether the current <see cref="IValueFormatter"/> can handle the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value for which to create a <see cref="string"/>.</param>
    /// <returns>
    /// <c>true</c> if the current <see cref="IValueFormatter"/> can handle the specified value; otherwise, <c>false</c>.
    /// </returns>
    public bool CanHandle(object value)
    {
        return value is ulong;
    }

    public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
    {
        formattedGraph.AddFragment(((ulong)value).ToString(CultureInfo.InvariantCulture) + "UL");
    }
}
}