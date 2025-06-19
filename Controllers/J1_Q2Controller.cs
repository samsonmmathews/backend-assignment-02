using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Assignment_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1_Q2Controller : ControllerBase
    {
        /// <summary>
        /// Takes the number of regular and small cupcake boxes as input and displays the number of remaining cupcakes.
        /// There are 28 students in the class [given in the question]
        /// </summary>
        /// <param name="regularBoxes">The number of regular cupcake boxes [8 cupcakes are inside this box]</param>
        /// <param name="smallBoxes">The number of small cupcake boxes [3 cupcakes are inside this box]</param>
        /// <returns>
        /// Returns the number of cupcakes remaining after every student eats one cupcake.
        /// </returns>
        /// <example>
        /// "GET" api/J1_Q2/CupcakeParty?regularBoxes=2&smallBoxes=5" -> 3
        /// </example>
        /// <example>
        /// "GET" api/J1_Q2/CupcakeParty?regularBoxes=4&smallBoxes=1" -> 7
        /// </example>
        /// <example>
        /// "GET" api/J1_Q2/CupcakeParty?regularBoxes=5&smallBoxes=12" -> 48
        /// </example>
        [HttpGet(template: "CupcakeParty")]
        public int CupcakeParty([FromQuery] int regularBoxes, [FromQuery] int smallBoxes)
        {
            int totalCupcakes = ((regularBoxes * 8) + (smallBoxes * 3));
            int remainingCupcakes = totalCupcakes - 28; // 28 is the total number of students in the class

            if(remainingCupcakes < 0)
            {
                remainingCupcakes = 0; // To handle scenarios where the total number of cupcakes are less than 28
            }
            return remainingCupcakes;
        }
    }
}
