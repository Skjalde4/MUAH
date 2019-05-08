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
using Windows.Devices.Geolocation;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;
using GMapsUWP.GeoCoding;
using MUAH.Model;
using MUAH.ViewModel;

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

        private async void MapSample_Loaded(object sender, RoutedEventArgs e)
        {
            var center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 56.25,
                Longitude = 10.38688659667969
            });

            await MapSample.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 200000));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Geopoint center = new Geopoint(new BasicGeoposition() { Latitude = 55.5443047, Longitude = 12.11542422 });
            ////create POI
            //MapIcon myPOI = new MapIcon { Location = center, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = "Superbrugsen Havdrup", ZIndex = 0 };
            //// add to map and center it
            //MapSample.MapElements.Add(myPOI);
            //MapSample.Center = center;
            //MapSample.ZoomLevel = 10;

            //await MapSample.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 300));
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Geopoint center = new Geopoint(new BasicGeoposition());
            bool isFound = false;
            int counter = 1;

            searchResult = txtSearch.Text;

            StoresViewModel SVM = new StoresViewModel();
            SVM.AddStore();
            
            foreach (var store in StoresViewModel.MyStore)
            {
                if (txtSearch.Text == store.Zipcode.ToString())
                {
                    center = new Geopoint(new BasicGeoposition() { Latitude = store.Latitude, Longitude = store.Longitude });
                    //create POI
                    MapIcon myPOI = new MapIcon { Location = center, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = store.StoreName, ZIndex = 0 };
                    // add to map and center it
                    MapSample.MapElements.Add(myPOI);
                    MapSample.Center = center;
                    MapSample.ZoomLevel = 10;

                    counter++;
                    isFound = true;
                }
            }

            if (isFound)
            {
                await MapSample.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 300*counter));
            }
            
        }

        private void MapSample_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            if (searchResult == "4622")
            {
                ((Frame)Window.Current.Content).Navigate(typeof(SpecificStore));
            }
          
        }
    }
}
