using System;

namespace variables
{
    class Program
    {
        static void Main(string[] args)
        {
            int cupsOfCoffee=0;
            string fullName="";
            DateTime today = DateTime.Today;
            Console.WriteLine($"Variables:\n\tcupsOfCoffee: {cupsOfCoffee}\n\tfullName: {fullName}\n\ttoday: {today}");
            Console.WriteLine("Enter a number: ");
            double x = 0;
            double y = 0;
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter another number: ");
            y = double.Parse(Console.ReadLine());
            double sum = x + y;
            double difference = y - x;
            double product = x * y;
            int quotient = Convert.ToInt32(x / y);
            string printSum = String.Format("If you add {0} and {1} you get {2}!", x, y, sum);
            string printDifference = String.Format($"If you subtract {y} from {x} you get {difference}!");
            string printProduct = String.Format($"If you multiply {x} and {y} you get {product}!");
            string printQuotient = String.Format($"If you divide {x} and {y} you get {quotient} with a remainder of {x%y}!");
            Console.WriteLine($"Results\n\t{printSum}\n\t{printDifference}\n\t{printProduct}\n\t{printQuotient}");
        }
    }
}
