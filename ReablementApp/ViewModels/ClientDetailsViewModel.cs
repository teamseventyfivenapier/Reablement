using MvvmHelpers;
using ReablementApp.Models;
using ReablementApp.Services;
using ReablementApp.Views;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ReablementApp.ViewModels
{
    //Client Details class is used as a form to populate / save / update clients details
    public class ClientDetailsViewModel : ViewModelBase
    {
        //Create a new ObservableRangeCollection of type Client for the current client. This will notifiy us
        //When items are changed
        public ObservableRangeCollection<Client> CurrentClient { get; set; }

        //This command will use the BackToClients method which will navigate the user back to the clients page
        public MvvmHelpers.Commands.Command BackToClientsPageCommand { get; }

        //This command will use in the SetClientDetails method to update the clients details or save a new client
        public MvvmHelpers.Commands.Command SetClientDetailsCommand { get; }

        #region Constructor Method

        public ClientDetailsViewModel()
        {
            Title = "Clients Details";

            CurrentClient = new ObservableRangeCollection<Client>();

            BackToClientsPageCommand = new MvvmHelpers.Commands.Command(BackToClients);

            SetClientDetailsCommand = new MvvmHelpers.Commands.Command(SetClientDetails);

            PopulateClientDetails();
        }

        #endregion Constructor Method

        #region Clients Properties
        private string clientChiNumber;

        public string ClientChiNumber
        {
            get => clientChiNumber;
            set
            {
                if (value == clientChiNumber)
                    return;
                clientChiNumber = value;
                OnPropertyChanged();
            }
        }


        private string clientFullName;

        public string ClientFullName
        {
            get => clientFullName;
            set
            {
                if (value == clientFullName)
                    return;
                clientFullName = value;
                OnPropertyChanged();
            }
        }

        private string clientFirstName;

        public string ClientFirstName
        {
            get => clientFirstName;
            set
            {
                if (value == clientFirstName)
                    return;
                clientFirstName = value;
                OnPropertyChanged();
            }
        }

        private string clientSurname;

        public string ClientSurname
        {
            get => clientSurname;
            set
            {
                if (value == clientSurname)
                    return;
                clientSurname = value;
                OnPropertyChanged();
            }
        }

        private DateTime clientDOB;

        public DateTime ClientDOB
        {
            get => clientDOB;
            set
            {
                if (value == clientDOB)
                    return;
                clientDOB = value.Date;
                OnPropertyChanged();
            }
        }

        private int clientAge;

        public int ClientAge
        {
            get => clientAge;
            set
            {
                if (value == clientAge)
                    return;
                clientAge = value;
                OnPropertyChanged();
            }
        }

        private string clientAddress;

        public string ClientAddress
        {
            get => clientAddress;
            set
            {
                if (value == clientAddress)
                    return;
                clientAddress = value;
                OnPropertyChanged();
            }
        }

        private string clientAccidentHist;

        public string ClientAccidentHist
        {
            get => clientAccidentHist;
            set
            {
                if (value == clientAccidentHist)
                    return;
                clientAccidentHist = value;
                OnPropertyChanged();
            }
        }

        private string clientMedicalConditions;

        public string ClientMedicalConditions
        {
            get => clientMedicalConditions;
            set
            {
                if (value == clientMedicalConditions)
                    return;
                clientMedicalConditions = value;
                OnPropertyChanged();
            }
        }

        private DateTime dateApointedOT;

        public DateTime DateApointedOT
        {
            get => dateApointedOT;
            set
            {
                if (value == dateApointedOT)
                    return;
                dateApointedOT = value.Date;
                OnPropertyChanged();
            }
        }

        private DateTime dateAppointedCarer;

        public DateTime DateAppointedCarer
        {
            get => dateAppointedCarer;
            set
            {
                if (value == dateAppointedCarer)
                    return;
                dateAppointedCarer = value.Date;
                OnPropertyChanged();
            }
        }

        private DateTime dateJoinedRE;

        public DateTime DateJoinedRE
        {
            get => dateJoinedRE;
            set
            {
                if (value == dateJoinedRE)
                    return;
                dateJoinedRE = value.Date;
                OnPropertyChanged();
            }
        }

        private string timeOnRE;

        public string TimeOnRE
        {
            get => timeOnRE;
            set
            {
                if (value == timeOnRE)
                    return;
                timeOnRE = value;
                OnPropertyChanged();
            }
        }

        #endregion Clients Properties

        //Method to navigate back to the Clients Page
        private void BackToClients()
        {
            Application.Current.MainPage = new ClientsPage();
        }

        //Method used to populate the properties of the client with the current clients properties if a client has been selected, or
        //To create a new blank form, if the user has selected to add a new client.
        public void PopulateClientDetails()
        {
            if (CurrentClientModel.CurrentClientID != 0)
            {

                clientChiNumber = CurrentClientModel.CurrentClientChiNumber;
                ClientFullName = $"{CurrentClientModel.CurrentClientFirstName} {CurrentClientModel.CurrentClientLastName}";
                ClientFirstName = CurrentClientModel.CurrentClientFirstName;
                ClientSurname = CurrentClientModel.CurrentClientLastName;
                ClientDOB = CurrentClientModel.DOB;
                ClientAge = CurrentClientModel.Age;
                ClientAddress = CurrentClientModel.Address;
                ClientAccidentHist = CurrentClientModel.AccidentHistory;
                ClientMedicalConditions = CurrentClientModel.MedicalConditions;
                DateApointedOT = CurrentClientModel.AppointedOT;
                DateAppointedCarer = CurrentClientModel.AppointedCarer;
                DateJoinedRE = CurrentClientModel.JoinedRE;
                TimeOnRE = $"{CurrentClientModel.TimeOnRE.ToString()} Days";
            }
            else
            {

                ClientChiNumber = "";
                ClientFullName = "";
                ClientFirstName = "";
                ClientSurname = "";
                ClientDOB = DateTime.Now;
                ClientAge = 0;
                ClientAddress = "";
                ClientAccidentHist = "";
                ClientMedicalConditions = "";
                DateApointedOT = DateTime.Now;
                DateAppointedCarer = DateTime.Now;
                DateJoinedRE = DateTime.Now;
                TimeOnRE = "";
            }
        }

        //Method sets the properties of the client and saves them to the database.
        private async void SetClientDetails()
        {
            //Performs some validations
            if (ClientFirstName == "")
            {
                await App.Current.MainPage.DisplayAlert("First Name input is empty", "Please insert First Name", "OK");
                return;
            }
            else if (!Regex.IsMatch(clientChiNumber.ToString(), @"^\d{10}$"))
            {
                clientChiNumber = CurrentClientModel.CurrentClientChiNumber;
                await App.Current.MainPage.DisplayAlert("Invalid CHI Number, must be 10 digits", "try again", "OK");
                return;

            }
            else if (ClientSurname == "")
            {
                await App.Current.MainPage.DisplayAlert("Surname input is empty", "Please insert Surname", "OK");
                return;
            }
            else if (ClientAddress == "")
            {
                await App.Current.MainPage.DisplayAlert("Address input is empty", "Please insert Address", "OK");
                return;
            }
            else
            {
                //Set properties of client & add/update the clients table in the database.

                //Calculate clients age in years, based on their date of birth
                int years = DateTime.Now.Year - ClientDOB.Date.Year;

                if ((ClientDOB.Date.Month > DateTime.Now.Month) || (ClientDOB.Date.Month == DateTime.Now.Month && ClientDOB.Date.Day > DateTime.Now.Day))
                    years--;

                //Calculate time on reablement
                double timeonRE = (DateTime.Now - DateJoinedRE.Date).TotalDays;
                var timeOnRE = Math.Round(timeonRE);

                //Try to add in the new or updated client to the clients table in the database.
                try
                {
                    var client = new Client
                    {
                        Id = CurrentClientModel.CurrentClientID,
                        ChiNumber = clientChiNumber,
                        FirstName = ClientFirstName,
                        LastName = ClientSurname,
                        DOB = ClientDOB.Date,
                        Age = years,
                        Address = ClientAddress,
                        MedicalConditions = ClientMedicalConditions,
                        AccidentHistory = ClientAccidentHist,
                        TimeOnRE = timeOnRE,
                        JoinedRE = DateJoinedRE.Date,
                        AppointedCarer = DateAppointedCarer.Date,
                        AppointedOT = DateApointedOT.Date
                    };
                    await ClientService.SaveClientAsync(client);

                    await App.Current.MainPage.DisplayAlert("Update Successful", "Client details updated", "OK");

                    Application.Current.MainPage = new ClientsPage();
                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Wrong details", "try again", "OK");
                }
            }
        }
    }
}