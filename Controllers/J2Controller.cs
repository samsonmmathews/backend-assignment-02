using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Assignment_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Takes into consideration the peppers used and displays the total spiciness of the chili in the 'Scolville Heat Units' value
        /// </summary>
        /// <param name="ChiliPeppers">The names of all the chili peppers used separated by a comma.</param>
        /// <returns>
        /// Returns the total spiciness of the chili in the SHU value
        /// </returns>
        /// <example>
        /// "GET" api/J2/ChilliPeppers?ChiliPeppers=Poblano%2CCayenne%2CThai%2CPoblano -> 118000
        /// </example>
        /// <example>
        /// "GET" api/J2/ChilliPeppers?ChiliPeppers=Habanero%2CThai%2CCayenne%2CSerrano%2CMirasol%2CPoblano -> 263000
        /// </example>
        /// <example>
        /// "GET" api/J2/ChilliPeppers?ChiliPeppers=Cayenne%2CCayenne%2CCayenne%2CCayenne -> 160000
        /// </example>
        [HttpGet(template: "ChilliPeppers")]
        public int ChilliPeppers(string ChiliPeppers)
        {
            int heatUnits = 0;
            string[] ingredients = ChiliPeppers.Split(',');
            foreach (string ingredient in ingredients)
            {
                if (ingredient == "Poblano")
                {
                    heatUnits += 1500;
                }
                else if (ingredient == "Mirasol")
                {
                    heatUnits += 6000;
                }
                else if (ingredient == "Serrano")
                {
                    heatUnits += 15500;
                }
                else if (ingredient == "Cayenne")
                {
                    heatUnits += 40000;
                }
                else if (ingredient == "Thai")
                {
                    heatUnits += 75000;
                }
                else if (ingredient == "Habanero")
                {
                    heatUnits += 125000;
                }
            }
            return heatUnits;
        }
    }
}
