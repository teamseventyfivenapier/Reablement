using MvvmHelpers;
using MvvmHelpers.Commands;
using ReablementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;
using ReablementApp.Services;
using System.Linq;
using ReablementApp.Views;

namespace ReablementApp.ViewModels
{
    public class GoalsOverviewViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Goal> Goals { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public MvvmHelpers.Commands.Command AddGoalCommand { get; }
        //This command will be used to pull in the remove method which will remove the selected goal from the database. 
        public AsyncCommand<Goal> RemoveCommand { get; }

        public AsyncCommand<object> SelectedCommand { get; }


        public GoalsOverviewViewModel()
        {
            PopulateGoalDetails();
         

            AddGoalCommand = new MvvmHelpers.Commands.Command(Add);

            SelectedCommand = new AsyncCommand<object>(Selected);

            Goals = new ObservableRangeCollection<Goal>();

           _ = LoadGoals();
            RefreshCommand = new AsyncCommand(Refresh);

            RemoveCommand = new AsyncCommand<Goal>(Remove);
        }


        #region Properties
        //Property for the selected client
        private Client selectedGoal;

        public Client SelectedGoal
        {
            get => selectedGoal;
            set => SetProperty(ref selectedGoal, value);
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

     


        #endregion

        //The Selected method takes the values of the selected goal from the GoalOverviewPage and stores them as the current goal
        //from the CurrentGoalModel. The loads the mai page as the App Shell. 
        public async Task Selected(object args)
        {
            var goal = args as Goal;
            if (goal == null)
                return;

            SelectedGoal = null;

            await Application.Current.MainPage.DisplayAlert("Selected", $"{goal.GoalName}", "OK");

            CurrentGoalModel.CurrentGoalID = goal.Id;
            CurrentGoalModel.GoalName = goal.GoalName;

            Application.Current.MainPage = new CurrentGoalPage();
        }




        public async void Add()
        {

            var Goalname = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of Goal");


            try
            {
                var goal = new Goal
                {
                    Id = CurrentGoalModel.Id,
                    CurrentClientID = CurrentClientModel.CurrentClientID,
                    GoalName = Goalname,


                };
                await GoalsService.SaveGoalAsync(goal);

                await App.Current.MainPage.DisplayAlert("Entry successful", "Goal Added", "OK");

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Entry Failed", "Try again", "OK");
                throw;
            }
        }

        ////Method sets the properties of the client and saves them to the database.
        //private async void SetClientDetails()
        //{


        //    //Try to add in the new or updated client to the clients table in the database.
        //    try
        //    {
        //        var client = new Client
        //        {
        //            Id = CurrentClientModel.CurrentClientID,
        //            FirstName = ClientFirstName,
        //            LastName = ClientSurname,
        //            DOB = ClientDOB.Date,
        //            Age = years,
        //            Address = ClientAddress,
        //            MedicalConditions = ClientMedicalConditions,
        //            AccidentHistory = ClientAccidentHist,
        //            TimeOnRE = timeOnRE,
        //            JoinedRE = DateJoinedRE.Date,
        //            AppointedCarer = DateAppointedCarer.Date,
        //            AppointedOT = DateApointedOT.Date
        //        };
        //        await ClientService.SaveClientAsync(client);

        //        await App.Current.MainPage.DisplayAlert("Update Successful", "Client details updated", "OK");

        //        Application.Current.MainPage = new ClientsPage();
        //    }
        //    catch (Exception)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Wrong details", "try again", "OK");
        //    }
        //}


        public void PopulateGoalDetails()
        {
            if (CurrentClientModel.CurrentClientID != 0)
            {
                ClientFullName = $"{CurrentClientModel.CurrentClientFirstName} {CurrentClientModel.CurrentClientLastName}";
               
            }

        }

        //Loads list of goals to the Goals Page when users pulls down to refresh 
        private async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Goals.Clear();

            var goals = await GoalsService.GetGoals();

            Goals.AddRange(goals);

            IsBusy = false;
        }

        //Loads in a list of goals from the Goals table in the database. 
        private async Task LoadGoals()
        {
            Goals.Clear();

            var goals = await GoalsService.GetGoals();

            Goals.AddRange(goals);
        }

        //Removes the currently selected client. 
        private async Task Remove(Goal goal)
        {
            await GoalsService.RemoveGoal(goal.Id);
            await Refresh();
        }
    }
}
    

