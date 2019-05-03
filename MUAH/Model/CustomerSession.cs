using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    public class CustomerSession
    {
        /// <summary>
        /// Vores CustomerSession bruges til at adskille kunderne fra hinanden når de bestiller mad, hvis de ikke er logget ind.
        /// Idéen er at programmet kan adskille  de forskellige kurve, såfremt flere kunder bestiller samtidig.
        /// Formålet med private sessions ift. databasen er, at kunder ofte opretter en ordre, uden at gennemføre bestillingen,
        /// hvorfor vi via denne metode undgår unødig fyld i databasen.
        /// </summary>
        public Guid SessionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int NoOfProduct { get; set; }

        
    }
}
