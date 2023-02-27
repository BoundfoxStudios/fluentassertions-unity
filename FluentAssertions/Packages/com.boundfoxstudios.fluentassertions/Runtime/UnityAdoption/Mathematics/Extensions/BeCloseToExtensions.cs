using System;
using BoundfoxStudios.FluentAssertions.Mathematics;
using FluentAssertions;
using FluentAssertions.Execution;
using Unity.Mathematics;
using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class BeCloseToExtensions
  {
    #region BeCloseTo

    public static AndConstraint<MathematicsAssertions<float3>> BeCloseTo(this MathematicsAssertions<float3> parent, float3 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float3>> BeCloseTo(this NullableMathematicsAssertions<float3> parent, float3 other, float maxDistance,
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

      var nonNullableAssertions = new Float3Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float3>> BeCloseTo(this NullableMathematicsAssertions<float3> parent, float3? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<float2>> BeCloseTo(this MathematicsAssertions<float2> parent, float2 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float2>> BeCloseTo(this NullableMathematicsAssertions<float2> parent, float2 other, float maxDistance,
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

      var nonNullableAssertions = new Float2Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float2>> BeCloseTo(this NullableMathematicsAssertions<float2> parent, float2? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<float4>> BeCloseTo(this MathematicsAssertions<float4> parent, float4 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float4>> BeCloseTo(this NullableMathematicsAssertions<float4> parent, float4 other, float maxDistance,
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

      var nonNullableAssertions = new Float4Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float4>> BeCloseTo(this NullableMathematicsAssertions<float4> parent, float4? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<int2>> BeCloseTo(this MathematicsAssertions<int2> parent,int2 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int2>> BeCloseTo(this NullableMathematicsAssertions<int2> parent,int2 other, float maxDistance,
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

      var nonNullableAssertions = new Int2Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int2>> BeCloseTo(this NullableMathematicsAssertions<int2> parent,int2? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<int3>> BeCloseTo(this MathematicsAssertions<int3> parent,int3 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int3>> BeCloseTo(this NullableMathematicsAssertions<int3> parent,int3 other, float maxDistance,
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

      var nonNullableAssertions = new Int3Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int3>> BeCloseTo(this NullableMathematicsAssertions<int3> parent,int3? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<int4>> BeCloseTo(this MathematicsAssertions<int4> parent,int4 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance <= maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int4>> BeCloseTo(this NullableMathematicsAssertions<int4> parent,int4 other, float maxDistance,
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

      var nonNullableAssertions = new Int4Assertions(parent.Subject.Value);
      nonNullableAssertions.BeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int4>> BeCloseTo(this NullableMathematicsAssertions<int4> parent,int4? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<int2>> NotBeCloseTo(this MathematicsAssertions<int2> parent,int2 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int2>> NotBeCloseTo(this NullableMathematicsAssertions<int2> parent,int2 other, float maxDistance,
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

      var nonNullableAssertions = new Int2Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int2>> NotBeCloseTo(this NullableMathematicsAssertions<int2> parent,int2? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<int3>> NotBeCloseTo(this MathematicsAssertions<int3> parent,int3 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int3>> NotBeCloseTo(this NullableMathematicsAssertions<int3> parent,int3 other, float maxDistance,
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

      var nonNullableAssertions = new Int3Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int3>> NotBeCloseTo(this NullableMathematicsAssertions<int3> parent,int3? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<int4>> NotBeCloseTo(this MathematicsAssertions<int4> parent,int4 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int4>> NotBeCloseTo(this NullableMathematicsAssertions<int4> parent,int4 other, float maxDistance,
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

      var nonNullableAssertions = new Int4Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<int4>> NotBeCloseTo(this NullableMathematicsAssertions<int4> parent,int4? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<float2>> NotBeCloseTo(this MathematicsAssertions<float2> parent,float2 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float2>> NotBeCloseTo(this NullableMathematicsAssertions<float2> parent,float2 other, float maxDistance,
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

      var nonNullableAssertions = new Float2Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float2>> NotBeCloseTo(this NullableMathematicsAssertions<float2> parent,float2? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<float3>> NotBeCloseTo(this MathematicsAssertions<float3> parent,float3 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float3>> NotBeCloseTo(this NullableMathematicsAssertions<float3> parent,float3 other, float maxDistance,
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

      var nonNullableAssertions = new Float3Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float3>> NotBeCloseTo(this NullableMathematicsAssertions<float3> parent,float3? other, float maxDistance,
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
    
    public static AndConstraint<MathematicsAssertions<float4>> NotBeCloseTo(this MathematicsAssertions<float4> parent,float4 other, float maxDistance, string because = "",
      params object[] becauseArgs)
    {
      if (maxDistance < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(maxDistance), $"The value of {nameof(maxDistance)} must be non-negative.");
      }

      var difference = other - parent.Subject.Value;
      var distance = math.length(difference);
      FailIfDifferenceOutsidePrecision(distance > maxDistance, parent, other, maxDistance, difference, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float4>> NotBeCloseTo(this NullableMathematicsAssertions<float4> parent,float4 other, float maxDistance,
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

      var nonNullableAssertions = new Float4Assertions(parent.Subject.Value);
      nonNullableAssertions.NotBeCloseTo(other, maxDistance, because, becauseArgs);

      return new(parent);
    }

    public static AndConstraint<NullableMathematicsAssertions<float4>> NotBeCloseTo(this NullableMathematicsAssertions<float4> parent,float4? other, float maxDistance,
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
