﻿using System.Threading.Tasks;

namespace TDD_With_Async_Await_Common
{
    public interface IHelloWorldData
    {
        Task<string> GetHelloWorld();

        Task CreateUser(string userLoginName);
    }
}