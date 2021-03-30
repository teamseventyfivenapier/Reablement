using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReablementApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Windows.Input;

namespace ReablementApp.ViewModels
{
    public class CurrentGoalViewModel : ViewModelBase
    {
        //public ICommand UpdateGoalCommand => new Command(UpdateGoal);

        public CurrentGoalViewModel()
        {
        }

        public CurrentGoalViewModel(Goal goal)
            : this()
        {
            Goal = goal;
            //Title = $"{Goal.GoalName} Details";
        }
        Goal goal;
        public Goal Goal
        {
            get => goal;
            set
            {
                if (goal == value)
                    return;

                goal = value;
                OnPropertyChanged();
            }
        }

        //public void UpdateGoal()
        //{            
        //}
    }
}
