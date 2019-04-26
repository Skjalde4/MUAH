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

        //public async void GetCustomersAsync()
        //{
        //    //var customers = await PersistencyServiceCustomer.
        //}
    }
}
