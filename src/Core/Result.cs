using System;

namespace GeneralRPS.Core
{
    public enum Result
    {
        Lose = -1,
        Draw = 0,
        Win = 1
    }

    public static class ResultExtensions
    {
        public static Result Inverse(this Result result) =>
            (Result)(-(int) result);

        public static Result ToResult(this int value) =>
            (Result) Math.Sign(value);
    }
}
