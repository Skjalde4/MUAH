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
            if (!AdminViewModel.AdminSingleton.CheckExistingAdmin(AdminViewModel.cVRNo))
            {
                AdminViewModel.AdminSingleton.PostAdmin(AdminViewModel.Id, AdminViewModel.username, AdminViewModel.password, AdminViewModel.cVRNo);
            }
            else
            {
                AdminViewModel.Text = "Admin findes allerede";
            }
        }
    }
}
