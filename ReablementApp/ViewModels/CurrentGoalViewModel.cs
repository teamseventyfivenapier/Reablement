using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReablementApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Windows.Input;
using MvvmHelpers.Commands;
using ReablementApp.Services;

namespace ReablementApp.ViewModels
{
    public class CurrentGoalViewModel : ViewModelBase
    {
        public ObservableRangeCollection<GoalsTasks> Tasks { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public MvvmHelpers.Commands.Command AddTaskCommand { get; }

        //This command will be used to pull in the remove method which will remove the selected goal from the database.
        public AsyncCommand<GoalsTasks> RemoveCommand { get; }

        public AsyncCommand<object> SelectedCommand { get; }

        //This command will use the BackToMainPages method which will navigate the user back to the main tabbed pages
        public MvvmHelpers.Commands.Command BackToMainPageCommand { get; }

        public CurrentGoalViewModel()
        {
            PopulateGoalDetails();

            AddTaskCommand = new MvvmHelpers.Commands.Command(AddTasks);

            Tasks = new ObservableRangeCollection<GoalsTasks>();

            _ = LoadTasks();
            RefreshCommand = new AsyncCommand(Refresh);

            RemoveCommand = new AsyncCommand<GoalsTasks>(Remove);

            BackToMainPageCommand = new MvvmHelpers.Commands.Command(BackToMainPages);
        }

        #region Properties

        private bool _isAddTaskVisible;

        public bool IsAddTaskVisible
        {
            get
            {
                return _isAddTaskVisible;
            }
            set
            {
                _isAddTaskVisible = value;
                OnPropertyChanged("IsAddTaskVisible");
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

        private string currentGoal;

        public string CurrentGoal
        {
            get => currentGoal;
            set
            {
                if (value == currentGoal)
                    return;
                currentGoal = value;
                OnPropertyChanged();
            }
        }

        //Property for the selected task
        private Client selectedTask;

        public Client SelectedGoal
        {
            get => selectedTask;
            set => SetProperty(ref selectedTask, value);
        }

        #endregion Properties

        //The Selected method takes the values of the selected goal from the GoalOverviewPage and stores them as the current goal
        //from the CurrentGoalModel. The loads the mai page as the App Shell.
        public async Task Selected(object args)
        {
            var task = args as GoalsTasks;
            if (task == null)
                return;

            SelectedGoal = null;

            await Application.Current.MainPage.DisplayAlert("Selected", $"{task.GoalTasks}", "OK");

            CurrentGoalModel.Id = task.Id;
            CurrentGoalModel.GoalName = task.GoalTasks;
        }

        //Method to navigate back to the Pages
        private void BackToMainPages()
        {
            Application.Current.MainPage = new AppShell();
        }

        public void PopulateGoalDetails()
        {
            if (CurrentClientModel.CurrentClientID != 0)
            {
                ClientFullName = $"{CurrentClientModel.CurrentClientFirstName} {CurrentClientModel.CurrentClientLastName}";
                CurrentGoal = CurrentGoalModel.GoalName;

                if (User.CurrentUser == "Client")
                {
                    IsAddTaskVisible = false;
                }
                else
                {
                    IsAddTaskVisible = true;
                }
            }
        }

        //Method to add new task to client
        public async void AddTasks()
        {
            var TaskName = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of Task");

            try
            {
                var task = new GoalsTasks
                {
                    Id = CurrentGoalModel.Id,
                    CurrentGoalID = CurrentGoalModel.CurrentGoalID,
                    GoalTasks = TaskName,
                };
                await GoalsTaskService.SaveTaskAsync(task);

                await App.Current.MainPage.DisplayAlert("Entry successful", "task Added", "OK");
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Entry Failed", "Try again", "OK");
                throw;
            }
        }

        //Loads list of tasks to the Tasks Page when users pulls down to refresh
        private async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Tasks.Clear();

            var tasks = await GoalsTaskService.GetTasks();
            Tasks.AddRange(tasks);

            IsBusy = false;
        }

        //Loads in a list of tasks from the GoalsTaskS table in the database.
        private async Task LoadTasks()
        {
            Tasks.Clear();

            var tasks = await GoalsTaskService.GetTasks();

            Tasks.AddRange(tasks);
        }

        //Removes the currently selected task.
        private async Task Remove(GoalsTasks task)
        {
            await GoalsTaskService.RemoveTask(task.Id);
            await Refresh();
        }
    }
}
