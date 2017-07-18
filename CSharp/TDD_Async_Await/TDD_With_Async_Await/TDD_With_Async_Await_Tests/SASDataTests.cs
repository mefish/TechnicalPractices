using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using TDD_With_Async_Await_Common;
using TDD_With_Async_Await_Data;

namespace SAS_UnitTests
{
    [TestFixture]
    internal class HelloWorldDataTests
    {
        [Test]
        public void OnCreateUserWillReturnATask()
        {
            var helloWorldData = new SimpleAuthenticationJsonDataRepository();

            var fileReader = new Mock<IFileReader>();

            helloWorldData.FileReader = fileReader.Object;

            var result = helloWorldData.StoreUser("jsmith");

            Assert.IsTrue(result.IsCompleted);
        }

        [Test]
        public void OnCreateUserWillWriteJsonToFile()
        {
            var helloWorldData = new SimpleAuthenticationJsonDataRepository();

            var fileReader = new Mock<IFileReader>();

            helloWorldData.FileReader = fileReader.Object;

            var userInformation = new UserInformation
                                  {
                                      LoginName = "jsmith"
                                  };

            var json = JsonConvert.SerializeObject(userInformation);

            fileReader.Setup(x => x.WriteToFile(json));

            helloWorldData.StoreUser("jsmith");

            fileReader.VerifyAll();
        }
    }
}