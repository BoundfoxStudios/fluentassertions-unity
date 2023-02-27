using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class NullableInt2Extensions
  {
    public static NullableInt2Assertions Should(this int2? instance) => new(instance);
  }

  public class NullableInt2Assertions : NullableMathematicsAssertions<int2>
  {
    public NullableInt2Assertions(int2? subject) : base(subject) { }
  }
}
