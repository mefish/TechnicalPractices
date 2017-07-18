using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await
{
    public class SimpleAuthenticationServerApi : ISimpleAuthenticationApi
    {
        public IHelloWorldData DataAdapter { get; set; }

        public async Task<string> GetHelloWorld()
        {
            var helloWorld = await DataAdapter.GetHelloWorld();
            return helloWorld;
        }

        public async Task<IPostResult> CreateUser(string loginName)
        {
            await DataAdapter.CreateUser(loginName);
            return new PostResult();
        }
    }
}