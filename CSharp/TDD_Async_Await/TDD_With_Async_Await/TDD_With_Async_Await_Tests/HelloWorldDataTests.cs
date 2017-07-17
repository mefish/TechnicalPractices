using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TDD_With_Async_Await_Common;
using TDD_With_Async_Await_Data;

namespace SAS_UnitTests
{
    [TestFixture]
    internal class HelloWorldDataTests
    {
        [Test]
        public void CanRetrieveUserInformationByUserNameSuccess()
        {
            var helloWorldData = new HelloWorldDataRepository();

            var fileReader = new Mock<IFileReader>();

            helloWorldData.FileReader = fileReader.Object;

            var userInformation = new UserInformation
                                  {
                                      LoginName = "jsmith",
                                      UserName = "John Smith"
                                  };

            fileReader.Setup(x => x.GetUserInformation()).Returns(Task.FromResult(userInformation));

            var result = helloWorldData.GetUserinformationForUserName("jsmith");

            Assert.AreEqual(userInformation.UserName, result.UserName);
        }
    }
}