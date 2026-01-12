using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class Float4Extensions
  {
    public static Float4Assertions Should(this float4 instance) => new(instance);
  }

  public class Float4Assertions : MathematicsAssertions<float4>
  {
    public Float4Assertions(float4 subject) : base(subject) { }
  }
}
