using System;

namespace TDD_With_Async_Await_Common
{
    public class PostResult : IPostResult
    {
        public bool WasSuccessful
        {
            get { return true; }
            set { throw new NotImplementedException(); }
        }
    }
}