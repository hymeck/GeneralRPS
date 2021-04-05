using System;

namespace GeneralRPS.Core
{
    public sealed class ArgsCountException : Exception
    {
        public ArgsCountException(string message) : base(message)
        {
        }
    }

    public sealed class ArgsUniquenessException : Exception
    {
        public ArgsUniquenessException()
        {
        }

        public ArgsUniquenessException(string message) : base(message)
        {
        }
    }
}
