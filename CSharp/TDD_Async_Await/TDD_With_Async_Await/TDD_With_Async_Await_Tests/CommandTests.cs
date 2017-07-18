using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TDD_With_Async_Await;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await_Tests
{
    [TestFixture]
    internal class CommandTests
    {
        private const string HELLO_WORLD = "Hello, World!";

        [Test]
        public void CanTestUserInterfaceWithTestCommand()
        {
            var testCommand = new TestAuthenticationCommand();

            var helloWorldApi = new Mock<ISimpleAuthenticationApi>();

            helloWorldApi.Setup(x => x.GetHelloWorld()).Returns(Task.FromResult(HELLO_WORLD));

            var result = testCommand.Execute();

            Assert.AreEqual(HELLO_WORLD, result);
        }

        [Test]
        public void CanCreateUserCommand()
        {
            var command = new CreateUserCommand
                          {
                              LoginName = "johndoe"
                          };

            var helloWorldApi = new Mock<ISimpleAuthenticationApi>();

            helloWorldApi.Setup(x => x.CreateUser("johndoe")).Returns(Task.FromResult(Mock.Of<IPostResult>()));

            command.SimpleAuthenticationApi = helloWorldApi.Object;

            command.Execute();

            helloWorldApi.VerifyAll();
        }
    }
}