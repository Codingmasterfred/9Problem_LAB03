using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            Console.WriteLine("Please enter a number between 2-10: ");
            string PrimaryInputForChallenge2 = Console.ReadLine();
            int ConvertedInput = Convert.ToInt32(PrimaryInputForChallenge2);
            int[] range = new int[Convert.ToInt32(ConvertedInput)];
            int num = 0;

                Challenge2(ConvertedInput, range);
            Challenge3();
            Console.WriteLine("Enter the array in the format [1,2,3]:");
            string Input = Console.ReadLine();

            int[] array = CovertstringOfArray(Input);


            Challenge4(array);
            Console.WriteLine("Enter the array in the format [1,2,3]: And it will sort out the larget value");
            string InputForChallenge5 = Console.ReadLine();
            int[] arrayForChallenge5 = CovertstringOfArray(InputForChallenge5);
            Challenge5(arrayForChallenge5);

            Console.WriteLine("Enter a word: ");
            string word = Console.ReadLine();

            try
            {
                Challenge6(word);
                Console.WriteLine("Word saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving the word: " + ex.Message);
            }
            Challenge7();
            Console.WriteLine("remove a word");
            string Inputforchallenge8 = Console.ReadLine();
            Challenge8(Inputforchallenge8);
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();
            Challenge9(sentence);

        }


        public static int[] CovertstringOfArray(string Input)
        {
            string[] stringArray = Input
               .Replace("[", "")
               .Replace("]", "")
               .Split(',');

            int[] array = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (int.TryParse(stringArray[i], out int parsedValue))
                {
                    array[i] = parsedValue;
                }
                else { Console.WriteLine("invalid");
                    i--; }
              
            }
                return array;
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

        public static int Challenge2(int ConvertedInput, int[] range)
        {
            string ConvertedInputForChallenge2 = Convert.ToString(ConvertedInput);
            if (!Regex.IsMatch(ConvertedInputForChallenge2, @"^-?\d+$") || ConvertedInput < 2 || ConvertedInput > 9)
        {
            Console.WriteLine("Enter A number GREATER THAN 2 but LESS THAN 10"); return 0;
        }
        else
        {
            int AmountOfRounds = 0;
                int total = 0;
               return  BaseCase(ConvertedInput, AmountOfRounds, total);
        }
        }
        public static int BaseCase(int ConvertedInput, int AmountOfRounds, int total)
        {
            if (AmountOfRounds == ConvertedInput)
            {
                Console.WriteLine(total  / ConvertedInput);
                return total / ConvertedInput;
            }
            else
            {
                Console.WriteLine(AmountOfRounds + " Of " + ConvertedInput + " - Enter A Number");
                int input = Convert.ToInt32(Console.ReadLine());
                total += input;
                return BaseCase(ConvertedInput, AmountOfRounds + 1, total);
            }
        }

        public static void Challenge3()
        {
            Console.WriteLine("         *");
            Console.WriteLine("        ***");
            Console.WriteLine("       *****");
            Console.WriteLine("      *******");
            Console.WriteLine("     *********");
            Console.WriteLine("      *******");
            Console.WriteLine("       ***** ");
            Console.WriteLine("        ***");
            Console.WriteLine("         *");
        }

        public static int Challenge4(int[] array)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            foreach (int num in array)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }

            int mostFrequentNumber = array[0];
            int maxFrequency = 1;

            foreach (KeyValuePair<int, int> kvp in frequencyMap)
            {
                if (kvp.Value > maxFrequency)
                {
                    mostFrequentNumber = kvp.Key;
                    maxFrequency = kvp.Value;
                }
            }
            Console.WriteLine(mostFrequentNumber);
            return mostFrequentNumber;
        }

       public static int Challenge5(int[] arrayForChallenge5)
        {
            if (arrayForChallenge5 == null || arrayForChallenge5.Length == 0)
            {
                throw new ArgumentException("Array is empty or null");
            }

            int maximum = arrayForChallenge5[0];
            for (int i = 1; i < arrayForChallenge5.Length; i++)
            {
                if (arrayForChallenge5[i] > maximum)
                {
                    maximum = arrayForChallenge5[i];
                }
            }

            return maximum;
        }

        public static void Challenge6(string word)
        {
            string filePath = "C:\\Users\\fgent\\OneDrive\\Documents\\GitHub\\9Problem_LAB03\\words.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(word);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving the word to file: " + ex.Message);
            }
        
    }
        public static void Challenge7()
        {
            string filePath = "C:\\Users\\fgent\\OneDrive\\Documents\\GitHub\\9Problem_LAB03\\words.txt";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading the file: " + ex.Message);
            }
        }

        public static void Challenge8(string wordToRemove)
        {
            string filePath = "words.txt";
            List<string> words = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        words.Add(line);
                    }
                }

                // Remove the specified word
                words.Remove(wordToRemove);

                // Write the updated contents back to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string word in words)
                    {
                        writer.WriteLine(word);
                    }
                    Console.WriteLine("Word is Back");    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading or writing the file: " + ex.Message);
            }



        }
            public static string[] Challenge9(string sentence)
            {
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Create an array to store the word and its length
            string[] result = new string[words.Length];

            // Process each word and store it in the result array
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int length = word.Length;
                result[i] = $"{word}: {length}";
            }
            Console.WriteLine(result);
            return result;
        }
    







        public static int Challenge1Test(string inlineData)
        {
           return Challenge1(inlineData);
        }

        public static int Challenge2Test(int ConvertedInput, int[] range)
        {
            return Challenge2(ConvertedInput, range);
        }

        public static int Challenge4Test( int[] array)
        {
            return Challenge4(array);
        }

        public static int Challenge5Test(int[] array)
        {
            return Challenge5(array);
        }
        public static string[] Challenge9Test(string sentence)
        {
            return Challenge9Test(sentence);
        }
    }
}