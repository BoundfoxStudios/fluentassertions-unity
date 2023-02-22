using NUnit.Framework;
using UnityEngine;

namespace BoundfoxStudios.FluentAssertions.Editor.Tests
{
  public class Vector3Tests
  {
    [Test]
    public void Vector3BePasses()
    {
      var v1 = new Vector3(1, 2, 3);
      var expected = new Vector3(1, 2, 3);

      v1.Should().Be(expected);
    }

    [Test]
    public void Vector3BeShouldMatchExactly()
    {
      var v1 = new Vector3(2, 4, 6);
      var expected = new Vector3(0.267261237f, 0.534522474f, 0.801783681f);

      var normalized = v1.normalized;
      normalized.Should().Be(expected);
    }
    
    [Test]
    public void Vector3BeApproximatelyPasses()
    {
      var v1 = new Vector3(2, 4, 6);
      var expected = new Vector3(0.2672612f, 0.5345225f, 0.8017837f);

      var normalized = v1.normalized;
      normalized.Should().BeApproximately(expected, 0.5f);
    }
  }
}
