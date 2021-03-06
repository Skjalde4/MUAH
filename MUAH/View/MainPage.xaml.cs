﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
using Windows.Devices.Geolocation;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;
using GMapsUWP.GeoCoding;
using MUAH.Model;
using MUAH.ViewModel;
using System.Net.Http;
using Windows.Networking.Connectivity;
using MUAH.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MUAH
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string searchResult;

        public MainPage()
        {
            this.InitializeComponent();
            MapSample.Loaded += MapSample_Loaded;
        }


        /// <summary>
        /// Her loades kortet, samt får tildelt DKs koordinater, så kortet starter på DK.
        /// Derudover udregnes radius samt hvor meget der skal være zoomet ind på kortet. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MapSample_Loaded(object sender, RoutedEventArgs e)
        {
            var center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 56.25,
                Longitude = 10.38688659667969
            });

            await MapSample.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 200000));
            LoadStores();
        }

        /// <summary>
        /// Her loades de butikker, som der er blevet oprettet, og vises derefter på kortet.
        /// Derudover bliver butikkerne tildelt et mapIcon, så 
        /// </summary>
        private void LoadStores()
        {
            Geopoint center = new Geopoint(new BasicGeoposition());
            
            StoresViewModel SVM = new StoresViewModel();
            SVM.AddStore();

            foreach (var store in StoresViewModel.MyStore)
            {
                center = new Geopoint(new BasicGeoposition() { Latitude = store.Latitude, Longitude = store.Longitude });
                MapIcon myPOI = new MapIcon { Location = center, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = store.StoreName, ZIndex = 0 };
                MapSample.MapElements.Add(myPOI);
            }
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Geopoint center = new Geopoint(new BasicGeoposition());
            bool isFound = false;
            int counter = 0;
            double latitudeSum = 0;
            double longitudeSum = 0;

            searchResult = txtSearch.Text;

            StoresViewModel SVM = new StoresViewModel();
            
            foreach (var store in StoresViewModel.MyStore)
            {
                if (txtSearch.Text == store.Zipcode.ToString())
                {
                    center = new Geopoint(new BasicGeoposition() { Latitude = store.Latitude, Longitude = store.Longitude });
                    MapSample.Center = center;
                    MapSample.ZoomLevel = 10;

                    counter++;
                    latitudeSum += store.Latitude;
                    longitudeSum += store.Longitude;
                    isFound = true;
                }
            }

            if (isFound)
            {
                latitudeSum = ((latitudeSum / counter));
                longitudeSum = ((longitudeSum / counter)); ;
                center = new Geopoint(new BasicGeoposition() {Latitude = latitudeSum, Longitude = longitudeSum});

                await MapSample.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 900*counter));
            }
            
        }

        private void MapSample_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            if (searchResult == "4622")
            {
                ((Frame)Window.Current.Content).Navigate(typeof(SpecificStore));
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyRoutedEventArgs e)
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
                txtSearch.Text.Length <= 3)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                if (txtSearch.Text.Length == 4 && e.Key == VirtualKey.Enter)
                    BtnSearch_Click(null, null);
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length == 4)
            {
                btnSearch.IsEnabled = true;
            }
            else
            {
                btnSearch.IsEnabled = false;
            }
        }

        private bool checkInternetAccess()
        {
            bool hasInternetAccess = false;

            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            hasInternetAccess = (connectionProfile != null &&
                                         connectionProfile.GetNetworkConnectivityLevel() ==
                                         NetworkConnectivityLevel.InternetAccess);

            return hasInternetAccess;
        }

        private async void Grid_Loading(FrameworkElement sender, object args)
        {  
            if (!checkInternetAccess())
            {
                ContentDialog messageDialog = new ContentDialog
                {
                    Title = "Error 404",
                    Content = "Programmet skal have adgang til internettet for at virke",
                    CloseButtonText = "Ok"
                };

               await messageDialog.ShowAsync();

               Application.Current.Exit();
            }
            
        }

        private void BtnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            ((Frame) Window.Current.Content).Navigate(typeof(AdminLogin));
        }
    }
}
