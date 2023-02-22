using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class Float3Extensions
  {
    public static Float3Assertions Should(this float3 instance) => new(instance);
  }

  public class Float3Assertions : MathematicsAssertions<float3>
  {
    public Float3Assertions(float3 subject) : base(subject) { }

    protected override bool CalculateApproximately(float3 subject, float3 expected, float precision) => math.lengthsq(subject - expected) < precision;
  }
}
