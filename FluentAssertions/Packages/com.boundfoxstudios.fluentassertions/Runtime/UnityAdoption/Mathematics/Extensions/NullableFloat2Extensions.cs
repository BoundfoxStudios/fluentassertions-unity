using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class NullableFloat2Extensions
  {
    public static NullableFloat2Assertions Should(this float2? instance) => new(instance);
  }

  public class NullableFloat2Assertions : NullableMathematicsAssertions<float2>
  {
    public NullableFloat2Assertions(float2? subject) : base(subject) { }
  }
}
