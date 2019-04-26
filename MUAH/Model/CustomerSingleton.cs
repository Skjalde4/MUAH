using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class CustomerSingleton
    {
        private static CustomerSingleton _instance = null;

        public static CustomerSingleton Instance
        {
            get { return _instance ?? (_instance = new CustomerSingleton()); }
        }



        private CustomerSingleton()
        {
            
        }
    }
}
