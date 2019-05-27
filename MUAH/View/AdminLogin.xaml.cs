using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class AdminLogin : Page
    {
        public AdminLogin()
        {
            this.InitializeComponent();
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            pnlCreate.Visibility = Visibility.Collapsed;
        }

        private void BtnOpretAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            pnlLogin.Visibility = Visibility.Collapsed;
            pnlCreate.Visibility = Visibility.Visible;
        }

        private void BtnAnnullerAdmin_Click(object sender, RoutedEventArgs e)
        {
            ((Frame) Window.Current.Content).Navigate(typeof(MainPage));
        }

        private void BtnAnnullerOpretAdmin_Click(object sender, RoutedEventArgs e)
        {
            ((Frame) Window.Current.Content).Navigate(typeof(MainPage));
        }

        private void BtnOpretAdmin_Click(object sender, RoutedEventArgs e)
        {
            ((Frame) Window.Current.Content).Navigate(typeof(AdminEdit));
        }

        private void TxtboxCVRNoAdminLogin_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key == VirtualKey.Number0 ||
                 e.Key == VirtualKey.Number1 ||
                 e.Key == VirtualKey.Number2 ||
                 e.Key == VirtualKey.Number3 ||
                 e.Key == VirtualKey.Number4 ||
                 e.Key == VirtualKey.Number5 ||
                 e.Key == VirtualKey.Number6 ||
                 e.Key == VirtualKey.Number7 ||
                 e.Key == VirtualKey.Number8 ||
                 e.Key == VirtualKey.Number9) &&
                txtboxCVRNoAdminLogin.Text.Length <= 7)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtboxCVRNoOpretAdmin_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key == VirtualKey.Number0 ||
                 e.Key == VirtualKey.Number1 ||
                 e.Key == VirtualKey.Number2 ||
                 e.Key == VirtualKey.Number3 ||
                 e.Key == VirtualKey.Number4 ||
                 e.Key == VirtualKey.Number5 ||
                 e.Key == VirtualKey.Number6 ||
                 e.Key == VirtualKey.Number7 ||
                 e.Key == VirtualKey.Number8 ||
                 e.Key == VirtualKey.Number9) &&
                txtboxCVRNoOpretAdmin.Text.Length <= 7)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
