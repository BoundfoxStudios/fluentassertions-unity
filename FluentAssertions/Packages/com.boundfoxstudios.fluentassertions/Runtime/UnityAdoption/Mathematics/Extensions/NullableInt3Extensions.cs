using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class NullableInt3Extensions
  {
    public static NullableInt3Assertions Should(this int3? instance) => new(instance);
  }

  public class NullableInt3Assertions : NullableMathematicsAssertions<int3>
  {
    public NullableInt3Assertions(int3? subject) : base(subject) { }
  }
}
