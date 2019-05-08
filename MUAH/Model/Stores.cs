using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class Stores
    {
        public string Adress { get; set; }
        public int Zipcode { get; set; }
        public string StoreName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Stores(string adress, int zipcode, string storeName, double latitude, double longitude)
        {
            Adress = adress;
            Zipcode = zipcode;
            StoreName = storeName;
            Latitude = latitude;
            Longitude = longitude;
        }

    }

}
