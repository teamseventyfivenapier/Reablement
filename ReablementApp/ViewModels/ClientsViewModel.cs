using MvvmHelpers;
using MvvmHelpers.Commands;
using ReablementApp.Models;
using ReablementApp.Services;
using ReablementApp.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReablementApp.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        //Create a new ObservableRangeCollection of type Client. This will notifiy us 
        //When items are changed
        public ObservableRangeCollection<Client> Client { get; set; }

        //AsyncCommand helps us bind data
        //This command will be used to pull in the refresh method, so that when a user pulls down to refresh 
        //A list of clients will be loaded onto the application from the database
        public AsyncCommand RefreshCommand { get; }

        //This comman will be used to pull in the remove method which will remove the selected client from the database. 
        public AsyncCommand<Client> RemoveCommand { get; }

        //This command will be used to store the selected client as the current client in the CurrentClientModel 
        //and load up the main page as the AppShell 
        public AsyncCommand<object> SelectedCommand { get; }

        //This command is used to pull in the Add method which sets the current client to 0 and loads
        //A new blank form for entering a new clients details. 
        public MvvmHelpers.Commands.Command AddClientCommand { get; }

        #region Constructor Method
        public ClientsViewModel()
        {
            Title = "Clients";

            Client = new ObservableRangeCollection<Client>();

            _ = LoadClients();

            SelectedCommand = new AsyncCommand<object>(Selected);

            RefreshCommand = new AsyncCommand(Refresh);

            AddClientCommand = new MvvmHelpers.Commands.Command(Add);

            RemoveCommand = new AsyncCommand<Client>(Remove);

        }
        #endregion

        //Property for the selected client
        private Client selectedClient;

        public Client SelectedClient
        {
            get => selectedClient;
            set => SetProperty(ref selectedClient, value);
        }

        //The Selected method takes the values of the selected client from the ClientsPage and stores them as the current client
        //from the CurrentClientModel. The loads the mai page as the App Shell. 
        public async Task Selected(object args)
        {
            var client = args as Client;
            if (client == null)
                return;

            SelectedClient = null;

            await Application.Current.MainPage.DisplayAlert("Selected", $"{client.FirstName}  {client.LastName}", "OK");

            CurrentClientModel.CurrentClientID = client.Id;
            CurrentClientModel.CurrentClientFirstName = client.FirstName;
            CurrentClientModel.CurrentClientLastName = client.LastName;
            CurrentClientModel.DOB = client.DOB;
            CurrentClientModel.Age = client.Age;
            CurrentClientModel.Address = client.Address;
            CurrentClientModel.MedicalConditions = client.MedicalConditions;
            CurrentClientModel.AccidentHistory = client.AccidentHistory;
            CurrentClientModel.TimeOnRE = client.TimeOnRE;
            CurrentClientModel.JoinedRE = client.JoinedRE;
            CurrentClientModel.AppointedCarer = client.AppointedCarer;
            CurrentClientModel.AppointedOT = client.AppointedOT;

            Application.Current.MainPage = new AppShell();
            //Application.Current.MainPage = new ClientDetailsPage();
        }

        //Sets the CurrentClient d to 0, so that a new client can be added
        //Navigates to the Clients Detail Page which populates an empty form 
        //For a new client to be added.
        private void Add()
        {
            CurrentClientModel.CurrentClientID = 0;
            Application.Current.MainPage = new ClientDetailsPage();
        }

        //Removes the currently selected client. 
        private async Task Remove(Client client)
        {
            await ClientService.RemoveClient(client.Id);
            await Refresh();
        }

        //Loads list of clients to the Clients Page when users pulls down to refresh 
        private async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Client.Clear();

            var clients = await ClientService.GetClients();

            Client.AddRange(clients);

            IsBusy = false;
        }

        //Loads in a list of clients from the Clients table in the database. 
        private async Task LoadClients()
        {
            Client.Clear();

            var clients = await ClientService.GetClients();

            Client.AddRange(clients);
        }
    }
}