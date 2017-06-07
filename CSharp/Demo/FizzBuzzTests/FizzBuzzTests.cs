using FizzBuzzTDD;
using NUnit.Framework;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestMethod()
        {
            var fizzBuzz = new FizzBuzz();
            Assert.IsNotNull(fizzBuzz);
        }
    }
}
