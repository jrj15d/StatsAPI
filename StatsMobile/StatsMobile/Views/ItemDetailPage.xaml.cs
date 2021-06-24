using StatsMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace StatsMobile.Views
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