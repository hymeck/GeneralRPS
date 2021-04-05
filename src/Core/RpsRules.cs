using System;

namespace GeneralRPS.Core
{
    public static class RpsRules
    {
        // private static int LeftShiftBound(int cardinality, int range, int element) =>
        //     (cardinality + (element - range)) % cardinality;

        private static int RightShiftBound(int cardinality, int range, int element) =>
            (element + range) % cardinality;
        
        // todo: horrible O(n). may be try O(1)?
        private static bool InRight(int cardinality, int rightBound, int pivot, int target)
        {
            var result = false;

            int tmp = pivot;
            while (++tmp <= rightBound)
            {
                if (tmp > cardinality)
                    tmp = 1;
                if (tmp == target)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }


        public static Result Judge(int cardinality, int leftElement, int rightElement)
        {
            var result = Result.Draw;
            
            if (leftElement != rightElement)
            {
                // var leftBound = LeftShiftBound(cardinality, range, leftElement);
                var rightBound = RightShiftBound(cardinality, cardinality >> 1, leftElement);

                result = InRight(cardinality, rightBound, leftElement, rightElement)
                    ? Result.Lose
                    : Result.Win;
            }
            
            return result;
        }
    }
}
