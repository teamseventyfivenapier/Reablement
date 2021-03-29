using MvvmHelpers;
using MvvmHelpers.Commands;
using ReablementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReablementApp.ViewModels
{
    public class GoalsOverviewViewModel : ViewModelBase
    {
        //public ICommand AddGoalCommand => new Command(AddGoal);
        public ObservableRangeCollection<GoalModel> GoalList { get; set; }
        public AsyncCommand RefreshCommand { get; }
        //public AsyncCommand<GoalModel> AddGoalCommand { get; }

        public GoalsOverviewViewModel()
        {
            RefreshCommand = new AsyncCommand(Refresh);
            //AddGoalCommand = new AsyncCommand<GoalModel>(AddGoal);

            GoalList = new ObservableRangeCollection<GoalModel>();
            GoalList.Add(new GoalModel { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            GoalList.Add(new GoalModel { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            GoalList.Add(new GoalModel { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            GoalList.Add(new GoalModel { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            GoalList.Add(new GoalModel { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
        }

        //public void AddGoal(GoalModel GoalName)
        //{
        //    GoalList.AddRange(GoalName);
        //}
        //Goal selectedGoal;
        //public Goal SelectedGoal
        //{
        //    get => selectedGoal;
        //    set
        //    {
        //        if (value != null)
        //        {
        //            Application.Current.MainPage.DisplayAlert("Goal Details", value.GoalName, "OK");
        //            previouslySelected = value;
        //            value = null;
        //        }
        //        selectedGoal = value;
        //        OnPropertyChanged();
        //    }
        //}

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
