using MvvmHelpers;
using ReablementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReablementApp.ViewModels
{
    public class ClientHomeViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Picture> Picture { get; set; }

        public ClientHomeViewModel()
        {
            Picture = new ObservableRangeCollection<Picture>();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";

            Picture.Add(new Picture { Quote = "Quote 1", Image = image });
            Picture.Add(new Picture { Quote = "Quote 1", Image = image });

            // animate to 75% progress over 500 milliseconds with linear easing
            // await progressBar.ProgressTo(0.75, 500, Easing.Linear);
        }

        public void GetUser()
        {
        }
    }
}
