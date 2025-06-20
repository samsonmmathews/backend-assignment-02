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
        /// "GET" api/J2/ChilliPeppers?Ingredients=Poblano%2CCayenne%2CThai%2CPoblano -> 118000
        /// </example>
        /// <example>
        /// "GET" api/J2/ChilliPeppers?Ingredients=Habanero%2CThai%2CCayenne%2CSerrano%2CMirasol%2CPoblano -> 263000
        /// </example>
        /// <example>
        /// "GET" api/J2/ChilliPeppers?Ingredients=Cayenne%2CCayenne%2CCayenne%2CCayenne -> 160000
        /// </example>
        [HttpGet(template: "ChilliPeppers")]
        public int ChilliPeppers(string Ingredients)
        {
            int heatUnits = 0;
            string[] chilis = Ingredients.Split(',');
            // Gets the input as a string, which we will then split into various parts whenever we see a comma
            // We will then store them in the string array chilis.
            foreach (string chili in chilis)
            {
                if (chili == "Poblano")
                {
                    heatUnits += 1500;
                }
                else if (chili == "Mirasol")
                {
                    heatUnits += 6000;
                }
                else if (chili == "Serrano")
                {
                    heatUnits += 15500;
                }
                else if (chili == "Cayenne")
                {
                    heatUnits += 40000;
                }
                else if (chili == "Thai")
                {
                    heatUnits += 75000;
                }
                else if (chili == "Habanero")
                {
                    heatUnits += 125000;
                }
            }
            return heatUnits;
        }
    }
}
