using NUnit.Framework;

namespace FluentAssertions.Examples.Tests {
    public class FluentAssertionTests
    {
        [Test]
        public void This_test_will_throw()
        {
            const string someString = "This test is now";
            someString.Should().Be("better readable");
        }

        [Test]
        public void Old_test_assert_will_throw()
        {
            const string someString = "This test is not good";
            Assert.AreEqual("good readable", someString);
        }
    }
}
