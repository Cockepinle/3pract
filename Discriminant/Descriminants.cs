using System;

namespace Discriminant
{
    public class Descriminants
    {
        public (double? rootFirst, double? rootSecond) RootValues(int a, int b, int c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return (null, null); 
            }
            else if (discriminant > 0)
            {
                double rootFirst = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double rootSecond = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return (rootFirst, rootSecond); 
            }
            else 
            {
                double root = -b / (2 * a);
                return (root, root); 
            }
        }
        public double PercentageOfTheNumber(double number, double percentag)
        {
            return number * (percentag / 100);
        }
    }
}