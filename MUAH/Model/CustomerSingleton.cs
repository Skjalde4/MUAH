using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using MUAH.PersistencyService;

namespace MUAH.Model
{
    class CustomerSingleton
    {
        /// <summary>
        /// En singleton laver en instans af sig selv, så de collections man bruger er ens på alle pages. 
        /// </summary>
        
        private static CustomerSingleton _instance = null;

        public static CustomerSingleton Instance
        {
            get { return _instance ?? (_instance = new CustomerSingleton()); }
        }

        public ObservableCollection<Customer> Customers { get; set; }


        private CustomerSingleton()
        {
            Customers = new ObservableCollection<Customer>();
            GetCustomers();
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

        //Put gør at man kan ændre i en kunde fx hvis kunden har fået nyt nummer
        public void PutCustomer(Customer oldCustomer, string phoneNo, string password, string name, int id)
        {
            Customer customers = new Customer(phoneNo, password, name, id);
            Customers.Remove(oldCustomer);
            Customers.Add(customers);
            PersistencyServiceCustomer.PutCustomerAsync(customers);
        }

        public void DeleteCustomer(Customer customerToBeDeleted)
        {
            Customers.Remove(customerToBeDeleted);
            PersistencyServiceCustomer.DeleteCustomerAsync(customerToBeDeleted);
        }

       
    }
}
