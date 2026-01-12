using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class NullableVector3IntExtensions
  {
    public static NullableVector3IntAssertions Should(this Vector3Int? instance) => new(instance);
  }

  public class NullableVector3IntAssertions : NullableMathematicsAssertions<Vector3Int>
  {
    public NullableVector3IntAssertions(Vector3Int? subject) : base(subject) { }
  }
}
