using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class NullableInt4Extensions
  {
    public static NullableInt4Assertions Should(this int4? instance) => new(instance);
  }

  public class NullableInt4Assertions : NullableMathematicsAssertions<int4>
  {
    public NullableInt4Assertions(int4? subject) : base(subject) { }
  }
}
