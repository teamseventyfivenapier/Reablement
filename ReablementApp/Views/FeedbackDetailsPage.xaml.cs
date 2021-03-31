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
    public partial class FeedbackDetailsPage : ContentPage
    {
        public FeedbackDetailsPage()
        {
            InitializeComponent();
            BindingContext = new FeedbackDetailsViewModel();
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedbackPage());
        }
    }
}