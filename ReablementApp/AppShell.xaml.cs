using ReablementApp.Models;

namespace ReablementApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();


            //Depending on the type of user that is logged into the application, the tabs, pages and navigation between
            //Pages will change. 
            if (User.CurrentUser == "Client")
            {
                ClientTabs.IsVisible = true;

                OTTabs.IsVisible = false;
                ManagerTabs.IsVisible = false;
                CarerTabs.IsVisible = false;
            }
            else if (User.CurrentUser == "Occupational Therapist")
            {
                OTTabs.IsVisible = true;

                ClientTabs.IsVisible = false;
                ManagerTabs.IsVisible = false;
                CarerTabs.IsVisible = false;
            }
            else if (User.CurrentUser == "Management")
            {
                ManagerTabs.IsVisible = true;

                OTTabs.IsVisible = false;
                ClientTabs.IsVisible = false;
                CarerTabs.IsVisible = false;
            }
            else if (User.CurrentUser == "Carer")
            {
                CarerTabs.IsVisible = true;

                ClientTabs.IsVisible = false;
                OTTabs.IsVisible = false;
                ManagerTabs.IsVisible = false;
            }
        }
    }
}