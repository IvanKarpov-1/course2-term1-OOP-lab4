using System.Text.RegularExpressions;

namespace Lab4
{
    internal delegate int CountOfDigitsInString(string str);

    public class DigitCounter
    {
        private static Regex _regex;

        public DigitCounter()
        {
            _regex = new Regex(@"\d");
        }

        private readonly CountOfDigitsInString _countOfDigitsInStringA = delegate(string str)
        {
            return _regex.Matches(str).Count;
        };

        private readonly CountOfDigitsInString _countOfDigitsInStringL = str => _regex.Matches(str).Count;

        public int GetDigitCountByAnonymousMethod(string str)
        {
            return _countOfDigitsInStringA(str);
        }

        public int GetDigitCountByLambdaExpression(string str)
        {
            return _countOfDigitsInStringL(str);
        }
    }
}