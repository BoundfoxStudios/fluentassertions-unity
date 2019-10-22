using NUnit.Framework;

namespace FluentAssertions.Examples.Tests {
    public class FluentAssertionTests
    {
        [Test]
        public void This_test_will_throw()
        {
            var one = 1;

            one.Should().Be(2);
        }
    }
}
