using System;
using GeneralRPS.Core;
using static System.Console;

namespace GeneralRPS.App
{
    public class Printer
    {
        public Printer PrintUsage()
        {
            WriteLine("usage: rps [shape]...");
            WriteLine("\tshape - list of shapes");
            return this;
        }

        public Printer PrintConstraints()
        {
            WriteLine("Constraints:");
            WriteLine("1. shape count is greater than 2;");
            WriteLine("2. shape count is odd;");
            WriteLine("3. shapes that differ only by case of characters are considered the same.");
            WriteLine("4. shapes are unique.");
            return this;
        }

        public Printer PrintExamples()
        {
            WriteLine("Argument example:");
            WriteLine("a b c");
            WriteLine("a b c d e f");
            WriteLine("shape1 shape2 shape3");
            return this;
        }
        
        public Printer PrintShapeMenu(string[] shapes)
        {
            WriteLine("Available moves:");
            var number = 1;
            foreach (var shape in shapes)
                WriteLine($"{number++} - {shape}");
            WriteLine("0 - exit");
            return this;
        }

        public Printer PrintMessageAndHex(string message, byte[] source)
        {
            WriteLine(message);
            WriteLine(Convert.ToHexString(source));
            return this;
        }

        public Printer PrintEnterYourMove()
        {
            Write("Enter your move: ");
            return this;
        }

        private Printer PrintMove(string text, string[] shapes, int shape)
        {
            WriteLine($"{text} {shapes[shape - 1]}");
            return this;
        }
        
        public Printer PrintYourMove(string[] shapes, int shape) => 
            PrintMove("Your move:", shapes, shape);

        public Printer PrintComputerMove(string[] shapes, int shape) => 
            PrintMove("Computer move:", shapes, shape);
        
        public Printer PrintResult(Result r)
        {
            WriteLine($"You {r.ToString()}!");
            return this;
        }
    }
}
