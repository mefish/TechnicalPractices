using System.Threading.Tasks;

namespace TDD_With_Async_Await_Common
{
    public interface ISimpleAuthenticationDataStore
    {
        Task<string> GetHelloWorld();

        Task CreateUser(string userLoginName);
    }
}