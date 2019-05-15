using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.Model;

namespace MUAH.ViewModel
{
    class StoresViewModel
    {
        private static List<Stores> _store;

        public StoresViewModel()
        {
            _store = new List<Stores>();
            AddStore();
            
        }

        public static List<Stores> MyStore
        {
            get => _store;
            set => _store = value;
        }
            
        public void AddStore()
        {
            Stores myStore1 = new Stores("Skovvej 3, 4622 Havdrup", 4622, "SuperBrugsen Havdrup", 55.5443047, 12.11542422);
            _store.Add(myStore1);

            Stores myStore2 = new Stores("Algade 51, 4000 Roskilde", 4000, "Superbrugsen Roskilde", 55.64067382, 12.08924593);
            _store.Add(myStore2);

            Stores myStore3 = new Stores("Hyrdehøj Bygade 6A, 4000 Roskilde", 4000, "Kvickly Hyrdehøj", 55.63422463, 12.05426067);
            _store.Add(myStore3);

            Stores myStore4 = new Stores("Klosterengen 58, 4000 Roskilde", 4000, "Dagli'Brugsen Hedegårdene", 55.64903508, 12.10491657);
            _store.Add(myStore4);

            Stores myStore5 = new Stores("Dyssegårdsvej 30-32, 4621 Gadstrup", 4621, "Dagli'Brugsen Gadstrup", 55.56818287, 12.09326433);
            _store.Add(myStore5);

            Stores myStore6 = new Stores("Solrød Center 23, 2680 Solrød Strand", 2680, "Superbrugsen Solrød", 55.53367782, 12.21612553);
            _store.Add(myStore6);

            Stores myStore7 = new Stores("Nørretoften 1, 4320 Lejre", 4320, "Dagli'Brugsen Osted", 55.56566747, 11.96246285);
            _store.Add(myStore7);

            Stores myStore8 = new Stores("Møllevej 10, 2690 Karlslunde", 2690, "SuperBrugsen Karlslunde", 55.57162848, 12.22652695);
            _store.Add(myStore8);

            Stores myStore9 = new Stores("Tune Center 4, 4030 Tune", 4030, "SuperBrugsen Tune", 55.59548914, 12.17580843);
            _store.Add(myStore9);

            Stores myStore10 = new Stores("Ølsemaglevej 19, 4600 Køge", 4600, "SuperBrugsen Ølsemagle", 55.4926586, 12.18714125);
            _store.Add(myStore10);

            Stores myStore11 = new Stores("Vestergade 25A, 4600 Køge", 4600, "Kvickly Køge", 55.45738179, 12.17806799);
            _store.Add(myStore11);

            Stores myStore12 = new Stores("Ringstedvej 210, 4600 Køge", 4600, "Dagli'Brugsen Lellinge", 55.46686181, 12.1111462);
            _store.Add(myStore12);

            Stores myStore13 = new Stores("Vestre Ringgade 4, 6000 Kolding", 6000, "SuperBrugsen Tøndervej", 55.48777774, 9.46574263);
            _store.Add(myStore13);

            Stores myStore14 = new Stores("Vestre Ringgade 2, 6000 Kolding", 6000, "Fakta Kolding", 55.48738572, 9.46566141);
            _store.Add(myStore14);

            Stores myStore15 = new Stores("Sct. Laurentii Vej 28, 9990 Skagen", 9990, "SuperBrugsen Skagen", 57.72294432, 10.59087843);
            _store.Add(myStore15);

            Stores myStore16 = new Stores("Skibhusvej 70A, 5000 Odense", 5000, "Kvickly Odense", 55.40714541, 10.39221857);
            _store.Add(myStore16);

            Stores myStore17 = new Stores("Møllevænget 1, 5592 Ejby", 5592, "Kvickly Odense", 55.43049654, 9.92962578);
            _store.Add(myStore17);

            Stores myStore18 = new Stores("Sundgårdsvej 1, 8700 Horsens", 5592, "SuperBrugsen Stensballe", 55.87255984, 9.90277252);
            _store.Add(myStore18);

            Stores myStore19 = new Stores("Vestsjællandscentret 8, 4200 Slagelse", 4200, "Kvickly Slagelse", 55.40674152, 11.35474617);
            _store.Add(myStore19);

            Stores myStore20 = new Stores("Jægergårdsgade 16, 8000 Aarhus", 8000, "SuperBrugsen Jægergårdsgade", 56.14794524, 10.19805587);
            _store.Add(myStore20);

            Stores myStore21 = new Stores("Merkurvej 1C, Suite 63, 7400 Herning", 7400, "SuperBrugsen Herning", 56.13534154, 8.99949573);
            _store.Add(myStore21);

            Stores myStore22 = new Stores("Ristingevej 27, 5932 Humble", 5932, "SuperBrugsen Humble", 54.82568322, 10.69430643);
            _store.Add(myStore22);

            Stores myStore23 = new Stores("Nybrovej 21, 3760 Gudhjem", 3760, "Dagli'Brugsen Østerlars", 55.16491249, 14.96585628);
            _store.Add(myStore23);

            Stores myStore24 = new Stores("Møllebakkevej 1, 8305 Samsø", 8305, "SuperBrugsen Samsø", 55.83129437, 10.59347329);
            _store.Add(myStore24);

            Stores myStore25 = new Stores("Vestergade 15, 7700 Thisted", 7700, "SuperBrugsen Thisted", 56.95467575, 8.68754744);
            _store.Add(myStore25);

        }
    }
}
