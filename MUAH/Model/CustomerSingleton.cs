using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.PersistencyService;

namespace MUAH.Model
{
    class CustomerSingleton
    {
        private static CustomerSingleton _instance = null;

        public static CustomerSingleton Instance
        {
            get { return _instance ?? (_instance = new CustomerSingleton()); }
        }

        public ObservableCollection<Customer> Customers { get; set; }


        private CustomerSingleton()
        {
            Customers = new ObservableCollection<Customer>();
        }

        //Get loader de customers der allerede er oprettet i databasen.
        public async void GetCustomers()
        {
            var customers = await PersistencyServiceCustomer.GetCustomerAsync();
            if (Customers != null)
                foreach (var cu in customers)
                {
                    Customers.Add(cu);
                }
        }

        //Post tilføjer nye kunder til databasen
        public void PostCustomer(string phoneNo, string password, string name, int id)
        {
            Customer customers = new Customer(phoneNo, password, name, id);
            Customers.Add(customers);
            PersistencyServiceCustomer.PostCustomerAsync(customers);
        }
    }
}
