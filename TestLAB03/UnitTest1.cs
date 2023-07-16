using Problem_LAB03;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestLAB03
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("2 2 2")]
        [InlineData("2 2 2 2")]
        [InlineData("2 2 a")]
        [InlineData("-2 -2 -2")]
        public void Challenge1(string inlineData)
        {
            int total = 1;
            string[] array = inlineData.Split(" ");
            int[] ArrayOfThree = new int[3];
            for (int i = 0; i < ArrayOfThree.Length; i++)
            {
                if (!Regex.IsMatch(array[i], @"^-?\d+$"))
                {
                    array[i] = "1";
                }
                ArrayOfThree[i] = Convert.ToInt32(array[i]);
                total *= ArrayOfThree[i];
            }
            if (ArrayOfThree.Length < 3)
            {
                total = 0;
            }

            Assert.Equal(
                total, Program.Challenge1(inlineData));
        }

        [Theory]
        [InlineData(4, new[] { 4, 8, 15, 16 }, 10)]
        [InlineData(2, new[] { 1, 2 }, 1)]
        [InlineData(5, new[] { 5, 5, 5, 5, 5 }, 5)]
        public void Challenge_2_Test(int input, int[] numbers, int expectedAverage)
        {
            // Arrange
            var mockUserInput = string.Join("\n", numbers);
            var mockConsoleInput = new System.IO.StringReader(mockUserInput);
            System.Console.SetIn(mockConsoleInput);
             
            // Redirect console output to Test Output window
            var testOutput = new System.IO.StringWriter();
            Console.SetOut(testOutput);

            // Act
            int actualAverage = Program.Challenge2(input, new int[input]);


            // Assert
            Assert.Equal(expectedAverage, actualAverage);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 2, 3, 3, 3, 1 }, 3)]
         [InlineData(new int[] { 5, 5, 5, 5, 5 }, 5)]
        [InlineData(new int[] { 4, 6, 8, 2, 1 },4)]
        [InlineData(new int[] { 7, 7, 7, 7, 7 },7)]
        [InlineData(new int[] { 9, 2, 6, 4, 1, 3 },9)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },1)]
        public static void Challenge_4_Test(int[] array1,int expected)
        {
            Assert.Equal(expected, Program.Challenge4Test(array1));
            Assert.Equal(expected, Program.Challenge4Test(array1));
            Assert.Equal(expected, Program.Challenge4Test(array1));

            // Test case: All numbers in the array are the same value
            Assert.Equal(expected, Program.Challenge4Test(array1));

            // Test case: No duplicates exist in the array
            Assert.Equal(expected, Program.Challenge4Test(array1));

            // Test case: Multiple numbers that show up the same amount of times
            Assert.Equal(expected, Program.Challenge4Test(array1));
        }
        [Theory]
        [InlineData(new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 }, 555)]
        [InlineData(new int[] { -5, -25, -99, -123, -78, -96, -555, -108, -4 }, -4)]
        [InlineData(new int[] { 5, 5, 5, 5, 5, 5, 5, 5 }, 5)]
        public void Challenge_5_Test(int[] array, int total)
        {

            Assert.Equal(total, Program.Challenge5Test(array));
            Assert.Equal(total, Program.Challenge5Test(array));
            Assert.Equal(total, Program.Challenge5Test(array));
        }
        [Theory]
        [InlineData("This is a sentence about important things", new string[]
 {
    "This: 4",
    "is: 2",
    "a: 1",
    "sentence: 8",
    "about: 5",
    "important: 9",
    "things: 6"
 })]
        public void Challenge_9_Test(string sentence, string[] expected)
        {
            // Act
            string[] result = Program.Challenge9(sentence);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}