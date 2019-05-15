using MUAH.ViewModel;

namespace MUAH.Handler
{
    class CustomerHandler
    {
        /// <summary>
        /// Specifikt er en handler en mellemmand mellem singleton og viewmodel.
        /// Derfor skal handleren have en viewmodel property, samt hvorfor vi i metoden CreateCustomer anvender singletonen. 
        /// </summary>
        public CustomerViewModel CViewModel { get; set; }

        /// <summary>
        /// Skaber et nyt CustomerHandler objekt, som initialiseres med en reference til viewmodellen.
        /// </summary>
        /// <param name="customerViewModel">reference til viewmodellen</param>
        public CustomerHandler(CustomerViewModel customerViewModel)
        {
            CViewModel = customerViewModel;
        }

        /// <summary>
        /// Kalder postcustomer metoden gennem customersingletonen i viewmodellen. 
        /// </summary>
        public void CreateCustomer()
        {
            if (!CViewModel.CustomerSingleton.CheckExistingCustomer(CViewModel.phoneNo))
            {
                CViewModel.CustomerSingleton.PostCustomer(CViewModel.phoneNo, CViewModel.password, CViewModel., CViewModel.id, CViewModel.email);
            }
            else
            {
                CustomerViewModel.Name = "";
                CViewModel.Text = "Brugeren findes allerede";
            }
        }

        
    }
}
