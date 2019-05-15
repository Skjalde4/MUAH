﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.Vpn;
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
        //private static string _name;
        public static string Name { get; set; }
        private ObservableCollection<CustomerSession> _customerSessions;
        private ObservableCollection<Customer> _customers;
        public CustomerSingleton CustomerSingleton { get; set; }

        private ICommand _createCustomerCommand;
        private ICommand _selectCustomerCommand;
        public CustomerHandler CustomerHandler { get; set; }
        public Customer SelectedCustomer { get; set; }

        
        public CustomerViewModel()
        {
            _customerSessions = new ObservableCollection<CustomerSession>();
            _customers = new ObservableCollection<Customer>();
            CustomerSingleton = CustomerSingleton.Instance;
            CustomerHandler = new CustomerHandler(this);
        }

        public ObservableCollection<CustomerSession> MySessions
        {
            get => _customerSessions;
            set => _customerSessions = value;
        }

        public string phoneNo { get; set; }
        public string password { get; set; }
        public int id { get; set; }
        public string email { get; set; }


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
                    Helper.isLoggedIn = true;

                    Name = customer.Name;
                    if (Helper.callFrom == "MenuPage")
                    {
                        ((Frame)Window.Current.Content).Navigate(typeof(MenuPage));
                    }
                    else
                    {
                        ((Frame)Window.Current.Content).Navigate(typeof(PayPage));
                    }
                }
            }

            if (!Helper.isLoggedIn)
            {
                Text = "Brugeren blev ikke fundet";
                Helper.isLoggedIn = false;
            }
        }

        public ICommand CreateCustomerCommand
        {
            get
            {
                return _createCustomerCommand ??
                       (_createCustomerCommand = new RelayCommand(CustomerHandler.CreateCustomer));
            }
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
