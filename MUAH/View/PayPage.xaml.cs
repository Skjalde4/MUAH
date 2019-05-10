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
using Visibility = Windows.UI.Xaml.Visibility;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PayPage : Page
    {
        public PayPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            imgCheckKontrolcifre.Visibility = Visibility.Collapsed;
            imgCheckKortnummer.Visibility = Visibility.Collapsed;
            imgCheckUdløbsdatoMåned.Visibility = Visibility.Collapsed;
            imgCheckUdløbsdatoÅr.Visibility = Visibility.Collapsed;
        }

        private void TxbKortnummer_KeyDown(object sender, KeyRoutedEventArgs e)
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
                txbKortnummer.Text.Length <= 15)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxbMåned_KeyDown(object sender, KeyRoutedEventArgs e)
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
                txbMåned.Text.Length <= 1)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxbÅr_KeyDown(object sender, KeyRoutedEventArgs e)
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
                txbÅr.Text.Length <= 1)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxbKontrolcifre_KeyDown(object sender, KeyRoutedEventArgs e)
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
                txbKontrolcifre.Text.Length <= 2)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxbKortnummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbKortnummer.Text.Length == 16)
            {
                imgCheckKortnummer.Visibility = Visibility.Visible;
                imgCrossKortnummer.Visibility = Visibility.Collapsed;
                btnGennemførBetaling.IsEnabled = isPayInformationFilled();
            }
            else
            {
                imgCheckKortnummer.Visibility = Visibility.Collapsed;
                imgCrossKortnummer.Visibility = Visibility.Visible;
            }
        }

        private void TxbMåned_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbMåned.Text.Length == 2)
            {
                imgCheckUdløbsdatoMåned.Visibility = Visibility.Visible;
                imgCrossUdløbsdatoMåned.Visibility = Visibility.Collapsed;
                btnGennemførBetaling.IsEnabled = isPayInformationFilled();
            }
            else
            {
                imgCheckUdløbsdatoMåned.Visibility = Visibility.Collapsed;
                imgCrossUdløbsdatoMåned.Visibility = Visibility.Visible;
            }
        }

        private void TxbÅr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbÅr.Text.Length == 2)
            {
                imgCheckUdløbsdatoÅr.Visibility = Visibility.Visible;
                imgCrossUdløbsdatoÅr.Visibility = Visibility.Collapsed;
                btnGennemførBetaling.IsEnabled = isPayInformationFilled();
            }
            else
            {
                imgCheckUdløbsdatoÅr.Visibility = Visibility.Collapsed;
                imgCrossUdløbsdatoÅr.Visibility = Visibility.Visible;
            }
        }

        private void TxbKontrolcifre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbKontrolcifre.Text.Length == 3)
            {
                imgCheckKontrolcifre.Visibility = Visibility.Visible;
                imgCrossKontrolcifre.Visibility = Visibility.Collapsed;
                btnGennemførBetaling.IsEnabled = isPayInformationFilled();
            }
            else
            {
                imgCheckKontrolcifre.Visibility = Visibility.Collapsed;
                imgCrossKontrolcifre.Visibility = Visibility.Visible;
            }
        }

        private bool isPayInformationFilled()
        {
            if (txbKortnummer.Text.Length == 16 && txbMåned.Text.Length == 2 && txbÅr.Text.Length == 2
                && txbKontrolcifre.Text.Length == 3)
                return true;
            else
                return false;
        }

        //private void EnabelPayButton()
        //{
        //    if (txbKortnummer.Text.Length == 16 && txbMåned.Text.Length == 2 && txbÅr.Text.Length == 2
        //        && txbKontrolcifre.Text.Length == 3 )
        //    {
        //        btnGennemførBetaling.IsEnabled = true;
        //    }
        //}

        

        private void BtnGennemførBetaling_Click(object sender, RoutedEventArgs e)
        {
            if (txbKortnummer.Text.Length == 16 && txbMåned.Text.Length == 2 && txbÅr.Text.Length == 2
                && txbKontrolcifre.Text.Length == 3)
            {
                ((Frame) Window.Current.Content).Navigate(typeof(ViewOrder));
            }
        }
    }
}
