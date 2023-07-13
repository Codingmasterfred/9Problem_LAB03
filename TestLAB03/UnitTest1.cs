using Problem_LAB03;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TestLAB03
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("2 2 2")]
        [InlineData("2 2 2 2")]
        [InlineData("2 2 a")]
        [InlineData("-2 -2 -2")]
        public void Test1(string inlineData)
        { 
            int total = 1;
            string[] array = inlineData.Split(" ");
            int[] ArrayOfThree= new int[3];
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
            /*ArrayOfThree = array.Select(x => Convert.ToInt32(x)).ToArray();
            ArrayOfThree.Select(x => total *= x).ToArray();
            if (ArrayOfThree.Length > 3) { */


            Assert.Equal(
                total, Program.Challenge1(inlineData));
        }
     
    }
}