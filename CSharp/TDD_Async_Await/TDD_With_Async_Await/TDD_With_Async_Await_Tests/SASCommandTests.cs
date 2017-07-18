using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TDD_With_Async_Await;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await_Tests
{
    [TestFixture]
    internal class SASCommandTests
    {
        private const string HELLO_WORLD = "Hello, World!";
        private const string USER_LOGIN_NAME = "johndoe";

        [Test]
        public void CanTestUserInterfaceWithTestCommand()
        {
            var testCommand = new TestAuthenticationCommand();

            var helloWorldApi = new Mock<ISimpleAuthenticationDataStore>();

            helloWorldApi.Setup(x => x.GetHelloWorld()).Returns(Task.FromResult(HELLO_WORLD));

            testCommand.SimpleAuthenticationApi = helloWorldApi.Object;

            var result = testCommand.Execute();

            Assert.AreEqual(HELLO_WORLD, result.Result);
        }

        [Test]
        public void CanCreateUserCommand()
        {
            var command = new CreateUserCommand
                          {
                              LoginName = USER_LOGIN_NAME
                          };

            var helloWorldApi = new Mock<ISimpleAuthenticationDataStore>();

            helloWorldApi.Setup(x => x.CreateUser(USER_LOGIN_NAME)).Returns(Task.FromResult(Mock.Of<IPostResult>()));

            command.SimpleAuthenticationApi = helloWorldApi.Object;

            command.Execute();

            helloWorldApi.VerifyAll();
        }

        [Test]
        public void WhenCreatingUserTaskWillBeSuccessful()
        {
            var command = new CreateUserCommand()
                          {
                              LoginName = USER_LOGIN_NAME
                          };
            var helloWorldApi = new Mock<ISimpleAuthenticationDataStore>();

            helloWorldApi.Setup(x => x.CreateUser(USER_LOGIN_NAME)).Returns(Task.FromResult(Mock.Of<IPostResult>()));

            command.SimpleAuthenticationApi = helloWorldApi.Object;

            var result = command.Execute();

            Assert.IsTrue(result.IsCompleted);
        }
    }
}