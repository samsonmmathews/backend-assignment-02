using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Assignment_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Based on the number of deliveries and collisions, we will calculate the score for the robot
        /// </summary>
        /// <param name="Collisions">The number of collisions that happened</param>
        /// <param name="Deliveries">The number of packages delivered</param>
        /// <returns>
        /// Returns the total score after calculating the number of points
        /// </returns>
        /// <example>
        /// "POST" -H "Content-Type: application/x-www-form-urlencoded" -d "Collisions=2&Deliveries=5" ".../api/J1/Delivedroid"
        /// </example>
        /// <example>
        /// "POST" -H "Content-Type: application/x-www-form-urlencoded" -d "Collisions=24&Deliveries=12" ".../api/J1/Delivedroid"
        /// </example>
        /// <example>
        /// "POST" -H "Content-Type: application/x-www-form-urlencoded" -d "Collisions=51&Deliveries=0" ".../api/J1/Delivedroid"
        /// </example>
        [HttpPost(template: "Delivedroid")]
        public int Delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            int score = ((Deliveries * 50) - (Collisions * 10));

            if (Deliveries > Collisions)
            {
                score += 500;
            }
            return score;
        }
    }
}
