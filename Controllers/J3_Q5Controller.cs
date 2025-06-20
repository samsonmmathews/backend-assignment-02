using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend_Assignment_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3_Q5Controller : ControllerBase
    {
        /// <summary>
        /// Bronze level is awarded to all participants who achieve the third highest score. 
        /// Given a list of all the scores, we need to determine the score required for bronze level 
        /// and how many participants achieved this score.
        /// </summary>
        /// <param name="participants">The number of participants who were there for the event</param>
        /// <param name="scores">The scores of each participant separated by a comma</param>
        /// <returns>
        /// It returns the score that got the bronze medal and the number of participants who got that score.
        /// </returns>
        /// <example>
        /// "GET" api/J3_Q5/BronzeMedalCount?participants=5&scores=12%2C78%2C54%2C42%2C91 -> 54 1
        /// </example>
        /// <example>
        /// "GET" api/J3_Q5/BronzeMedalCount?participants=8&scores=75%2C70%2C60%2C70%2C70%2C60%2C75%2C70 -> 60 2
        /// </example>
        /// <example>
        /// "GET" api/J3_Q5/BronzeMedalCount?participants=4&scores=70%2C62%2C58%2C73 -> 62 1
        /// </example>
        [HttpGet(template: "BronzeMedalCount")]
        public string BronzeMedalCount([FromQuery] int participants, [FromQuery] string scores)
        {
            int[] score = scores.Split(",").Select(int.Parse).ToArray();
            int first = score[0];
            int second = int.MinValue;
            int third = int.MinValue;
            int count = 0;

            for (int i = 1; i < participants; i++) // For iterating inside the loop
            {
                if (score[i] > first)
                {
                    third = second;
                    second = first;
                    first = score[i];   
                    // If the value in the array is greater than the value in the variable first, then that means it is the highest value.
                    // Then we will shift the values of each variable.
                }
                else if(score[i] > second && score[i] != first)
                {
                    third = second; // We will only check this loop if the value in the array is less than the value in 'first'
                    second = score[i];
                    // If the value in the array is greater than the value in the variable second and not equal to the value in the variable first,
                    // then that means the value in the array is the second highest value. Then we need to shift the values up.
                }
                else if (score[i] > third && score[i] != first && score[i] != second)
                {
                    third = score[i];   // We will only check this loop if the value in the array is less than the value in 'first' and 'second'
                    // If the value in the array is greater than the value in the variable third and not equal to the value in the variable first
                    // and variable second, then that means the value in the array is the third highest value. Then we need to shift the values up.
                }
            }

            for (int i = 0; i < participants; i++)
            {
                if (score[i] == third)
                {
                    count++;    // The variable 'count' increments it's value if there is a value that is equal to the value stored inside 'third'
                }
            }
            string ans = third.ToString() + " " + count.ToString();
            return ans;
        }
    }
}
