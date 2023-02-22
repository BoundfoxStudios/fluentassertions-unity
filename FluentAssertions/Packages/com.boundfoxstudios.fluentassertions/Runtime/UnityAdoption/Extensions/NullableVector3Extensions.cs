using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class NullableVector3Extensions
  {
    public static NullableVector3Assertions Should(this Vector3? instance) => new(instance);
  }

  public class NullableVector3Assertions : NullableMathematicsAssertions<Vector3>
  {
    public NullableVector3Assertions(Vector3? subject) : base(subject) { }
    protected override bool CalculateApproximately(Vector3 subject, Vector3 expected, float precision) => (subject - expected).sqrMagnitude < precision;
  }
}
