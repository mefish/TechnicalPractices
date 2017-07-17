using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TDD_With_Async_Await;

namespace TDD_With_Async_Await_Tests
{
    [TestFixture]
    class CommandTests
    {
        [Test]
        public void CanTestUserInterfaceWithTestCommand()
        {
            var testCommand = new TestAuthenticationCommand();

            var result = testCommand.Execute();

            Assert.AreEqual("Hello, World!", result);

        }
    }
}
