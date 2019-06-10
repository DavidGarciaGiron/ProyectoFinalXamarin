using System;
using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.Views;
using Xamarin.Forms;

namespace ProyectoFinalXamarin.Views
{
    public partial class HomePage2 : ContentPage
    {
        public HomePage2()
        {
            InitializeComponent();
        }
        
        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGastoPage());
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var gasto = e.Item as Gasto;

            Navigation.PushAsync(new EditGastoPage(gasto));
        }

    }
}