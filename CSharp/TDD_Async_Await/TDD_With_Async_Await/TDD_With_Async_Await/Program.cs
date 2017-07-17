using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_With_Async_Await_Common;

namespace TDD_With_Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;

            Run();
        }

        private static void Run()
        {
            while (true)
            {
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    string result = Execute(consoleInput);

                    WriteToConsole(result);
                }
                catch (Exception exception)
                {
                    WriteToConsole(exception.Message);
                }
            }
        }

        private const string READ_PROMPT = "console> ";
        private static string ReadFromConsole(string promptMessage = "")
        {
            Console.WriteLine(READ_PROMPT + promptMessage);
            return Console.ReadLine();
        }

        private static void WriteToConsole(string message = "")
        {
            if (message.Length > 0) Console.WriteLine(message);
        }

        private static string Execute(string command)
        {
            return $"Executed the {command} command";
        }

        public void DisplayToUser(string stringToDisplay)
        {
            Console.WriteLine(stringToDisplay);
        }
    }
}
