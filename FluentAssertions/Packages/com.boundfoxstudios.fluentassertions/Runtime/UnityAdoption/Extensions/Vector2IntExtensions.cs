using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class Vector2IntExtensions
  {
    public static Vector2IntAssertions Should(this Vector2Int instance) => new(instance);
  }

  public class Vector2IntAssertions : MathematicsAssertions<Vector2Int>
  {
    public Vector2IntAssertions(Vector2Int subject) : base(subject) { }
  }
}
