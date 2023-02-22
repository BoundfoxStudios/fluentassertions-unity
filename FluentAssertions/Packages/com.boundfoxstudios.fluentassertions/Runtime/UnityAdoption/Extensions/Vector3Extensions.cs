using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class Vector3Extensions
  {
    public static Vector3Assertions Should(this Vector3 instance) => new(instance);
  }

  public class Vector3Assertions : MathematicsAssertions<Vector3>
  {
    public Vector3Assertions(Vector3 subject) : base(subject) { }
    protected override bool CalculateApproximately(Vector3 subject, Vector3 expected, float precision) => (subject - expected).sqrMagnitude < precision;
  }
}
