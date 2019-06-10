using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using ProyectoFinalXamarin.Models;


namespace ProyectoFinalXamarin.Views
{
    class AddGastosPage : ContentPage
    {
        private Entry _nombreEntry;
        private Entry _apellidosEntry;
        private Entry _fechaGastoEntry;
        private Entry _montoEntry;
        private Entry _tipoGastoEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public AddGastosPage()
        {

            this.Title = "Registrar un Nuevo Gasto";

            var myImage = new Image()
            {
                Source = FileImageSource.FromUri(
            new Uri("https://i.pinimg.com/564x/ff/0b/73/ff0b7332c013ed44a96583f98767d9c4.jpg"))
            };

            StackLayout stackLayout = new StackLayout();

            _nombreEntry = new Entry();
            _nombreEntry.Keyboard = Keyboard.Text;
            _nombreEntry.Placeholder = "Ingrese su Nombre";
            stackLayout.Children.Add(_nombreEntry);

            _apellidosEntry = new Entry();
            _apellidosEntry.Keyboard = Keyboard.Text;
            _apellidosEntry.Placeholder = "Ingrese su Apellido";
            stackLayout.Children.Add(_apellidosEntry);

            _fechaGastoEntry = new Entry();
            _fechaGastoEntry.Keyboard = Keyboard.Text;
            _fechaGastoEntry.Placeholder = "dd/mm/aaaa";
            stackLayout.Children.Add(_fechaGastoEntry);

            _montoEntry = new Entry();
            _montoEntry.Keyboard = Keyboard.Text;
            _montoEntry.Placeholder = "Ingrese la Cantidad";
            stackLayout.Children.Add(_montoEntry);

            _tipoGastoEntry = new Entry();
            _tipoGastoEntry.Keyboard = Keyboard.Text;
            _tipoGastoEntry.Placeholder = "Detalle de Gasto";
            stackLayout.Children.Add(_tipoGastoEntry);

            _saveButton = new Button();
            _saveButton.Text = "Guardar";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);
            
            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Gastos>();

            var maxPK = db.Table<Gastos>().OrderByDescending(c => c.Id).FirstOrDefault();

            Gastos gastos = new Gastos()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                Nombre = _nombreEntry.Text,
                Apellidos = _apellidosEntry.Text,
                FechaGasto = _fechaGastoEntry.Text,
                Monto = _montoEntry.Text,
                TipoGasto = _tipoGastoEntry.Text
            };
            db.Insert(gastos);
            await DisplayAlert(null, "El registro de gasto de: " + gastos.Nombre + " fue guardado exitosamente.", "Ok");
            await Navigation.PopAsync();
        }

    }
}
