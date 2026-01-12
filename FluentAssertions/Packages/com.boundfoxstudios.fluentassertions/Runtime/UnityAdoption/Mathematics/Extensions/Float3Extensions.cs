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
  }
}
