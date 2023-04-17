using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class NullableVector2IntExtensions
  {
    public static NullableVector2IntAssertions Should(this Vector2Int? instance) => new(instance);
  }

  public class NullableVector2IntAssertions : NullableMathematicsAssertions<Vector2Int>
  {
    public NullableVector2IntAssertions(Vector2Int? subject) : base(subject) { }
  }
}
