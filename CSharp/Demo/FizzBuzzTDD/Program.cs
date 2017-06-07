using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();
            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Press 'Enter' to exit");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter))
            {

            }
        }
    }
}
