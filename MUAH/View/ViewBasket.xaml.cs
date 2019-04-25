using MUAH.Model;
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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ViewBasket : Page
    {
        public ViewBasket()
        {
            this.InitializeComponent();
        }

        private void BtnRetur_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(MenuPage));
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            foreach (var items in MenuPage.session)
            {
                lstBasket.Items.Add(items);
            }
        }
    }
}
