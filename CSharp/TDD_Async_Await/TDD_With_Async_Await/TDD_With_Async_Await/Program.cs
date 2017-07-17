using System;

namespace TDD_With_Async_Await
{
    internal class Program
    {
        private const string READ_PROMPT = "console> ";

        private static void Main(string[] args)
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
                    var result = Execute(consoleInput);

                    WriteToConsole(result);
                }
                catch (Exception exception)
                {
                    WriteToConsole(exception.Message);
                }
            }
        }

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
            if (command == "test") return new TestAuthenticationCommand().Execute();
            return $"Executed the {command} command";
        }

        public void DisplayToUser(string stringToDisplay)
        {
            Console.WriteLine(stringToDisplay);
        }
    }
}