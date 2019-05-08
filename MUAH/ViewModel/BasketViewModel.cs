using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MUAH.Annotations;
using MUAH.Model;

namespace MUAH.ViewModel
{
    class BasketViewModel : INotifyPropertyChanged
    {
        private List<CustomerSession> _sessions;

        public BasketViewModel()
        {
            _sessions = new List<CustomerSession>();
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
