using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class CustomerSessionSingleton
    {
        private static CustomerSessionSingleton _instance = null;

        public static CustomerSessionSingleton Instance
        {
            get { return _instance ?? (_instance = new CustomerSessionSingleton()); }
        }

        public ObservableCollection<CustomerSession> BasketProducts { get; set; }

        private CustomerSessionSingleton()
        {
            BasketProducts = new ObservableCollection<CustomerSession>();
        }

        public void AddProductToBasket()
        {

        }
    }
}
