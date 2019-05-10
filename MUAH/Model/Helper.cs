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
