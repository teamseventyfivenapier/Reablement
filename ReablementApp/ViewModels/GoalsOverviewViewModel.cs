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

namespace ReablementApp.ViewModels
{
    public class GoalsOverviewViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Goal> Goals { get; set; }
        public AsyncCommand RefreshCommand { get; }
        //public ICommand AddGoalCommand => new Command(AddGoal);
        //public AsyncCommand<Goal> AddGoalCommand { get; }
        //public ICommand AddGoalCommand { get; }
        //public Command GetGoalsCommand { get; }

        public GoalsOverviewViewModel()
        {
            RefreshCommand = new AsyncCommand(Refresh);
            //AddGoalCommand = new AsyncCommand<GoalModel>(AddGoal);
            //AddGoalCommand = new Command(async () => await AddGoal());
            //AddGoalCommand = new Command(AddGoal);
            //GetGoalsCommand = new Command(async () => await GetGoalsAsync());

            Goals = new ObservableRangeCollection<Goal>();
            Goals.Add(new Goal { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            Goals.Add(new Goal { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            Goals.Add(new Goal { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            Goals.Add(new Goal { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
            Goals.Add(new Goal { GoalName = "Make Dinner", GoalTasks = "Go to kichen, Get pots and pans, Get ingrediants, Cook." });
        }

        //async Task GetGoalsAsync()
        //{
        //    if (IsBusy)
        //        return;

        //    try
        //    {
        //        IsBusy = true;

        //        var json = await Client.GetStringAsync("https://montemagno.com/monkeys.json");
        //        var goals = Goal.FromJson(json);

        //        Goals.Clear();
        //        foreach (var goal in goals)
        //            Goals.Add(goal);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Unable to get goals: {ex.Message}");
        //        await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public void AddGoal()
        //{
        //    Goals.Add(GoalName);
        //}

        //public void AddGoal(object obj)
        //{
        //    Goal goal = new Goal();
        //    goal.GoalName
        //    Goals.AddRange(goal);
        //}

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
