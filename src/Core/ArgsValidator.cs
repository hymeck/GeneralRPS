using System;

namespace GeneralRPS.Core
{
    public class ArgsValidator
    {
        private readonly string[] args;

        public ArgsValidator(string[] args) => 
            this.args = args;

        public ArgsValidator CheckCount()
        {
            if (args.Length < 3)
                throw new ArgsCountException($"Count is less than 3.");
            return this;
        }

        public ArgsValidator CheckIsCountOdd()
        {
            if (args.Length % 2 == 0)
                throw new ArgsCountNotOddException($"Count is not odd.");
            return this;
        }

        // todo: too high complexity
        public static bool HasUniqueElements(string[] source)
        {
            var result = true;
            for (var i = 0; i < source.Length - 1; i++)
            for (var j = i + 1; j < source.Length; j++)
            {
                if (source[i].ToUpper() == source[j].ToUpper())
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public ArgsValidator CheckUniqueness(Func<string[], bool> unique)
        {
            if (!unique(args))
                throw new ArgsUniquenessException("There are at least two the same elements.");
            return this;
        }
    }
}
