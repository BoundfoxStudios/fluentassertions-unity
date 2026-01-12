using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class Int2Extensions
  {
    public static Int2Assertions Should(this int2 instance) => new(instance);
  }

  public class Int2Assertions : MathematicsAssertions<int2>
  {
    public Int2Assertions(int2 subject) : base(subject) { }
  }
}
