using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReablementApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            SetPreferences();
        }

        private void SetPreferences()
        {
            LoginSwitch.IsToggled = Preferences.Get("loginSwitch", false);
            if (!LoginSwitch.IsToggled)
            {

                Preferences.Clear();
            }
            else
            {
                EntPassword.Text = Preferences.Get("password", string.Empty);
                EntUserName.Text = Preferences.Get("username", string.Empty);
                LoginSwitch.IsToggled = Preferences.Get("loginSwitch", false);
            }

        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("username", EntUserName.Text);

            //TODO stored access token
            //var response = Preferences.Get("username", string.Empty);

            Preferences.Set("password", EntPassword.Text);

            //TODO stored access token
            //var Passwordresponse = Preferences.Get("password", string.Empty);


            Preferences.Set("loginSwitch", LoginSwitch.IsToggled);
            var switchResponse = Preferences.Get("switch", false);

        }
    }
}