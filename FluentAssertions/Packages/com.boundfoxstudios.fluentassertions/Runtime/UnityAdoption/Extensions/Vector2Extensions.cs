using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class Vector2Extensions
  {
    public static Vector2Assertions Should(this Vector2 instance) => new(instance);
  }

  public class Vector2Assertions : MathematicsAssertions<Vector2>
  {
    public Vector2Assertions(Vector2 subject) : base(subject) { }
  }
}
