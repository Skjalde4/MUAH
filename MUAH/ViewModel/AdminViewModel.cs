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
    class AdminViewModel : INotifyPropertyChanged
    {
        private string _text;

        private ObservableCollection<Admin> _admins;
        public AdminSingleton AdminSingleton { get; set; }

        private ICommand _createAdminCommand;
        public AdminHandler AdminHandler { get; set; }


        public AdminViewModel()
        {
            _admins = new ObservableCollection<Admin>();
            AdminSingleton = AdminSingleton.Instance;
            AdminHandler = new AdminHandler(this);
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public int CVRNo { get; set; }

        public ObservableCollection<Admin> Admins
        {
            get => _admins;
            set => _admins = value;
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

        public void CheckAdmin()
        {
            foreach (var admin in AdminSingleton.Admins)
            {
                if (admin.Username == Username && admin.Password == Password && admin.CVRNo == CVRNo)
                {
                    ((Frame) Window.Current.Content).Navigate(typeof(AdminEdit));
                }
                else
                {
                    Text = "Administrateren blev ikke fundet";
                }
            }
        }

        public ICommand CreateAdminCommand
        {
            get
            {
                return _createAdminCommand ??
                       (_createAdminCommand = new RelayCommand(AdminHandler.CreateAdmin));
            }
            set { _createAdminCommand = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
