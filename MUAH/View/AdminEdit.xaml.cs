using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MUAH.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminEdit : Page
    {
        private ObservableCollection<Admin> _admins = new ObservableCollection<Admin>();

        public AdminEdit()
        {
            this.InitializeComponent();
        }

        private async void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Log af",
                Content = "Er du sikker på at du vil logge af?",
                PrimaryButtonText = "Ja",
                CloseButtonText = "Nej"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Log ud hvis brugeren trykker på primaryButton.
            // Ellers gør intet.
            if (result == ContentDialogResult.Primary)
            {
                ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
            }
            else
            {
                // Brugeren trykkede på CloseButton, ESC eller lignende.
                // Gør intet.
            }
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            btnFjernAdmin.Visibility = Visibility.Collapsed;
            btnTilføjAdmin.Visibility = Visibility.Collapsed;
            GWAdmin.Visibility = Visibility.Collapsed;
            pnlAdmin.Visibility = Visibility.Collapsed;
        }

        private void BtnRedigerAdmin_Click(object sender, RoutedEventArgs e)
        {
            btnFjernAdmin.Visibility = Visibility.Visible;
            btnTilføjAdmin.Visibility = Visibility.Visible;
            GWAdmin.Visibility = Visibility.Visible;
            pnlAdmin.Visibility = Visibility.Visible;

            foreach (var admin in AdminViewModel.AdminSingleton.Admins)
            {
                _admins.Add(admin);
            }
        }

        private void BtnRedigerMadUdAfHuset_Click(object sender, RoutedEventArgs e)
        {
            btnFjernAdmin.Visibility = Visibility.Collapsed;
            btnTilføjAdmin.Visibility = Visibility.Collapsed;
            GWAdmin.Visibility = Visibility.Collapsed;
            pnlAdmin.Visibility = Visibility.Collapsed;
        }
    }
}
