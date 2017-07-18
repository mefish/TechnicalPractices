using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await
{
    public class CreateUserCommand
    {
        public ISimpleAuthenticationApi SimpleAuthenticationApi { get; set; }
        public string LoginName { get; set; }

        public void Execute()
        {
            SimpleAuthenticationApi.CreateUser(LoginName);
        }
    }
}