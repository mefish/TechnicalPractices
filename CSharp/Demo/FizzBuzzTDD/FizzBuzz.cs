using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTDD
{
    public class FizzBuzz
    {
        private const string FIZZTEXT = "Fizz";
        private const string BUZZTEXT = "Buzz";

        public string GetFizzAndOrBuzz(int numberToConvert = 1)
        {
            var replacement = string.Empty;

            if (IsFizz(numberToConvert)) replacement += FIZZTEXT;

            if (IsBuzz(numberToConvert)) replacement += BUZZTEXT;

            if (replacement != string.Empty) return replacement;

            return numberToConvert.ToString();
        }

        private static bool IsBuzz(int startNumber)
        {
            return startNumber % 5 == 0;
        }

        private static bool IsFizz(int startNumber)
        {
            return startNumber % 3 == 0;
        }
    }
}
