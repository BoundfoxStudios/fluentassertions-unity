using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics
{
  public static class Int4Extensions
  {
    public static Int4Assertions Should(this int4 instance) => new(instance);
  }

  public class Int4Assertions : MathematicsAssertions<int4>
  {
    public Int4Assertions(int4 subject) : base(subject) { }
  }
}
