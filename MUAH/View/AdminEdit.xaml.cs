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
    public sealed partial class AdminEdit : Page
    {
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
    }
}
