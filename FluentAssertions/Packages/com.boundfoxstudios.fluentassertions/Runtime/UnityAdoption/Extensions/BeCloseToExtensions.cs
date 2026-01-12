using System;
using FluentAssertions;
using FluentAssertions.Execution;
using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class BeCloseToExtensions
  {
    #region BeCloseTo

    public static AndConstraint<MathematicsAssertions<Vector2>> BeCloseTo(this MathematicsAssertions<Vector2> parent, Vector2 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2>> BeCloseTo(this NullableMathematicsAssertions<Vector2> parent, Vector2 other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector2Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2>> BeCloseTo(this NullableMathematicsAssertions<Vector2> parent, Vector2? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.BeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector3>> BeCloseTo(this MathematicsAssertions<Vector3> parent, Vector3 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3>> BeCloseTo(this NullableMathematicsAssertions<Vector3> parent, Vector3 other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector3Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3>> BeCloseTo(this NullableMathematicsAssertions<Vector3> parent, Vector3? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.BeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector4>> BeCloseTo(this MathematicsAssertions<Vector4> parent, Vector4 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector4>> BeCloseTo(this NullableMathematicsAssertions<Vector4> parent, Vector4 other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector4Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector4>> BeCloseTo(this NullableMathematicsAssertions<Vector4> parent, Vector4? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.BeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector2Int>> BeCloseTo(this MathematicsAssertions<Vector2Int> parent, Vector2Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2Int>> BeCloseTo(this NullableMathematicsAssertions<Vector2Int> parent, Vector2Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector2IntAssertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2Int>> BeCloseTo(this NullableMathematicsAssertions<Vector2Int> parent, Vector2Int? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.BeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector3Int>> BeCloseTo(this MathematicsAssertions<Vector3Int> parent, Vector3Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3Int>> BeCloseTo(this NullableMathematicsAssertions<Vector3Int> parent, Vector3Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector3IntAssertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3Int>> BeCloseTo(this NullableMathematicsAssertions<Vector3Int> parent, Vector3Int? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.BeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    #endregion

    #region NotBeCloseTo

    public static AndConstraint<MathematicsAssertions<Vector2>> NotBeCloseTo(this MathematicsAssertions<Vector2> parent, Vector2 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2>> NotBeCloseTo(this NullableMathematicsAssertions<Vector2> parent, Vector2 other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector2Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2>> NotBeCloseTo(this NullableMathematicsAssertions<Vector2> parent, Vector2? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.NotBeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector3>> NotBeCloseTo(this MathematicsAssertions<Vector3> parent, Vector3 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3>> NotBeCloseTo(this NullableMathematicsAssertions<Vector3> parent, Vector3 other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector3Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3>> NotBeCloseTo(this NullableMathematicsAssertions<Vector3> parent, Vector3? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.NotBeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector4>> NotBeCloseTo(this MathematicsAssertions<Vector4> parent, Vector4 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector4>> NotBeCloseTo(this NullableMathematicsAssertions<Vector4> parent, Vector4 other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector4Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector4>> NotBeCloseTo(this NullableMathematicsAssertions<Vector4> parent, Vector2? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.NotBeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector2Int>> NotBeCloseTo(this MathematicsAssertions<Vector2Int> parent, Vector2Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2Int>> NotBeCloseTo(this NullableMathematicsAssertions<Vector2Int> parent, Vector2Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector2IntAssertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector2Int>> NotBeCloseTo(this NullableMathematicsAssertions<Vector2Int> parent, Vector2Int? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.NotBeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    public static AndConstraint<MathematicsAssertions<Vector3Int>> NotBeCloseTo(this MathematicsAssertions<Vector3Int> parent, Vector3Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = difference.magnitude;
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3Int>> NotBeCloseTo(this NullableMathematicsAssertions<Vector3Int> parent, Vector3Int other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      Execute.Assertion
        .ForCondition(parent.Subject is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", other, maxDistance);

      var nonNullableAssertions = new Vector3IntAssertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<Vector3Int>> NotBeCloseTo(this NullableMathematicsAssertions<Vector3Int> parent, Vector3Int? other, float maxDistance,
      string because = "", params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      if (parent.Subject is null && other is null)
      {
        return new(parent);
      }

      var succeeded = Execute.Assertion
        .ForCondition(other is not null)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to be close to {0} +/- {1}{reason}, but it was {2}.", other, maxDistance, parent.Subject);

      if (succeeded)
      {
        parent.NotBeCloseTo(other.Value, maxDistance, because, becauseArgs);
      }

      return new(parent);
    }

    #endregion

    private static void FailIfDifferenceOutsidePrecision<T>(
      bool differenceWithinPrecision,
      MathematicsAssertions<T> parent, T expectedValue, float precision, T actualDifference,
      string because, object[] becauseArgs)
      where T : struct, IEquatable<T>, IFormattable
    {
      Execute.Assertion
        .ForCondition(differenceWithinPrecision)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:value} to approximate {1} +/- {2}{reason}, but {0} differed by {3}.",
          parent.Subject, expectedValue, precision, actualDifference);
    }
  }
}
