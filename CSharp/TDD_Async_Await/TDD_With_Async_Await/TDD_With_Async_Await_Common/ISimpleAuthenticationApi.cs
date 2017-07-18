using System.Threading.Tasks;

namespace TDD_With_Async_Await_Common
{
    public interface ISimpleAuthenticationApi
    {
        Task<string> GetHelloWorld();

        Task<IPostResult> CreateUser(string loginName);
    }
}