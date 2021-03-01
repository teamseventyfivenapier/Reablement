using ReablementApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ReablementApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}