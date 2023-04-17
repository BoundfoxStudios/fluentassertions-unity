using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class Vector4Extensions
  {
    public static Vector4Assertions Should(this Vector4 instance) => new(instance);
  }

  public class Vector4Assertions : MathematicsAssertions<Vector4>
  {
    public Vector4Assertions(Vector4 subject) : base(subject) { }
  }
}
