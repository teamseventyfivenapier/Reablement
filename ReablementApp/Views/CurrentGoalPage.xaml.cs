using ReablementApp.Models;
using ReablementApp.ViewModels;
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
        public CurrentGoalPage()
        {
            InitializeComponent();
            //currentGoal.Text = GoalName;
            //currentTask.Text = Task;
            BindingContext = new CurrentGoalViewModel();
        }
      

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
         
        }
    }
}