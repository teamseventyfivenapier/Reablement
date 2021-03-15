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
    }
}