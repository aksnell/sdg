using System;

namespace variables
{
    public class Epic
    {
        public void runLesson()
        {
            // Initialize variable practice.
            int cupsOfCoffee=0;
            string fullName="";
            DateTime today = DateTime.Today;
            Console.WriteLine($"Variables:\n\tcupsOfCoffee: {cupsOfCoffee}\n\tfullName: {fullName}\n\ttoday: {today}");
            // Adventure Mode name logic, and lets just guess and hope that we can throw a
            // ternary into a print statement
            Console.WriteLine(" Hello, what is your name: ");
            fullName = Console.ReadLine();
            Console.WriteLine(fullName == "Alice" ? "Hello Alice, you get a special greeting!" : String.Format($"Hello {fullName} you get a boring greeting."));
            // Explorer mode number handeling, etc.
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
