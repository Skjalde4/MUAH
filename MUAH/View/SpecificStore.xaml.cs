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
using MUAH.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MUAH
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpecificStore : Page
    {
        public SpecificStore()
        {
            this.InitializeComponent();
        }

        private void BtnMUAH_Click(object sender, RoutedEventArgs e)
        {
            ((Frame) Window.Current.Content).Navigate(typeof(MenuPage));
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            HidePanels(null);
            pnlBackground.Visibility = Visibility.Collapsed;
            txtUgensTilbud.Visibility = Visibility.Collapsed;
            btnGlobalAvis.Visibility = Visibility.Collapsed;
            btnLokalAvis.Visibility = Visibility.Collapsed;
        }

        private void HidePanels(RelativePanel myPanel)
        {
            List<RelativePanel> myPanels = new List<RelativePanel>();

            myPanels.Add(pnlAfdelinger);
            myPanels.Add(pnlÅbningstider);
            myPanels.Add(pnlKundeservice);

            if (myPanel != null)
            {
                myPanels.Remove(myPanel);
                pnlBackground.Visibility = Visibility.Visible;
                myPanel.Visibility = Visibility.Visible;
            }

            foreach (var items in myPanels)
            {
                items.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnÅbningstider_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlÅbningstider);
            txtUgensTilbud.Visibility = Visibility.Collapsed;
            btnGlobalAvis.Visibility = Visibility.Collapsed;
            btnLokalAvis.Visibility = Visibility.Collapsed;
        }

        private void BtnAfdelinger_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlAfdelinger);
            txtUgensTilbud.Visibility = Visibility.Collapsed;
            btnGlobalAvis.Visibility = Visibility.Collapsed;
            btnLokalAvis.Visibility = Visibility.Collapsed;
        }

        private void BtnKundeservice_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(pnlKundeservice);
            txtUgensTilbud.Visibility = Visibility.Collapsed;
            btnGlobalAvis.Visibility = Visibility.Collapsed;
            btnLokalAvis.Visibility = Visibility.Collapsed;
        }

        private void BtnTilbud_Click(object sender, RoutedEventArgs e)
        {
            HidePanels(null);
            pnlBackground.Visibility = Visibility.Collapsed;

            txtUgensTilbud.Visibility = Visibility.Visible;
            btnGlobalAvis.Visibility = Visibility.Visible;
            btnLokalAvis.Visibility = Visibility.Visible;
        }

        private void BtnSmileyRapport_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(SmileyRapport));
        }
    }
}
