using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReablementApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentGoalPage : ContentPage
    {
        public CurrentGoalPage(string GoalName, string Task)
        {
            InitializeComponent();
            currentGoal.Text = GoalName;
            currentTask.Text = Task;
        }
    }
}