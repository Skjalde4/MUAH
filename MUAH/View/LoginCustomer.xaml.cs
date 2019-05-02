using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MUAH.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginCustomer : Page
    {
        public LoginCustomer()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Når grid'et loader på denne page, starter panellet create med at være collapsed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Grid_Loading(FrameworkElement sender, object args)
        {
            pnlCreate.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// når man trykker på opret bruger lukker login panellet, og create panellet bliver synligt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpretBrugerLogin_Click(object sender, RoutedEventArgs e)
        {
            pnlLogin.Visibility = Visibility.Collapsed;
            pnlCreate.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Når man trykker på knappen annuller i opret bruger panellet, bliver man sendt tilbage til menupage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnnullerOpretBruger_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(MenuPage));
        }
        /// <summary>
        /// Når man trykker på knappen annuller, i login panellet, bliver man sendt tilbage til manupage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnnuller_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(MenuPage));
        }
        /// <summary>
        ///Hvis man kommer fra menupage og trykker på opret bruger i opret bruger panellet, og brugeren ikke findes
        /// navigeres man tilbage til menupage.
        /// Hvis man trykker på opret bruger og nummmeret ikke findes, oprettes brugeren
        /// og man navigeres til payPage hvis man kommer fra viewbasket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpretBruger_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.callFrom == "MenuPage" && Helper.customerExist == false) 
            {
                ((Frame)Window.Current.Content).Navigate(typeof(MenuPage));
            }
            else if(Helper.callFrom == "ViewBasket" && Helper.customerExist == false)
            {
                ((Frame)Window.Current.Content).Navigate(typeof(PayPage));
            }
            else
            {
                Helper.customerExist = true;
            }
        }
    }
}
