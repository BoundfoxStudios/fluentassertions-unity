using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class Int3Extensions
  {
    public static Int3Assertions Should(this int3 instance) => new(instance);
  }

  public class Int3Assertions : MathematicsAssertions<int3>
  {
    public Int3Assertions(int3 subject) : base(subject) { }
  }
}
