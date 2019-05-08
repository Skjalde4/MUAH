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
            



        }
    }
}
