using ProyectoFinalXamarin.Models;
using ProyectoFinalXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGastoPage : ContentPage
    {
        public EditGastoPage(Gasto gasto)
        {
            var editGastoViewModel = new EditGastoViewModel();

            editGastoViewModel.SelectedGasto = gasto;

            BindingContext = editGastoViewModel;

            InitializeComponent();
        }
    }
}