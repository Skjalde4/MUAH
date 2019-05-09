using System;
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
        /// Her bliver kortet loaded, og så har vi angivet koordinaterne på DK, så det er DK man ser, når siden loader.
        /// Nede i await sættes radius og zoom. 
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
        /// Her loades de forretninger, som vi har oprettet på kortet. Derudover laves der en metode, som beregner radius
        /// af antallet af forretninger der er i det indtastede postnummer, samt pinpoints.
        /// </summary>
        private void LoadStores()
        {
            Geopoint center = new Geopoint(new BasicGeoposition());
            
            StoresViewModel SVM = new StoresViewModel();
            //SVM.AddStore();

            foreach (var store in StoresViewModel.MyStore)
            {
                center = new Geopoint(new BasicGeoposition() { Latitude = store.Latitude, Longitude = store.Longitude });
                MapIcon myPOI = new MapIcon { Location = center, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = store.StoreName, ZIndex = 0 };
                MapSample.MapElements.Add(myPOI);
            }
        }

        /// <summary>
        /// Når vi klikker på søgeknappen, søger den på det indstastede postnummer. Når postnummeret er fundet, zoomer kortet
        /// ind på butikken eller butikkerne. Derudover har vi lavet zoom, som udregner centrum af antallet af butikker i et givent
        /// postnummer. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Man kan kun klikke på kortet, hvis man har indstastet et postnummer og er blevet zoomet ind på byen. Dog har vi kun
        /// oprettet en side over superbrugsen havdrup, hvorfor man kun kan klikke på kortet, hvis man har valgt 4622 og befinder sig i
        /// havdrup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MapSample_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            if (searchResult == "4622")
            {
                ((Frame)Window.Current.Content).Navigate(typeof(SpecificStore));
            }
        }

        /// <summary>
        /// Dette event tjekker for hvilke taster der er trykket ned. I dette tilfælde kan man kun indtaste tal og ikke bogstaver.
        /// Som det ses i nedenstående kan den kun tage virtuelKey fra nr. 0-9.
        /// Derudover skal der indtastes 4 tal, før det er muligt at søge. Dog har vi i koden skrevet at længden skal være større eller
        /// lig med 3, da den først tæller når koden er kørt igennem, hvorfor det ender med at blive 4. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
        }

        /// <summary>
        /// Når programmet opstarter, vil søgeknappen være disabled. Dette event gør, at når teksten i søgefeltet ændres, anvendes denne.
        /// Hvis teksten indeholder 4 tegn, vil knappen blive enabled, og hvis den indeholder >4 vil den blive disabled igen. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
