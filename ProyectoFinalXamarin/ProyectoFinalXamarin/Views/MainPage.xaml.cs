using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnsqlite.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new HomePage());
            };
            btnapirest.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new HomePage2());
            };
        }
    }
}