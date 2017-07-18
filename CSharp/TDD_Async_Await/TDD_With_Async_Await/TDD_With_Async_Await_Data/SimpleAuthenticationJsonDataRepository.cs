using System.Threading.Tasks;
using Newtonsoft.Json;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await_Data
{
    public class SimpleAuthenticationJsonDataRepository
    {
        public IFileReader FileReader { get; set; }

        public Task StoreUser(string loginName)
        {
            var userInformation = new UserInformation
                                  {
                                      LoginName = loginName
                                  };

            var json = JsonConvert.SerializeObject(userInformation);

            FileReader.WriteToFile(json);

            return Task.CompletedTask;
        }
    }
}