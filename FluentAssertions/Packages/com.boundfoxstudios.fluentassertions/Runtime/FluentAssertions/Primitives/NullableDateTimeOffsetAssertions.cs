﻿using System;
using System.Diagnostics;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives {

/// <summary>
/// Contains a number of methods to assert that a nullable <see cref="DateTimeOffset"/> is in the expected state.
/// </summary>
/// <remarks>
/// You can use the <see cref="FluentAssertions.Extensions.FluentDateTimeExtensions"/>
/// for a more fluent way of specifying a <see cref="DateTime"/>.
/// </remarks>
[DebuggerNonUserCode]
public class NullableDateTimeOffsetAssertions : NullableDateTimeOffsetAssertions<NullableDateTimeOffsetAssertions>
{
    public NullableDateTimeOffsetAssertions(DateTimeOffset? expected)
        : base(expected)
    {
    }
}

/// <summary>
/// Contains a number of methods to assert that a nullable <see cref="DateTimeOffset"/> is in the expected state.
/// </summary>
/// <remarks>
/// You can use the <see cref="FluentAssertions.Extensions.FluentDateTimeExtensions"/>
/// for a more fluent way of specifying a <see cref="DateTime"/>.
/// </remarks>
[DebuggerNonUserCode]
public class NullableDateTimeOffsetAssertions<TAssertions> : DateTimeOffsetAssertions<TAssertions>
    where TAssertions : NullableDateTimeOffsetAssertions<TAssertions>
{
    public NullableDateTimeOffsetAssertions(DateTimeOffset? expected)
        : base(expected)
    {
    }

    /// <summary>
    /// Asserts that a nullable <see cref="DateTimeOffset"/> value is not <c>null</c>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> HaveValue(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(Subject.HasValue)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context:variable} to have a value{reason}, but found {0}", Subject);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    /// <summary>
    /// Asserts that a nullable <see cref="DateTimeOffset"/> value is not <c>null</c>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> NotBeNull(string because = "", params object[] becauseArgs)
    {
        return HaveValue(because, becauseArgs);
    }

    /// <summary>
    /// Asserts that a nullable <see cref="DateTimeOffset"/> value is <c>null</c>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> NotHaveValue(string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(!Subject.HasValue)
            .BecauseOf(because, becauseArgs)
            .FailWith("Did not expect {context:variable} to have a value{reason}, but found {0}", Subject);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    /// <summary>
    /// Asserts that a nullable <see cref="DateTimeOffset"/> value is <c>null</c>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> BeNull(string because = "",
        params object[] becauseArgs)
    {
        return NotHaveValue(because, becauseArgs);
    }
}
}