using MvvmHelpers;
using ReablementApp.Models;
using ReablementApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReablementApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        //Create a new ObservableRangeCollection of type Client for the current client. This will notifiy us
        //When items are changed
        public ObservableRangeCollection<Client> CurrentClient { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            _ = LoadClients();

            CurrentClient = new ObservableRangeCollection<Client>();

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

            User.CurrentUser = picker.SelectedItem.ToString();

            if (User.CurrentUser == "Client")
            {
             

                try
                {
                    var currentClient = ClientService.GetClientChiNumberAsync(EntUserName.Text);
                    CurrentClientModel.CurrentClientID = currentClient.Result.Id;
                    CurrentClientModel.CurrentClientChiNumber = currentClient.Result.ChiNumber;
                    CurrentClientModel.CurrentClientFirstName = currentClient.Result.FirstName;
                    CurrentClientModel.CurrentClientLastName = currentClient.Result.LastName;
                    CurrentClientModel.DOB = currentClient.Result.DOB;
                    CurrentClientModel.Age = currentClient.Result.Age;
                    CurrentClientModel.Address = currentClient.Result.Address;
                    CurrentClientModel.MedicalConditions = currentClient.Result.MedicalConditions;
                    CurrentClientModel.AccidentHistory = currentClient.Result.AccidentHistory;
                    CurrentClientModel.TimeOnRE = currentClient.Result.TimeOnRE;
                    CurrentClientModel.JoinedRE = currentClient.Result.JoinedRE;
                    CurrentClientModel.AppointedCarer = currentClient.Result.AppointedCarer;
                    CurrentClientModel.AppointedOT = currentClient.Result.AppointedOT;


                    Application.Current.MainPage = new AppShell();

                }
                catch (Exception)
                {

                    Application.Current.MainPage.DisplayAlert("Wrong CHI Number entered, must be 10 digits", "Try again", "OK");
                    return;
                }
               
                
               

            }
            else
            {
                Application.Current.MainPage = new ClientsPage();
            }
           

        }

        //Loads list of clients to the Clients Page when users pulls down to refresh 
        private async Task LoadClients()
        {
            IsBusy = true;

            await Task.Delay(2000);

            CurrentClient.Clear();

            var clients = await ClientService.GetClients();

            CurrentClient.AddRange(clients);

            IsBusy = false;
        }
    }
}