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

        public string GetHelloWorld()
        {
            return DataAdapter.GetHelloWorld();
        }
    }
}
