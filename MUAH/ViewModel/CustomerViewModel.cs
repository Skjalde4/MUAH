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
    class CustomerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CustomerSession> _customerSessions;
        private ObservableCollection<Customer> _customers;
        public CustomerSingleton CustomerSingleton { get; set; }

        private RelayCommand _createCustomerCommand;
        public Handler.CustomerHandler CustomerHandler { get; set; }
        

        public CustomerViewModel()
        {
            _customerSessions = new ObservableCollection<CustomerSession>();
            _customers = new ObservableCollection<Customer>();
            CustomerSingleton = CustomerSingleton.Instance;
            CustomerHandler = new Handler.CustomerHandler(this);
        }

        public ObservableCollection<CustomerSession> MySessions
        {
            get => _customerSessions;
            set => _customerSessions = value;
        }


        public ICommand CreateCustomerCommand
        {
            get { return _createCustomerCommand ?? (_createCustomerCommand = new RelayCommand(CustomerHandler.CreateCustomer));}
            //set { _createCustomerCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
