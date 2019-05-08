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

        }
    }
}
