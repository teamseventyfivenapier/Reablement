using MvvmHelpers;
using ReablementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReablementApp.ViewModels
{
    public class ClientHomeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Picture> Picture { get; set; }

        public ClientHomeViewModel()
        {
            Picture = new ObservableRangeCollection<Picture>();
            var image = "https://i.ibb.co/V3jT8mt/pexels-photo-302083.jpg";
            var image2 = "https://i.ibb.co/7y8PnHC/pexels-photo-4262424.jpg";
            var image3 = "https://i.ibb.co/Hx8YrxR/pexels-photo-4473314.jpg";
            var image4 = "https://i.ibb.co/NpJqh7M/pexels-photo-1456951.jpg";
            var image5 = "https://i.ibb.co/1866fFQ/pexels-photo-1648358.jpg";

            Picture.Add(new Picture { Quote = "“The secret of your success is found in your daily routine.”", Image = image });
            Picture.Add(new Picture { Quote = "“You can rise up from anything. You can completely recreate yourself.”", Image = image2 });
            Picture.Add(new Picture { Quote = "“Start thinking wellness, not illness”", Image = image3 });
            Picture.Add(new Picture { Quote = "“Grow through what you go through.”", Image = image4 });
            Picture.Add(new Picture { Quote = "“Your body can stand almost anything. It’s your mind that you have to convince.”", Image = image5 });

            // animate to 75% progress over 500 milliseconds with linear easing
            // await progressBar.ProgressTo(0.75, 500, Easing.Linear);
        }

        public void GetUser()
        {
        }
    }
}
