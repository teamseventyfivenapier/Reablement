
using ReablementApp.Models;
using ReablementApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ReablementApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {




            InitializeComponent();



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
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
