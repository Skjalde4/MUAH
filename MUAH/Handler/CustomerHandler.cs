using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.ViewModel;

namespace MUAH.Handler
{
    class CustomerHandler
    {
        public CustomerViewModel CustomerViewModel { get; set; }

        public CustomerHandler(CustomerViewModel customerViewModel)
        {
            CustomerViewModel = customerViewModel;
        }

        public void CreateCustomer()
        {
           // CustomerViewModel.CustomerSingleton.PostCustomer(CustomerViewModel.id);
        }

        //public void EditCustomer()
        //{
            
        //}
    }
}
