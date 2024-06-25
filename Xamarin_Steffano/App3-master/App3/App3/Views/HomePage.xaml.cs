using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Data;
using App3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            // Restablecer la apariencia predeterminada de las celdas anteriores
            foreach (var item in cv.ItemsSource)
            {
                var viewCell = cv.TemplatedItems.FirstOrDefault(c => c.BindingContext == item) as ViewCell;

                if (viewCell != null)
                {
                    // Restablecer el fondo a blanco
                    viewCell.View.BackgroundColor = Color.White;
                }
            }

            // Cambiar la apariencia del elemento seleccionado
            if (e.SelectedItem is Models.CV selectedCV)
            {
                var selectedViewCell = cv.TemplatedItems.FirstOrDefault(c => c.BindingContext == selectedCV) as ViewCell;

                if (selectedViewCell != null)
                {
                    // Realizar aquí los cambios en la apariencia según tus necesidades
                    // Puedes cambiar el color de fondo, el texto, etc.
                    // Por ejemplo, cambiar el fondo a LightGray
                    selectedViewCell.View.BackgroundColor = Color.LightGray;
                }
            }

            // Desactivar el efecto de selección de la celda
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await App.Context.GetItemsAsync();
            cv.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }
        private async void BtnDelete_Clicked(object sender , EventArgs e)
        {
            if(await DisplayAlert("Confirmacion", "¿Estas seguro de eliminar la informacion?" , "Si", "No"))
            {
                var item = (CV)(sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(item);
                if(result == 1)
                {
                    LoadItems();
                }
            }
        }
    }
}
