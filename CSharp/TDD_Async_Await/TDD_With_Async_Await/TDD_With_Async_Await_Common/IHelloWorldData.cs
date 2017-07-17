﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_With_Async_Await_Common
{
    public interface IHelloWorldData
    {
        Task<string> GetHelloWorld();

        Task CreateUser(string userLoginName, string userUserName);
    }
}
