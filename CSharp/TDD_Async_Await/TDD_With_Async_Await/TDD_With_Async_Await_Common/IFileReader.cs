﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_With_Async_Await_Common
{
    public interface IFileReader
    {
        Task WriteToFile(string userInformation);
    }
}
