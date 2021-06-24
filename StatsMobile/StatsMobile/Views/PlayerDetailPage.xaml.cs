using StatsMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatsMobile.Views
{
    public partial class PlayerDetailPage : ContentPage
    {
        public PlayerDetailPage()
        {
            InitializeComponent();
            BindingContext = new PlayerDetailViewModel();
        }
    }
}