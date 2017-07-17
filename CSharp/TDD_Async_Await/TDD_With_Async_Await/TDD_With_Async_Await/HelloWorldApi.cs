using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await
{
    public class HelloWorldApi
    {
        public IHelloWorldData DataAdapter { get; set; }

        public async Task<string> GetHelloWorld()
        {
            var helloWorld = await DataAdapter.GetHelloWorld();
            return helloWorld;
        }

        public async Task<PostResult> CreateUser(string userDataLoginName, string userDataUserName)
        {
            await DataAdapter.CreateUser(userDataLoginName, userDataUserName);
            return new PostResult();
        }
    }
}
