using System;
using GeneralRPS.Core;

namespace GeneralRPS.App
{
    class Entry
    {
        static void Main(string[] args)
        {
            try
            {
                CheckArgs(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                var p = new Printer(); 
                p
                    .PrintUsage()
                    .PrintConstraints()
                    .PrintExamples();
                Environment.Exit(1);
            }

            var i = new Interactor(args);
            i.Interact();
        }

        private static void CheckArgs(string[] args)
        {
            var v = new ArgsValidator(args);
            v
                .CheckCount()
                .CheckIsCountOdd()
                .CheckUniqueness(ArgsValidator.HasUniqueElements);
        }
    }
}
