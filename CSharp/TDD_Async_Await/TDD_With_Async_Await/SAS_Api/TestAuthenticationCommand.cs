using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await
{
    public class TestAuthenticationCommand
    {
        public Task<string> Execute()
        {
            return SimpleAuthenticationApi.GetHelloWorld();
        }

        public ISimpleAuthenticationDataStore SimpleAuthenticationApi { get; set; }
    }
}