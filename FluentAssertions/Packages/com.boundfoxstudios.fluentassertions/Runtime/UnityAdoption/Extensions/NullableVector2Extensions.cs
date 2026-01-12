using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class NullableVector2Extensions
  {
    public static NullableVector2Assertions Should(this Vector2? instance) => new(instance);
  }

  public class NullableVector2Assertions : NullableMathematicsAssertions<Vector2>
  {
    public NullableVector2Assertions(Vector2? subject) : base(subject) { }
  }
}
