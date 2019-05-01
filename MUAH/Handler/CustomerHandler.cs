using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.ViewModel;
using MUAH.Model;

namespace MUAH.Handler
{
    class CustomerHandler
    {
        /// <summary>
        /// Specifikt er en handler en mellemmand mellem singleton og viewmodel.
        /// Derfor skal handleren have en viewmodel property, samt hvorfor vi i metoden CreateCustomer anvender singletonen. 
        /// </summary>
        public CustomerViewModel CustomerViewModel { get; set; }

        public CustomerHandler(CustomerViewModel customerViewModel)
        {
            CustomerViewModel = customerViewModel;
        }

        public void CreateCustomer()
        {
            CustomerViewModel.CustomerSingleton.PostCustomer(CustomerViewModel.phoneNo, CustomerViewModel.password, CustomerViewModel.Name, CustomerViewModel.id);
        }

        //public void EditCustomer()
        //{
            
        //}
    }
}
