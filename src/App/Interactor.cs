using GeneralRPS.Core;
using static System.Console;

namespace GeneralRPS.App
{
    public class Interactor
    {
        private readonly string[] shapes;
        public Interactor(string[] shapes) =>
            this.shapes = shapes;

        public Interactor Interact()
        {
            var computerShape = Utils.GenerateRandomShapeNumber(1, shapes.Length);
            var (keyHmac, hmac) = Utils.GenerateHmacs(computerShape);

            var p = new Printer();
            p.PrintMessageAndHex("HMAC:", hmac);

            var userShape = GetShapeNumberFromInputLoop(p);
            p.PrintYourMove(shapes, userShape);
            var res = PlayOnce(shapes.Length, userShape, computerShape);
            p.PrintComputerMove(shapes, computerShape);
            p.PrintResult(res);
            
            p.PrintMessageAndHex("HMAC key:", keyHmac);
            
            return this;
        }

        private int GetShapeNumberFromInputLoop(Printer p)
        {
            do
            {
                p
                    .PrintShapeMenu(shapes)
                    .PrintEnterYourMove();
                var choice = ReadLine();

                var r = int.TryParse(choice, out var shape);
                if (!r || shape < 1 || shape > shapes.Length)
                    continue;

                return shape;
            }
            while (true);
        }

        private Result PlayOnce(int cardinality, int shapeNumber, int computerShapeNumber)
        {
            var r = new RpsRules();
            return r.Judge(cardinality, shapeNumber, computerShapeNumber);
        }
    }
}
