using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MUAH.Annotations;
using MUAH.Command;
using MUAH.Handler;
using MUAH.Model;

namespace MUAH.ViewModel
{
    class BasketViewModel : INotifyPropertyChanged
    {
        //TODO
        private List<CustomerSession> _sessions;

        public CustomerSessionSingleton CsSingleton { get; set; }
        public BasketHandler BasketHandler { get; set; }

        public ICommand AddProductsCommand { get; set; }

        public BasketViewModel()
        {
            CsSingleton = CustomerSessionSingleton.Instance;
            _sessions = new List<CustomerSession>();

            BasketHandler = new BasketHandler(this);
            AddProductsCommand = new RelayCommand(BasketHandler.AddProducts);
        }

        public List<CustomerSession> Session
        {
            get => _sessions;
            set => _sessions = value;
        }

        public Guid SessionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int NoOfProduct { get; set; }
        public double TotalPrice { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
