using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using MUAH.PersistencyService;
using MUAH.ViewModel;

namespace MUAH.Model
{
    class CustomerSingleton
    {
        /// <summary>
        /// En singleton laver en instans af sig selv, så de collections man bruger er ens på alle pages. 
        /// </summary>
        
        private static CustomerSingleton _instance = null;

        /// <summary>
        /// Propertien gør sådan, at hvis der allerede er en instans af klassen så returneres den, men
        /// hvis der ikke er en, skabes den. 
        /// </summary>
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

        /// <summary>
        /// Metoden loader de customers der allerede er oprettet i databasen. 
        /// </summary>
        public async void GetCustomers()
        {
            var customers = await PersistencyServiceCustomer.GetCustomerAsync();
            if (Customers != null)
                foreach (var cu in customers)
                {
                    Customers.Add(cu);
                }
        }



        /// <summary>
        /// Denne metode bruges til at skabe et nyt customer objekt. 
        /// </summary>
        /// <param name="phoneNo"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void PostCustomer(string phoneNo, string password, string name, int id)
        {
            Customer customers = new Customer(phoneNo, password, name, id);
            Customers.Add(customers);
            PersistencyServiceCustomer.PostCustomerAsync(customers);
        }

        /// <summary>
        /// Denne metode ændrer en customer i databasen. 
        /// </summary>
        /// <param name="oldCustomer">refererer til det customer objekt der skal ændres</param>
        /// <param name="phoneNo"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void PutCustomer(Customer oldCustomer, string phoneNo, string password, string name, int id)
        {
            Customer customers = new Customer(phoneNo, password, name, id);
            Customers.Remove(oldCustomer);
            Customers.Add(customers);
            PersistencyServiceCustomer.PutCustomerAsync(customers);
        }

        /// <summary>
        /// Denne metode sletter en customer.
        /// </summary>
        /// <param name="customerToBeDeleted">bruges til at vælge hvilket objekt der skal slettes
        /// </param>
        public void DeleteCustomer(Customer customerToBeDeleted)
        {
            Customers.Remove(customerToBeDeleted);
            PersistencyServiceCustomer.DeleteCustomerAsync(customerToBeDeleted);
        }

       
    }
}
