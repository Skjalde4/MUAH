using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.PersistencyService;
using MUAH.View;

namespace MUAH.Model
{
    class CustomerSessionSingleton
    {
        //TODO
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

        public void PostBasket()
        {
            foreach (var product in MenuPage.session)
            {
                BasketProducts.Add(product);
                PersistencyServiceBasket.PostBasketAsync(product);
            }
        }
    }
}
