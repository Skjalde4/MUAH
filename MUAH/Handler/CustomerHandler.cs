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

        /// <summary>
        /// Skaber et nyt CustomerHandler objekt, som initialiseres med en reference til viewmodellen.
        /// </summary>
        /// <param name="customerViewModel">reference til viewmodellen</param>
        public CustomerHandler(CustomerViewModel customerViewModel)
        {
            CustomerViewModel = customerViewModel;
        }

        /// <summary>
        /// Kalder postcustomer metoden gennem customersingletonen i viewmodellen. 
        /// </summary>
        public void CreateCustomer()
        {
            if (!CustomerViewModel.CustomerSingleton.CheckExistingCustomer(CustomerViewModel.phoneNo))
            {
                CustomerViewModel.CustomerSingleton.PostCustomer(CustomerViewModel.phoneNo, CustomerViewModel.password, CustomerViewModel.Name, CustomerViewModel.id);
            }
            else
            {
                CustomerViewModel.Name = "";
                CustomerViewModel.Text = "Brugeren findes allerede";
            }
        }

        
    }
}
