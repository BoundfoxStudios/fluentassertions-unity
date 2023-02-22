using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;
using JetBrains.Annotations;

namespace BoundfoxStudios.FluentAssertions
{
  public abstract class MathematicsAssertions<TSubject> : MathematicsAssertions<TSubject, MathematicsAssertions<TSubject>>
    where TSubject : struct, IEquatable<TSubject>, IFormattable
  {
    protected MathematicsAssertions(TSubject subject) : base(subject) { }
  }

  [DebuggerNonUserCode]
  public abstract class MathematicsAssertions<TSubject, TAssertions>
    where TSubject : struct, IEquatable<TSubject>, IFormattable
    where TAssertions : MathematicsAssertions<TSubject, TAssertions>
  {
    public MathematicsAssertions(TSubject subject) : this((TSubject?)subject) { }

    private protected MathematicsAssertions(TSubject? subject) => Subject = subject;

    /// <summary>
    ///   Gets the object which value is being asserted.
    /// </summary>
    public TSubject? Subject { get; }

    public AndConstraint<TAssertions> Be(TSubject expected, string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(Subject?.Equals(expected) == true)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> Be(TSubject? expected, string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(expected is { } value ? Subject?.Equals(value) == true : !Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> NotBe(TSubject unexpected, string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(Subject?.Equals(unexpected) == false)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(unexpected), unexpected, Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> NotBe(TSubject? unexpected, string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(unexpected is { } value ? Subject?.Equals(value) == false : Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(unexpected), unexpected, Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> BeOneOf(params TSubject[] validValues) => BeOneOf(validValues, string.Empty);

    public AndConstraint<TAssertions> BeOneOf(IEnumerable<TSubject> validValues, string because = "",
      params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(Subject is { } value && validValues.Contains(value))
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be one of {0}{reason}, but found {1}.", validValues, Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> BeApproximately(TSubject expected, float precision, string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(Subject is { } value && CalculateApproximately(value, expected, precision))
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> BeOfType(Type expectedType, string because = "", params object[] becauseArgs)
    {
      Guard.AgainstNull(expectedType, nameof(expectedType));

      var subjectType = Subject?.GetType();
      if (expectedType.IsGenericTypeDefinition && subjectType?.IsGenericType == true)
      {
        subjectType.GetGenericTypeDefinition().Should().Be(expectedType, because, becauseArgs);
      }
      else
      {
        subjectType.Should().Be(expectedType, because, becauseArgs);
      }

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> NotBeOfType(Type unexpectedType, string because = "", params object[] becauseArgs)
    {
      Guard.AgainstNull(unexpectedType, nameof(unexpectedType));

      Execute.Assertion
        .ForCondition(Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected type not to be " + unexpectedType + "{reason}, but found <null>.");

      Subject.GetType().Should().NotBe(unexpectedType, because, becauseArgs);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> Match(Expression<Func<TSubject, bool>> predicate,
      string because = "",
      params object[] becauseArgs)
    {
      Guard.AgainstNull(predicate, nameof(predicate));

      Execute.Assertion
        .ForCondition(predicate.Compile()((TSubject)Subject))
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to match {0}{reason}, but found {1}.", predicate.Body, Subject);

      return new((TAssertions)this);
    }

    protected abstract bool CalculateApproximately(TSubject subject, TSubject expected, float precision);

    [CanBeNull]
    private protected virtual string CalculateDifferenceForFailureMessage(TSubject subject, TSubject expected) => null;

    private string GenerateDifferenceMessage(TSubject? expected)
    {
      const string noDifferenceMessage = ".";

      if (Subject is not { } subject || expected is not { } expectedValue)
      {
        return noDifferenceMessage;
      }

      var difference = CalculateDifferenceForFailureMessage(subject, expectedValue);
      return difference is null ? noDifferenceMessage : $" (difference of {difference}";
    }
  }
}
