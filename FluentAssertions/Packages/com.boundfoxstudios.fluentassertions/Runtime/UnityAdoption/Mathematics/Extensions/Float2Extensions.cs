using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class Float2Extensions
  {
    public static Float2Assertions Should(this float2 instance) => new(instance);
  }

  public class Float2Assertions : MathematicsAssertions<float2>
  {
    public Float2Assertions(float2 subject) : base(subject) { }
  }
}
