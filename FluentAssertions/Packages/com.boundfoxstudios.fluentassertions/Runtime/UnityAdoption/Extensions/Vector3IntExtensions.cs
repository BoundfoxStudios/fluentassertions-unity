using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class Vector3IntExtensions
  {
    public static Vector3IntAssertions Should(this Vector3Int instance) => new(instance);
  }

  public class Vector3IntAssertions : MathematicsAssertions<Vector3Int>
  {
    public Vector3IntAssertions(Vector3Int subject) : base(subject) { }
  }
}
