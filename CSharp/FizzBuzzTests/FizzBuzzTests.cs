using FizzBuzzTDD;
using NUnit.Framework;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void TestMethod(int number, string expectedResult)
        {
            var result = _fizzBuzz.GetFizzAndOrBuzz(number);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
