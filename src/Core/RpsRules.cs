namespace GeneralRPS.Core
{
    public class RpsRules
    {
        // private int LeftShiftBound(int cardinality, int range, int element) =>
        //     (cardinality + (element - range)) % cardinality;

        private int RightShiftBound(int cardinality, int range, int element) =>
            (element + range) % cardinality;
        
        // todo: horrible O(n). may be try O(1)?
        private bool IsInRight(int cardinality, int rightBound, int pivot, int target)
        {
            if (target == rightBound)
                return true;
            
            var result = false;
            var tmp = pivot;
            while (++tmp != rightBound)
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
        
        public Result Judge(int cardinality, int firstShapeNumber, int secondShapeNumber)
        {
            var result = Result.Draw;
            
            if (firstShapeNumber != secondShapeNumber)
            {
                // var leftBound = LeftShiftBound(cardinality, range, leftElement);
                var rightBound = RightShiftBound(cardinality, cardinality >> 1, firstShapeNumber);

                result = IsInRight(cardinality, rightBound, firstShapeNumber, secondShapeNumber)
                    ? Result.Lose
                    : Result.Win;
            }
            
            return result;
        }
    }
}
