using UnityEngine;

namespace BoundfoxStudios.FluentAssertions
{
  public static class NullableVector4Extensions
  {
    public static NullableVector4Assertions Should(this Vector4? instance) => new(instance);
  }

  public class NullableVector4Assertions : NullableMathematicsAssertions<Vector4>
  {
    public NullableVector4Assertions(Vector4? subject) : base(subject) { }
  }
}
