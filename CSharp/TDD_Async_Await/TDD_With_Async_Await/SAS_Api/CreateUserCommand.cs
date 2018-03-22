using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await
{
    public class CreateUserCommand
    {
        public ISimpleAuthenticationDataStore SimpleAuthenticationApi { get; set; }
        public string LoginName { get; set; }

        public Task Execute()
        {
            return SimpleAuthenticationApi.CreateUser(LoginName);
        }
    }
}