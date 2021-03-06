﻿using ReablementApp.Models;
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
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
            BindingContext = new FeedbackViewModel();
        }

        private void cvFeedback_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushAsync(new FeedbackDetailsPage());
        }

        private void btnSendFeedback_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedbackSendPage());
        }
    }
}