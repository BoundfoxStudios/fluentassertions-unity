using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class NullableFloat4Extensions
  {
    public static NullableFloat4Assertions Should(this float4? instance) => new(instance);
  }

  public class NullableFloat4Assertions : NullableMathematicsAssertions<float4>
  {
    public NullableFloat4Assertions(float4? subject) : base(subject) { }
  }
}
