using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.PersistencyService;

namespace MUAH.Model
{
    class AdminSingleton
    {
        /// <summary>
        /// En singleton laver en instans af sig selv, så de collections man bruger er ens på alle pages. 
        /// </summary>

        private static AdminSingleton _instance = null;

        public static AdminSingleton Instance
        {
            get { return _instance ?? (_instance = new AdminSingleton()); }
        }

        public ObservableCollection<Admin> Admins { get; set; }


        public AdminSingleton()
        {
            Admins = new ObservableCollection<Admin>();
        }

        public bool CheckExistingAdmin(int CVRNo)
        {
            bool result = false;
            foreach (var admin in Admins)
            {
                if (admin.CVRNo == CVRNo)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public async void GetAdmins()
        {
            var admins = await PersistencyServiceAdmin.GetAdminAsync();
            if (Admins != null)
                foreach (var ad in admins)
                {
                    Admins.Add(ad);
                }
        }

        public void PostAdmin(int id, string username, string password, int cvrno)
        {
            Admin admins = new Admin(id, username, password, cvrno);
            Admins.Add(admins);
            PersistencyServiceAdmin.PostAdminAsync(admins);
        }

        public void PutAdmins(Admin oldAdmin, int id, string username, string password, int cvrno)
        {
            Admin admins = new Admin(id, username, password, cvrno);
            Admins.Remove(oldAdmin);
            Admins.Add(admins);
            PersistencyServiceAdmin.PutAdminAsync(admins);
        }
       
        public void DeleteAdmin(Admin adminToBeDeleted)
        {
            Admins.Remove(adminToBeDeleted);
            PersistencyServiceAdmin.DeleteAdminAsync(adminToBeDeleted);
        }

    }
}
