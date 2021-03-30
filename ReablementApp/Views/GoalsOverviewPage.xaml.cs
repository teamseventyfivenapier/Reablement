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
            BindingContext = new GoalsOverviewViewModel();
        }

        async void lvGoals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var goal = e.CurrentSelection.FirstOrDefault() as Goal;
            if (goal == null)
                return;

            await Navigation.PushAsync(new CurrentGoalPage(goal));
            //await Navigation.PushAsync(new CurrentGoalPage(goalDetails.GoalName, goalDetails.Tasks));
            //var goal = ((CollectionView)sender).SelectedItem as Models.GoalModel;
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