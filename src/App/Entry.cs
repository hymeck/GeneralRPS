using System;
using System.Security.Cryptography;
using System.Text;
using GeneralRPS.Core;
using static System.Console;
using static GeneralRPS.Core.ArgsValidator;

namespace GeneralRPS.App
{
    class Entry
    {
        static void Main(string[] args)
        {
            WriteLine(ToHex(GenerateKey()));
            // try
            // {
            //     CheckArgs(args);
            // }
            // catch (Exception e)
            // {
            //     WriteLine(e.Message);
            //     PrintHelp();
            //     Environment.Exit(1);
            // }
            //
            // RandomNumberGenerator s = RandomNumberGenerator.Create();
            // var computerChoice = RandomChoice(s, 1, args.Length);
            // HMACSHA256 hmac = new HMACSHA256();
            // hmac.
            //
            // var result = Play(args.Length, 1, 5);
            // WriteLine($"Result: {result.ToString()}");

            // do
            // {
            //     PrintMenu(args);
            //     Write("Enter your move: ");
            //     var input = ReadLine();
            //
            //     if (!int.TryParse(input, out var choice))
            //     {
            //         WriteLine();
            //         continue;
            //     }
            //
            //     if (choice == 0)
            //         Environment.Exit(0);
            //
            //     if (!IsCorrect(args, choice))
            //     {
            //         WriteLine();
            //         continue;
            //     }
            //     
            //     WriteLine($"Your move: {args[choice - 1]}");
            //     
            //     var result = Play(args.Length, choice, 6);
            //     WriteLine($"Result: {result.ToString()}");
            //     break;
            //
            // } 
            // while (true);
        }

        private static void PrintHelp()
        {
            WriteLine("usage: rps [shape]...");
            WriteLine("\tshape - list of shapes");
            WriteLine();
            WriteLine("Constraints:");
            WriteLine("1. shape count is greater than 2;");
            WriteLine("2. shape count is odd;");
            WriteLine("3. shapes are unique.");
        }

        private static void CheckArgs(string[] args)
        {
            CheckUniqueness(CheckIsCountOdd(CheckCount(args)), HasUniqueElements);
        }

        private static void PrintMenu(string[] shapes)
        {
            WriteLine("Available moves:");
            int number = 1;
            foreach (var shape in shapes)
                WriteLine($"{number++} - {shape}");
            WriteLine("0 - exit");
        }

        private static bool IsCorrect(string[] shapes, int choice) =>
            choice >= 1 && choice <= shapes.Length;


        private static byte[] GenerateKey()
        {
            var g = RandomNumberGenerator.Create();
            var bytes = new byte[16]; // 128 bit
            g.GetNonZeroBytes(bytes);
            return bytes;
        }

        private static string ToHex(byte[] key) => 
            Convert.ToHexString(key);

        private static int RandomChoice(int min, int max)
        {
            var g = RandomNumberGenerator.Create();
            var bytes = new byte[sizeof(int)]; // 4 bytes
            g.GetNonZeroBytes(bytes);
            var val = BitConverter.ToInt32(bytes);
            // https://stackoverflow.com/a/3057867/86411
            return ((val - min) % (max - min + 1) + (max - min + 1)) % (max - min + 1) + min;
        }
        
        private static Result Play(int cardinality, int choice, int computerChoice) =>
            RpsRules.Judge(cardinality, choice, computerChoice);
    }
}