using MvvmHelpers;
using ReablementApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReablementApp.ViewModels
{
    public class MoreViewModel : ViewModelBase
    {
        //This command will use the BackToClients method which will navigate the user back to the clients page
        public MvvmHelpers.Commands.Command LogoutCommand { get; }
        public MoreViewModel()
        {
            LogoutCommand = new MvvmHelpers.Commands.Command(Logout);
        }

        private void Logout()
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
