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
        private const int BUZZMULTIPLE = 5;
        private const int FIZZMULTIPLE = 3;
        private string _replacementText;

        public string GetFizzAndOrBuzz(int numberToConvert)
        {
            ClearReplacementText();

            AddFizzIfFizz(numberToConvert);
            AddBuzzIfBuzz(numberToConvert);

            if (AnyReplacementText()) return _replacementText;

            return numberToConvert.ToString();
        }

        private void AddBuzzIfBuzz(int numberToConvert)
        {
            if (IsBuzz(numberToConvert)) _replacementText += BUZZTEXT;
        }

        private void AddFizzIfFizz(int numberToConvert)
        {
            if (IsFizz(numberToConvert)) _replacementText += FIZZTEXT;
        }

        private void ClearReplacementText()
        {
            _replacementText = string.Empty;
        }

        private bool AnyReplacementText()
        {
            return _replacementText != string.Empty;
        }

        private static bool IsBuzz(int startNumber)
        {
            return startNumber % BUZZMULTIPLE == 0;
        }

        private static bool IsFizz(int startNumber)
        {
            return startNumber % FIZZMULTIPLE == 0;
        }
    }
}
