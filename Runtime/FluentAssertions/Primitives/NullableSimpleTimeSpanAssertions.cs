﻿using System;
using System.Diagnostics;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives;

/// <summary>
/// Contains a number of methods to assert that a nullable <see cref="TimeSpan"/> is in the expected state.
/// </summary>
/// <remarks>
/// You can use the <see cref="FluentAssertions.Extensions.FluentTimeSpanExtensions"/>
/// for a more fluent way of specifying a <see cref="TimeSpan"/>.
/// </remarks>
[DebuggerNonUserCode]
public class NullableSimpleTimeSpanAssertions : NullableSimpleTimeSpanAssertions<NullableSimpleTimeSpanAssertions>
{
    public NullableSimpleTimeSpanAssertions(TimeSpan? value)
        : base(value)
    {
    }
}

/// <summary>
/// Contains a number of methods to assert that a nullable <see cref="TimeSpan"/> is in the expected state.
/// </summary>
/// <remarks>
/// You can use the <see cref="FluentAssertions.Extensions.FluentTimeSpanExtensions"/>
/// for a more fluent way of specifying a <see cref="TimeSpan"/>.
/// </remarks>
[DebuggerNonUserCode]
public class NullableSimpleTimeSpanAssertions<TAssertions> : SimpleTimeSpanAssertions<TAssertions>
    where TAssertions : NullableSimpleTimeSpanAssertions<TAssertions>
{
    public NullableSimpleTimeSpanAssertions(TimeSpan? value)
        : base(value)
    {
    }

    /// <summary>
    /// Asserts that a nullable <see cref="TimeSpan"/> value is not <c>null</c>.
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
            .FailWith("Expected a value{reason}.");

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    /// <summary>
    /// Asserts that a nullable <see cref="TimeSpan"/> value is not <c>null</c>.
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
    /// Asserts that a nullable <see cref="TimeSpan"/> value is <c>null</c>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> NotHaveValue(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(!Subject.HasValue)
            .BecauseOf(because, becauseArgs)
            .FailWith("Did not expect a value{reason}, but found {0}.", Subject);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    /// <summary>
    /// Asserts that a nullable <see cref="TimeSpan"/> value is <c>null</c>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> BeNull(string because = "", params object[] becauseArgs)
    {
        return NotHaveValue(because, becauseArgs);
    }

    /// <summary>
    /// Asserts that the value is equal to the specified <paramref name="expected"/> value.
    /// </summary>
    /// <param name="expected">The expected value</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<TAssertions> Be(TimeSpan? expected, string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(Subject == expected)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {0}{reason}, but found {1}.", expected, Subject);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }
}
