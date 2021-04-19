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
    public partial class FeedbackSendPage : ContentPage
    {
        public FeedbackSendPage()
        {
            InitializeComponent();
            BindingContext = new FeedbackSendViewModel();
        }

        private void btnSendMsg_Clicked(object sender, EventArgs e)
        {
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedbackPage());
        }
    }
}