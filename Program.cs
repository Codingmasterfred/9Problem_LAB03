using System;
namespace Problem_LAB03
{
    public  class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 numbers: ");
            string input = Console.ReadLine();
            int product = Challenge1(input);
          
            Console.WriteLine("The product of these 3 numbers is: " + product);
        }

        public static int Challenge1(string input)
        {
            int product = 1;
            string[] numberStrings = input.Split(' ');
            int[] numbers = new int[3];
            for (int i = 0; i < Math.Min(3, numberStrings.Length); i++)
            {
                if (numberStrings.Length < 3)
                {
                    return 0;
                }
                if (int.TryParse(numberStrings[i], out int parsedNumber))
                {
                   
                    numbers[i] = parsedNumber;
                    product *= numbers[i] ;
                }
                else
                {
                    numbers[i] = 1;
                }
            }
            return product;
        }

       public static int Challenge1Test(string inlineData)
        {
           return Challenge1(inlineData);
        }

    }
}