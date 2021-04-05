using System;
using GeneralRPS.Core;
using static GeneralRPS.Core.RpsRules;

namespace GeneralRPS.App
{

    class Entry
    {
        static void Main(string[] args)
        {
            // CheckUniqueness(args, HasUniqueElements);
            string[] source = {"a", "b", "c", "d", "e", "f", "g"};
            var cardinality = source.Length; // 7
            var range = cardinality >> 1; // 3
            
            var result = Judge(cardinality, range, 2, 3);
        }
    }
}