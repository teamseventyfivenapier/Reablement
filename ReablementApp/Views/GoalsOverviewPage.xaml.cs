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
        }

        private void btnAddGoal_Clicked(object sender, EventArgs e)
        {

        }

        //private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var goal = ((ListView)sender).SelectedItem as Models.Goal;
        //    if (goal == null)
        //        return;
        //    await DisplayAlert("Goal Selected", goal.Name, "OK");
        //}

        //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}