using System;
using System.Diagnostics;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BoundfoxStudios.FluentAssertions
{
  [DebuggerNonUserCode]
  public abstract class NullableMathematicsAssertions<TSubject> : MathematicsAssertions<TSubject, NullableMathematicsAssertions<TSubject>>
    where TSubject : struct, IEquatable<TSubject>, IFormattable
  {
    public NullableMathematicsAssertions(TSubject? subject) : base(subject) { }
  }

  [DebuggerNonUserCode]
  public abstract class NullableMathematicsAssertions<TSubject, TAssertions> : MathematicsAssertions<TSubject, TAssertions>
    where TSubject : struct, IEquatable<TSubject>, IFormattable
    where TAssertions : NullableMathematicsAssertions<TSubject, TAssertions>
  {
    public NullableMathematicsAssertions(TSubject? subject) : base(subject) { }

    public AndConstraint<TAssertions> HaveValue(string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected a value{reason}.");

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> NotBeNull(string because = "", params object[] becauseArgs) => HaveValue(because, becauseArgs);

    public AndConstraint<TAssertions> NotHaveValue(string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(!Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Did not expect a value{reason}, but found {0}.", Subject);

      return new((TAssertions)this);
    }

    public AndConstraint<TAssertions> BeNull(string because = "", params object[] becauseArgs) => NotHaveValue(because, becauseArgs);

    public AndConstraint<TAssertions> Match(Expression<Func<TSubject?, bool>> predicate,
      string because = "",
      params object[] becauseArgs)
    {
      Guard.AgainstNull(predicate, nameof(predicate));

      Execute.Assertion
        .ForCondition(predicate.Compile()(Subject))
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected value to match {0}{reason}, but found {1}.", predicate, Subject);

      return new((TAssertions)this);
    }
  }
}
