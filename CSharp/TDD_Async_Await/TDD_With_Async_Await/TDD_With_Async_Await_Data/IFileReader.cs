using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_With_Async_Await_Data;

namespace TDD_With_Async_Await_Common
{
    public interface IFileReader
    {
        UserInformation GetUserInformation();
    }
}
