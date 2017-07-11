using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await_Data
{
    public class HelloWorldDataRepository
    {
        public UserInformation GetUserinformationForUserName(string loginName)
        {
            return new UserInformation
                   {
                       LoginName = loginName,
                       UserName = "John Smith"
                   };
        }

        public IFileReader FileReader { get; set; }
    }
}
