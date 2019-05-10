using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace MUAH.Model
{
    class Helper
    {
        /// <summary>
        /// Hjælper med at indeholde properties der bruges til at komme videre. 
        /// </summary>
        public static string callFrom;

        public static bool isLoggedIn;

        /// <summary>
        /// Her tjekkes der for, om måneden er mindre end 13, eftersom at der kun er 12 måneder på et år.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool isMaxMonth(string month, VirtualKey c)
        {
            int digMonth = Convert.ToInt16(month + ((Char)c).ToString());


            if (digMonth < 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool isMinimumYear(string year, VirtualKey c)
        {
            int digYear = Convert.ToInt16(year + ((Char)c).ToString());
            int numberOfChar = (year + ((Char)c).ToString()).Length;

            if (digYear > 18 || numberOfChar <2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
