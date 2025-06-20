using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace Backend_Assignment_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2_Q2Controller : ControllerBase
    {
        /// <summary>
        /// Magic Squares are square arrays of numbers that have the interesting property that the numbers in each column, and in each row,
        /// all add up to the same total. Given a 4x4 square[2-D array] of numbers, determine if it is magic square. [2016 J2 Question]
        /// </summary>
        /// <param name="row1">The four numbers of the first row separated by a comma</param>
        /// <param name="row2">The four numbers of the second row separated by a comma</param>
        /// <param name="row3">The four numbers of the third row separated by a comma</param>
        /// <param name="row4">The four numbers of the fourth row separated by a comma</param>
        /// <returns>
        /// Output either magic if the input is a magic square, or not magic if the input is not a magic square.
        /// If each row and each column adds up to the same number, then it is a magic square.
        /// </returns>
        /// <example>
        /// "GET" api/J2_Q2/MagicSquares?row1=5%2C10%2C1%2C3&row2=10%2C4%2C2%2C3&row3=1%2C2%2C8%2C5&row4=3%2C3%2C5%2C0 -> not magic
        /// </example>
        /// <example>
        /// "GET" api/J2_Q2/MagicSquares?row1=16%2C3%2C2%2C13&row2=5%2C10%2C11%2C8&row3=9%2C6%2C7%2C12&row4=4%2C15%2C14%2C1" -> magic
        /// </example>
        [HttpGet(template: "MagicSquares")]
        public string MagicSquares(string row1, string row2, string row3, string row4)
        {
            int[][] dataset = new int[4][];
            string result = "magic";
            int target = 0;

            dataset[0] = row1.Split(',').Select(int.Parse).ToArray();
            dataset[1] = row2.Split(',').Select(int.Parse).ToArray();
            dataset[2] = row3.Split(',').Select(int.Parse).ToArray();
            dataset[3] = row4.Split(',').Select(int.Parse).ToArray();
            // Gets the input of each row as a string, which we will then split into various parts whenever we see a comma.
            // We will then parse this string data into an integer value and stores it in our array.

            target = dataset[0].Sum();  // Calculates the sum of values in the first row and assigns it to the variable 'target'

            for(int i = 0; i < 4; i++)
            {
                if (dataset[i].Sum() != target) // Checks if the sum of the other rows are equal to the value in 'target'
                {
                    result = "not magic";
                    return result;
                }
            }

            for (int col = 0; col < 4; col++)
            {
                int colSum = 0;
                for (int row = 0; row < 4; row++)
                {
                    colSum += dataset[row][col];
                }
                if (colSum != target)   // Checks if the sum of the columns are not equal to the value in 'target'
                {
                    result = "not magic";
                    return result;
                }
            }
            return result;
        }
    }
}
