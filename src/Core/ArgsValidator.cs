using System;

namespace GeneralRPS.Core
{
    public static class ArgsValidator
    {
        public static string[] CheckNull(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            return args;
        }

        public static string[] CheckCount(string[] args)
        {
            if (args.Length % 2 == 0)
                throw new ArgsCountException($"Count is not odd.");
            return args;
        }

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

        public static string[] CheckUniqueness(string[] args, Func<string[], bool> unique)
        {
            if (!unique(args))
                throw new ArgsUniquenessException("There are at least two the same elements.");
            return args;
        }
    }
}