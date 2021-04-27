using MvvmHelpers;
using ReablementApp.Models;
using ReablementApp.Services;
using ReablementApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReablementApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Create a new ObservableRangeCollection of type Client for the current client. This will notifiy us
        //When items are changed
        public ObservableRangeCollection<Client> CurrentClient { get; set; }

        //This command will use the BackToClients method which will navigate the user back to the clients page
        public MvvmHelpers.Commands.Command LoginCommand { get; }



        public LoginViewModel()
        {
            _ = LoadClients();

            CurrentClient = new ObservableRangeCollection<Client>();

            SetPreferences();

            LoginCommand = new MvvmHelpers.Commands.Command(Login);
        }

        //Method to login and set users.
        private void Login()
        {
            Preferences.Set("username", UserName);

            //TODO stored access token
            //var response = Preferences.Get("username", string.Empty);

            Preferences.Set("password", Password);

            //TODO stored access token
            //var Passwordresponse = Preferences.Get("password", string.Empty);

            Preferences.Set("loginSwitch", IsSwitchedToggled == true);
            var switchResponse = Preferences.Get("switch", false);

            //TODO sort picker.
            // User.CurrentUser = picker.SelectedItem.ToString();

            if (User.CurrentUser == "Client")
            {


                try
                {
                    var currentClient = ClientService.GetClientChiNumberAsync(UserName);
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

        #region Properties
        private bool _isSwitchToggled = false;
        public bool IsSwitchedToggled
        {
            get { return _isSwitchToggled; }
            set
            {
                _isSwitchToggled = value;
                OnPropertyChanged(nameof(IsSwitchedToggled));
            }
        }

        private string username;

        public string UserName
        {
            get => username;
            set
            {
                if (value == username)
                    return;
                username = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                if (value == password)
                    return;
                password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void SetPreferences()
        {
            bool isswitchtoggled;
            isswitchtoggled = IsSwitchedToggled ? Preferences.Get("loginSwitch", false) : Preferences.Get("loginSwitch", true);

            if (!isswitchtoggled)
            {
                Preferences.Clear();
            }
            else
            {
                Password = Preferences.Get("password", string.Empty);
                UserName = Preferences.Get("username", string.Empty);
                IsSwitchedToggled = Preferences.Get("loginSwitch", false);
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
