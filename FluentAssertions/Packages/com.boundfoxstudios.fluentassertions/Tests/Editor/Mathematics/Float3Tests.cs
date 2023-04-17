using FluentAssertions;
using NUnit.Framework;
using Unity.Mathematics;

namespace BoundfoxStudios.FluentAssertions.Mathematics.Editor.Tests
{
  public class Float3Tests
  {
    [Test]
    public void Float3BePasses()
    {
      var v1 = new float3(1, 2, 3);
      var expected = new float3(1, 2, 3);

      v1.Should().Be(expected);
    }

    [Test]
    public void Float3BeShouldMatchExactly()
    {
      var v1 = new float3(2, 4, 6);
      var expected = new float3(0.267261237f, 0.534522474f, 0.801783681f);
      
      var normalized = math.normalize(v1);
      normalized.Should().Be(expected);
    }
    
    [Test]
    public void Float3BeApproximatelyPasses()
    {
      var v1 = new float3(2, 4, 6);
      var expected = new float3(0.2672612f, 0.5345225f, 0.8017837f);
      
      var normalized = math.normalize(v1);
      normalized.Should().BeCloseTo(expected, 0.5f);
    }
  }
}
