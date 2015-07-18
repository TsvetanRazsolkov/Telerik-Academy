namespace Methods
{
    using System;

    public class Methods
    {   
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber("1.5", "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Point2D firstPoint = new Point2D(3, -1);
            Point2D secondPoint = new Point2D(3, 2.5);
            var distanceBetweenPoints = firstPoint.CalcDistanceToAnotherPoint(secondPoint);
            bool pointsFormHorizontalLine = firstPoint.HorizontalCoordinate == secondPoint.HorizontalCoordinate;
            bool pointsFormVerticalLine = firstPoint.VerticalCoordinate == secondPoint.VerticalCoordinate;
            Console.WriteLine(distanceBetweenPoints);
            Console.WriteLine("Horizontal? " + pointsFormHorizontalLine);
            Console.WriteLine("Vertical? " + pointsFormVerticalLine);

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        public static double CalcTriangleArea(double a, double b, double c)
        {
            ValidateTriangleSides(a, b, c);            

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    {
                        throw new ArgumentException("Method accepts only a single digit as parameter");
                    }
            }
        }

        public static int FindMaxNumber(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Parameter must be a not empty array.");
            }

            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(object number, string format)
        {
            double numberAsDouble;
            bool isConvertibleToNumber = double.TryParse(number.ToString(), out numberAsDouble);
            if (!isConvertibleToNumber)
            {
                throw new ArgumentException("Number parameter is not an object convertible to number.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format parameter");
            }
        }

        private static void ValidateTriangleSides(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            bool sidesCanFormTriangle = a + b > c && a + c > b && b + c > a;
            if (!sidesCanFormTriangle)
            {
                throw new ArgumentException("Sides do not satisfy the Triangle Inequality Theorem and cannot form a triangle");
            }
        }
    }
}
