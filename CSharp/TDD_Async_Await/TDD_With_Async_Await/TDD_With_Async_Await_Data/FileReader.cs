using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await_Data
{
    class FileReader : IFileReader
    {
        public Task WriteToFile(string userInformation)
        {
            throw new NotImplementedException();
        }
    }
}
