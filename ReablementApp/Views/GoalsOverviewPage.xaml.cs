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
    public partial class GoalsOverviewPage : ContentPage
    {
        public GoalsOverviewPage()
        {
            InitializeComponent();
            //BindingContext = new GoalsOverviewViewModel();
        }

        //private void btnAddGoal_Clicked(object sender, EventArgs e)
        //{

        //}

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var goalDetails = e.SelectedItem as GoalModel;
            await Navigation.PushAsync(new CurrentGoalPage(goalDetails.GoalName, goalDetails.Tasks));
            //var goal = ((ListView)sender).SelectedItem as Models.GoalModel;
            //if (goal == null)
            //    return;
            //await DisplayAlert("Goal Selected", goal.GoalName, "OK");
        }

        //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}