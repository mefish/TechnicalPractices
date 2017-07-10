using Moq;
using NUnit.Framework;
using TDD_With_Async_Await;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await_Tests
{
    [TestFixture]
    public class BusinessLayerTests
    {
        private const string HELLO_WORLD_TEST = "Hello World Test";

        [Test]
        public void WillCallDatabaseTest()
        {
            var helloWorld = new HelloWorld();

            var helloWorldData = new Mock<IHelloWorldData>();

            helloWorldData.Setup(x => x.GetHelloWorld()).Returns(HELLO_WORLD_TEST);

            helloWorld.DataAdapter = helloWorldData.Object;

            var result = helloWorld.GetHelloWorld();

            Assert.AreEqual(HELLO_WORLD_TEST, result);
        }
    }
}