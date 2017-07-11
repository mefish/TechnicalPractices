using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TDD_With_Async_Await_Common;
using TDD_With_Async_Await_Data;

namespace TDD_With_Async_Await_Tests
{
    [TestFixture]
    class HelloWorldDataTests
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
                                      UserName = "John Smith",
                                  };

            fileReader.Setup(x => x.GetUserInformation()).Returns(Task.FromResult(userInformation));

            var result = helloWorldData.GetUserinformationForUserName("jsmith");

            Assert.AreEqual(userInformation.UserName, result.UserName);
        }
    }
}
