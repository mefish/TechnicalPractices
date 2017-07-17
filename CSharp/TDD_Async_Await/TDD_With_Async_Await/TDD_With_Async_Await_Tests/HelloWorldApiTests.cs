using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TDD_With_Async_Await;
using TDD_With_Async_Await_Common;
using TDD_With_Async_Await_Data;

namespace SAS_UnitTests
{
    [TestFixture]
    public class HelloWorldApiTests
    {
        private const string HELLO_WORLD_TEST = "Hello World Test";

        [Test]
        public void WillCallDatabaseTest()
        {
            var helloWorld = new HelloWorldApi();

            var helloWorldData = new Mock<IHelloWorldData>();

            helloWorldData.Setup(x => x.GetHelloWorld()).Returns(Task.FromResult(HELLO_WORLD_TEST));

            helloWorld.DataAdapter = helloWorldData.Object;

            var result = helloWorld.GetHelloWorld();

            Assert.AreEqual(HELLO_WORLD_TEST, result.Result);
        }

        [Test]
        public async Task CanCreateAUser()
        {
            var helloWorld = new HelloWorldApi();

            var helloWorldData = new Mock<IHelloWorldData>();

            var userData = new UserInformation
                           {
                               LoginName = "Login name",
                               UserName = "Tammy Smith"
                           };

            helloWorldData.Setup(x => x.CreateUser(userData.LoginName, userData.UserName)).Returns(Task.CompletedTask);

            helloWorld.DataAdapter = helloWorldData.Object;

            var result = await helloWorld.CreateUser(userData.LoginName, userData.UserName);

            Assert.IsTrue(result.WasSuccessful);
        }
    }
}