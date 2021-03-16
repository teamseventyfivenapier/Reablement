using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReablementApp.ViewModels
{
    public class GoalsOverviewViewModel : ViewModelBase
    {
        //public ObservableRangeCollection<Goal> Goal { get; set; }
        public AsyncCommand RefreshCommand { get; }

        public GoalsOverviewViewModel()
        {
            //Goal = new ObservableRangeCollection<Goal>();
            RefreshCommand = new AsyncCommand(Refresh);

            //Goal.Add(new Goal { GoalName = "Make Dinner", GoalProgress = goalprogress });
        }

        //Goal selectedGoal;
        //public Goal SelectedGoal
        //{
        //    get => selectedGoal;
        //    set
        //    {
        //        if (value != null)
        //        {
        //            Application.Current.MainPage.DisplayAlert("Goal Details", value.Name, "OK");
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
