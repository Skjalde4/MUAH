using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MUAH.Annotations;
using MUAH.Command;
using MUAH.Handler;
using MUAH.Model;
using MUAH.View;

namespace MUAH.ViewModel
{
    class CustomerViewModel : INotifyPropertyChanged
    {
        private string _text;
        private ObservableCollection<CustomerSession> _customerSessions;
        private ObservableCollection<Customer> _customers;
        public CustomerSingleton CustomerSingleton { get; set; }

        private ICommand _createCustomerCommand;
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

        public string phoneNo { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int id { get; set; }


        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => _customers = value;
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value; 
                OnPropertyChanged("Text");
            }
        }

        public void CheckCustomer()
        {
            foreach (var customer in CustomerSingleton.Customers)
            {
                if (customer.PhoneNo == phoneNo && customer.Password == password)
                {
                    ((Frame) Window.Current.Content).Navigate(typeof(MenuPage));
                }
            }

            Text = "Brugeren blev ikke fundet";
        }

        public ICommand CreateCustomerCommand
        {
            get { return _createCustomerCommand ?? (_createCustomerCommand = new RelayCommand(CustomerHandler.CreateCustomer));}
            set { _createCustomerCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
