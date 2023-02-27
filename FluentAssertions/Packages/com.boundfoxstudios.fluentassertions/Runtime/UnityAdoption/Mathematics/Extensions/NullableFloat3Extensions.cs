using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class NullableFloat3Extensions
  {
    public static NullableFloat3Assertions Should(this float3? instance) => new(instance);
  }

  public class NullableFloat3Assertions : NullableMathematicsAssertions<float3>
  {
    public NullableFloat3Assertions(float3? subject) : base(subject) { }
  }
}
