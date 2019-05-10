using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.ViewModel;

namespace MUAH.Handler
{
    class AdminHandler
    {
        public AdminViewModel AdminViewModel { get; set; }

        public AdminHandler(AdminViewModel adminViewModel)
        {
            AdminViewModel = adminViewModel;
        }

        public void CreateAdmin()
        {
            if (!AdminViewModel.AdminSingleton.CheckExistingAdmin(AdminViewModel.CVRNo))
            {
                AdminViewModel.AdminSingleton.PostAdmin(AdminViewModel.Id, AdminViewModel.Username, AdminViewModel.Password, AdminViewModel.CVRNo);
            }
            else
            {
                AdminViewModel.Text = "Admin findes allerede";
            }
        }
    }
}
